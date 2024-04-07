using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class CreateAccountEndpoint : MonoBehaviour
{
    public string apiURL = "http://localhost:3000/api/usuarios";
    private string username;
    private string password;
    public UsernameValidator usernameValidator;

    void OnEnable()
    {
        usernameValidator.ValidUsername += StartPost;
    }

     void OnDisable()
    {
        usernameValidator.ValidUsername -= StartPost;
    }




    public void StartPost(string u, string p)
    {
        //Debug.Log("Last char:"+u[u.Length-1]+".");
        username = u.Substring(0, u.Length-1);
        password = p.Substring(0, p.Length-1);
        StartCoroutine(CreateAccount());
    }

    IEnumerator CreateAccount()
    {
        // We create a UnityWebRequest object and make a GET request to the API
        // We use the cardEndpoint and cardId to fetch the card data

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        Debug.Log(username);

        
        UnityWebRequest www = UnityWebRequest.Post(apiURL, form); 
        yield return www.SendWebRequest();

        // If the request fails, we log the error
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log($"Request failed: {www.error}");
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
                Debug.Log("Created new account!");
                SceneManager.LoadScene("Menu");
            }
            else
            {
                Debug.Log(logInCheck.Error);
            }
        }
    }
}