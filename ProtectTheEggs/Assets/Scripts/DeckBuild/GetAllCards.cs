using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GetAllCards : MonoBehaviour
{
    public RSCards AvailableCards;
    public UserInformation userInformation;
    public string apiURL = "http://localhost:3000/api/card";
    public GameObject textoMensajeErrorMenu;
    public TMP_Text TextoErroresMenu;

    void Start()
    {
        if(!userInformation.loadedDeck)
        {
            AvailableCards.Items.Clear();
            StartCoroutine(APIGet());
        }
    }

    IEnumerator APIGet()
    {
        UnityWebRequest www = UnityWebRequest.Get(apiURL); 
        yield return www.SendWebRequest();

        // If the request fails, we log the error
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log($"Request failed: {www.error}");

            TextoErroresMenu.text = $"Request failed: {www.error}";
            
            textoMensajeErrorMenu.SetActive(true);
            yield return new WaitForSeconds(2f);
            textoMensajeErrorMenu.SetActive(false);
        }
        else 
        {
            // If the request is successful, we parse the JSON data and store it in the card object
            // The response of the request is stored in the downloadHandler property of the UnityWebRequest object
            string data = www.downloadHandler.text;
           
            CardList cartas = JsonUtility.FromJson<CardList>(data);
            for(int i = 0; i < cartas.Cartas.Count; i++)
            {
                //Debug.Log(cartas.Cartas[i].cardName);
                AvailableCards.Items.Add(new Card(cartas.Cartas[i]));
            }
        }
    }
}
