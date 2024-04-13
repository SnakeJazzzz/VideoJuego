using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDeck : MonoBehaviour
{
 string url = "http://localhost:3000/api/CreateDeck"; // Endpoint to update the deck in the database.private 
public RSCards selectedCards;
    string json;
    /*
    void Start()
    {
        StartCoroutine(PostDeck());
    }

    void CreateDeck()
    {
        DeckData deckData = new DeckData
    {
        username = userInformation.username, // User's username
        cards = new List<CardData>() // List of cards to be saved
    };

    foreach (Card card in selectedDeck)
    {
        deckData.cards.Add(new CardData { IDCarta = card.ID, Cantidad = 1 }); // Assuming each card is added once
    }

    string json = JsonUtility.ToJson(deckData);
    yield return StartCoroutine(PostDeck(json));
    }

    IEnumerator PostDeck()
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
        Debug.Log("Deck saved successfully.");
        // ... Handle successful deck save ...
    }
}*/
}
