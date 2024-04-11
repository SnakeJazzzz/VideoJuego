using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestingEndpoint : MonoBehaviour
{
    private string apiURL = "http://localhost:3000/api/mazo/";
    
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
        WWWForm form = new WWWForm();
        form.AddField("nombreMazo", "MazoTest");
        form.AddField("username", "test");
        form.AddField("cartaDatos", "1,2,3,4");
        form.AddField("cantidadDatos", "2,2,2,2");

        UnityWebRequest www = UnityWebRequest.Post(apiURL, form); 
        yield return www.SendWebRequest();


       
        // If the request fails, we log the error
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log($"Request failed: {www.error}");
        }
        else 
        {
           
           /*
            string data = www.downloadHandler.text;
            Debug.Log(data);
            Card cardtest = JsonUtility.FromJson<Card>(data);*/
            
            //Debug.Log(cardtest.stats.health);
            //Debug.Log(cardtest);
        
             Debug.Log("succes");
           
        }
    }
}
