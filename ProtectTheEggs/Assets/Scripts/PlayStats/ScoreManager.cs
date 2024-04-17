using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;

[System.Serializable]
public class ScoreData
{
    public int IDUsuario;
    public int newScore;
}

public class ScoreManager : MonoBehaviour
{
    private string apiUrl = "http://localhost:3000/api/usuarios/updateScore";

    public void UpdatePlayerScore(int userID, int newScore)
    {
        ScoreData data = new ScoreData()
        {
            IDUsuario = userID,
            newScore = newScore
        };

        string jsonData = JsonUtility.ToJson(data);
        Debug.Log("Sending JSON: " + jsonData); // This should now show the correct JSON structure

        StartCoroutine(SendScoreUpdate(jsonData));
    }


   private IEnumerator SendScoreUpdate(string jsonData)
{
    string url = "http://localhost:3000/api/usuarios/updateScore";
    UnityWebRequest request = new UnityWebRequest(url, "POST");
    byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    request.SetRequestHeader("Content-Type", "application/json");

    yield return request.SendWebRequest();

    if (request.result != UnityWebRequest.Result.Success)
    {
        Debug.LogError("Error: " + request.error);
    }
    else
    {
        Debug.Log("Response: " + request.downloadHandler.text);
    }
}

}





