using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SessionAPIHandler : MonoBehaviour
{
    // Base URL for API requests
    public string baseUrl = "http://127.0.0.1:3000/api/partidas";
    public PartidaInfo currentPartida;
    public UserInformation userInformation;
    public WaveCounter waveCounter;
    public mapsMenu mapsMenu; // Make sure you have a MapsMenu script that contains information about the current map

    public void PopulateSessionData()
    {
        Debug.Log("PopulateSessionData called");
        currentPartida.currentSession.username = userInformation.username;
        currentPartida.currentSession.MaxOrda = waveCounter.waveNumberText.text;
        currentPartida.currentSession.NombreMapa = mapsMenu.GetCurrentMapName(); 
        StartCoroutine(CreateSession());
    }

    public IEnumerator CreateSession()
    {
        // Convert the session data to JSON
        string jsonData = JsonUtility.ToJson(currentPartida.currentSession);

        // Create a UnityWebRequest object for sending post request
        using (var www = new UnityWebRequest(baseUrl, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            // Send the request and wait for a response
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Session created successfully!");
                // Optional: Handle the response here if necessary
            }
            else
            {
                Debug.LogError("Failed to create session: " + www.error);
            }
        }
    }
}
