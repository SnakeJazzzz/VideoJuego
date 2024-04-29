using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class DeleteDeck : MonoBehaviour
{
    public RSRSCards mazos;
    public UserInformation userInformation;
    public string apiURL = "http://localhost:3000/api/mazo/";
    public GameObject TextoMensajeMazoBorrado;
    public GameObject TextoMensajeBorrandoMazo;
    public GameObject TextoMensajeErrorDD;
    public TMP_Text TextoErrorDD;

    public string buttonClickSoundName;

    public void StartDelete()
    {
        StartCoroutine(Delete());

        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
    }

    IEnumerator Delete()
    {
        // We create a UnityWebRequest object and make a GET request to the API
        // We use the cardEndpoint and cardId to fetch the card data
        string ruta = apiURL + mazos.Items[userInformation.selectedDeck].ID;

        Debug.Log("Deleting " + ruta);
        TextoMensajeBorrandoMazo.SetActive(true);
        yield return new WaitForSeconds(2f);
       
        UnityWebRequest www = UnityWebRequest.Delete(ruta); 
        yield return www.SendWebRequest();

        // If the request fails, we log the error
        if(www.result != UnityWebRequest.Result.Success)
        {
            TextoMensajeBorrandoMazo.SetActive(false);
            yield return new WaitForSeconds(2f);

            Debug.Log($"Request failed: {www.error}");

            TextoErrorDD.text = $"Request failed: {www.error}";

            TextoMensajeErrorDD.SetActive(true);
            yield return new WaitForSeconds(5f);
            TextoMensajeErrorDD.SetActive(false);
        }
        else 
        {
            TextoMensajeBorrandoMazo.SetActive(false);
            yield return new WaitForSeconds(2f);

            Debug.Log("Deleted Correctly!");
            DeleteLocally();

            TextoMensajeMazoBorrado.SetActive(true);
            yield return new WaitForSeconds(5f);
            TextoMensajeMazoBorrado.SetActive(false);
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
