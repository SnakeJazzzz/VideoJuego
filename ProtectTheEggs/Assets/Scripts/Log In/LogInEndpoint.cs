using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;

public class LogInEndpoint : MonoBehaviour
{
    public UserInformation userInformation;
    public UsernameValidator usernameValidator;
    public string apiURL = "http://localhost:3000/api/usuarios/";
    private string username;
    private string password;
    public GameObject textoMensajeLogIn;
    public GameObject textoMensajeErrorLI;
    public TMP_Text TextoErroresLI;
    public string loginSuccessSoundName;
    public string loginErrorSoundName;
        
    void OnEnable()
    {
        usernameValidator.ValidUsername += CheckInfo;
    }

    void OnDisable()
    {
        usernameValidator.ValidUsername -= CheckInfo;
    }
    
    void Start()
    {
        userInformation.Reset();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.musicClips[7], true); 
    }

    public void CheckInfo(string u, string p)
    {
        //Debug.Log("Last char:"+u[u.Length-1]+".");
        username = u.Substring(0, u.Length-1);
        password = p.Substring(0, p.Length-1);
        StartCoroutine(LogIn());
    }

    IEnumerator LogIn()
    {
        // We create a UnityWebRequest object and make a GET request to the API
        // We use the cardEndpoint and cardId to fetch the card data
        string ruta = apiURL + username +"/"+ password;

        //Debug.Log(username.Length + "\n"+ password.Length);

        //ruta ="http://localhost:3000/api/usuarios/test/123";
        UnityWebRequest www = UnityWebRequest.Get(ruta); 
        yield return www.SendWebRequest();

        // If the request fails, we log the error
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log($"Request failed: {www.error}");

            TextoErroresLI.text = $"Request failed: {www.error}";
            
            textoMensajeErrorLI.SetActive(true);
            yield return new WaitForSeconds(2f);
            textoMensajeErrorLI.SetActive(false);
        }
        else 
        {
            // If the request is successful, we parse the JSON data and store it in the card object
            // The response of the request is stored in the downloadHandler property of the UnityWebRequest object
            string data = www.downloadHandler.text;
            LogInCheck logInCheck = JsonUtility.FromJson<LogInCheck>(data);

            // Using the JsonUtility class, we can parse the JSON data and store it in the card object
            // It is important to note that the JSON data must match the structure of the Card class
            
            if (logInCheck.Success)
            {
                Debug.Log("Access Granted");
                userInformation.username = username;

                textoMensajeLogIn.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                
//--------------------
                textoMensajeLogIn.SetActive(true);
                SoundManager.Instance.PlaySFXByName(loginSuccessSoundName);
                yield return new WaitForSeconds(0.5f); // Wait for the sound to play a bit
                SceneManager.LoadScene("Menu");
//--------------------
                

                textoMensajeLogIn.SetActive(false);
            }
            else
            {
                Debug.Log(logInCheck.Error);

                TextoErroresLI.text = logInCheck.Error;

//--------------------
                SoundManager.Instance.PlaySFXByName(loginErrorSoundName);
                textoMensajeErrorLI.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                textoMensajeErrorLI.SetActive(false);
//--------------------

            }
        }
    }
}
