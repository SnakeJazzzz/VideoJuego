using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostDeck : MonoBehaviour
{
    public string url = "http://localhost:3000/api/CreateDeck"; // Endpoint to update the deck in the database.private 
    public DeckBuilderManager deckBuilderManager;
    string json;
    public RSRSCards mazos;


    void OnEnable()
    {
        deckBuilderManager.StartPost += CreateJson;
    }

    void OnDisable()
    {
        deckBuilderManager.StartPost -= CreateJson;
    }


    
    void CreateJson()
    {
        //Debug.Log("Creando Json");
        string json = JsonUtility.ToJson(deckBuilderManager.MazoSeleccionado);
        Debug.Log(json);
        StartCoroutine(Post(json));
    }

    
    IEnumerator Post(string json)
    {
        UnityWebRequest www = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        www.uploadHandler = new UploadHandlerRaw(jsonToSend);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error saving deck: {www.error}");
        }
        else
        {
            string data = www.downloadHandler.text;
            DeckUpload deckUpload = JsonUtility.FromJson<DeckUpload>(data);
            if (deckUpload.Success)
            {
                Debug.Log("Saved!");
                deckBuilderManager.SavedInDB?.Invoke(deckUpload.DeckID);
            }
            else
            {
                Debug.Log(deckUpload.Error);
            }
            // ... Handle successful deck save ...
        }
    }

   

}
