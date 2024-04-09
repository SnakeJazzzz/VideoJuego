using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadDecks : MonoBehaviour
{

    public UserInformation userInformation;
    public RSRSCards mazos;
    public string apiURL = "http://localhost:3000/api/mazo/";
    void Start()
    {
        if(!userInformation.loadedDeck)
        {
            StartCoroutine(GetDecks());
        }
        
    }

   
    IEnumerator GetDecks()
    {
        
        string ruta = apiURL + userInformation.username ;

        UnityWebRequest www = UnityWebRequest.Get(ruta); 
        yield return www.SendWebRequest();

        // If the request fails, we log the error
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log($"Request failed: {www.error}");
        }
        else 
        {
           
            string data = www.downloadHandler.text;
            //LogInCheck logInCheck = JsonUtility.FromJson<LogInCheck>(data);
            userInformation.loadedDeck = true;
            Debug.Log(data);
        }
    }
}
