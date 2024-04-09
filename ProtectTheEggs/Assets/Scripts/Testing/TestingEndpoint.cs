using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestingEndpoint : MonoBehaviour
{
    public string apiURL = "http://localhost:3000/api/card/1";
    
    void Start()
    {
        CheckInfo();
    }
    public void CheckInfo()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        UnityWebRequest www = UnityWebRequest.Get(apiURL); 
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
            Debug.Log(data);
            Card cardtest = JsonUtility.FromJson<Card>(data);
            
            //Debug.Log(cardtest.stats.health);
            //Debug.Log(cardtest);
            // Using the JsonUtility class, we can parse the JSON data and store it in the card object
            // It is important to note that the JSON data must match the structure of the Card class
            
           
        }
    }
}
