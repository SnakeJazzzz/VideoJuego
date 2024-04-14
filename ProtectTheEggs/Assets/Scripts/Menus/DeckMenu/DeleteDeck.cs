using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DeleteDeck : MonoBehaviour
{
    public RSRSCards mazos;
    public UserInformation userInformation;
    public string apiURL = "http://localhost:3000/api/mazo/";
   
    
    

    public void StartDelete()
    {

        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        // We create a UnityWebRequest object and make a GET request to the API
        // We use the cardEndpoint and cardId to fetch the card data
        string ruta = apiURL + mazos.Items[userInformation.selectedDeck].ID;

        Debug.Log("Deleting " + ruta);
       
       
        UnityWebRequest www = UnityWebRequest.Delete(ruta); 
        yield return www.SendWebRequest();

        // If the request fails, we log the error
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log($"Request failed: {www.error}");
        }
        else 
        {
            Debug.Log("Deleted Correctly!");
            DeleteLocally();
        }
    }

    void DeleteLocally()
    {
        mazos.Items[userInformation.selectedDeck].Reset();
        for (int i = userInformation.selectedDeck; i < mazos.Items.Count - 1; i++)
        {
            mazos.Items[i].Copy(mazos.Items[i+1]);
        }
        mazos.Items[mazos.Items.Count - 1].Reset();
        userInformation.selectedDeck = -1;
        SceneManager.LoadScene("DeckMenu");

    }   
}

