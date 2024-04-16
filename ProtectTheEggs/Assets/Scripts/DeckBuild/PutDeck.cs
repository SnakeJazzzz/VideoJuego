using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PutDeck : MonoBehaviour
{
    [SerializeField]
    string url = "http://localhost:3000/api/EditDeck/"; // Endpoint to update the deck in the database.private 
    public DeckBuilderManager deckBuilderManager;
    string json;
    public RSRSCards mazos;
    public UserInformation userInformation;


    void OnEnable()
    {
        deckBuilderManager.StartPut += CreateJson;
    }

    void OnDisable()
    {
        deckBuilderManager.StartPut -= CreateJson;
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
        string ruta = url + mazos.Items[userInformation.selectedDeck].ID;
        Debug.Log(ruta);

        UnityWebRequest www = new UnityWebRequest(ruta, "PUT");
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
                Debug.Log("Saved Edited Deck!");
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
