using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class DeckBuilder : MonoBehaviour
{
    public Transform selectedDeckPanel; // The panel where selected cards are shown
    public List<Card> availableCards; // List of all available cards
    public List<Card> selectedDeck = new List<Card>(); // Current selected deck
    public CardDisplay cardDisplayPrefab; // Reference to the CardDisplay prefab
    public Transform availableCardsPanel; // Add this line to declare the panel
    public RSCards mazo1;

    public UserInformation userInformation;

    public int maxCardId = 15;


    void Start()
    {
        PopulateAvailableCards();
        StartCoroutine(LoadCardsIndividually());
    }

    private void PopulateAvailableCards()
    {
        
        foreach (Card card in availableCards)
        {
            /*
            MenuCard display = Instantiate(cardDisplayPrefab, availableCardsPanel).GetComponent<MenuCard>();
            display.Initialize(card, true); // true indicates this card is in the available pool and should be set up for addition
            */
       }
 
    }

    public void AddCardToDeck(Card card)
    {
        if (selectedDeck.Count < 8)
        {
            selectedDeck.Add(card);
            UpdateSelectedDeckDisplay();
        }
    }

    public void RemoveCardFromDeck(Card card)
    {
        if (selectedDeck.Contains(card))
        {
            selectedDeck.Remove(card);
            UpdateSelectedDeckDisplay(); // Refresh the selected cards display
        }
    }

    private void UpdateSelectedDeckDisplay()
    {
        // Clear current selected deck display
        foreach (Transform child in selectedDeckPanel)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new card displays for the selected deck
        foreach (Card card in selectedDeck)
        {
            /*
            MenuCard display = Instantiate(cardDisplayPrefab, selectedDeckPanel).    GetComponent<MenuCard>();
            display.Initialize(card, false); // false indicates this card is in the selected deck and   should be set up for removal
            */
        }
    }

// Assume you know the range of valid card IDs or have a way to determine when to stop.
IEnumerator LoadCardsIndividually()
{
    for (int id = 1; id <= maxCardId; id++)
    {
        string url = "http://localhost:3000/api/card/" + id;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error fetching card with ID {id}: {www.error}");
        }
        else
        {
            string jsonResponse = www.downloadHandler.text;
            Card card = JsonUtility.FromJson<Card>(jsonResponse);
            if (card != null && card.ID != 0) // Now you get the ID from the server response
            {
                AddCardToAvailableCards(card);
            }
        }
    }
    PopulateAvailableCards(); // Once all cards are loaded, populate the UI
}

        
    




// A method to add the card to the available list and possibly to some UI list
void AddCardToAvailableCards(Card card)
{
    availableCards.Add(card);

    // You may also want to instantiate UI elements here, or you can do it all at once
    // after all cards are loaded, as shown in the PopulateAvailableCards method.
}



    // Add a method in your DeckBuilder script to save the deck.
public IEnumerator SaveDeckCoroutine()
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
    yield return StartCoroutine(PostDeck(json)); // Send the data to the server
}




IEnumerator PostDeck(string json)
{
    string url = "http://localhost:3000/api/updateDeck"; // Endpoint to update the deck in the database.
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
}

// Call this from FinishDeckAndLoadMenu instead of SaveDeck
public void FinishDeckAndLoadMenu()
{
    Debug.Log("FinishDeckAndLoadMenu called.");
    
    mazo1.Items.Clear();
    
    Debug.Log($"Adding {selectedDeck.Count} selected cards to Mazo 1");
    foreach (Card card in selectedDeck)
    {
        mazo1.Items.Add(card);
        Debug.Log($"Added card {card.cardName} to Mazo 1");
    }

    StartCoroutine(FinishDeckAfterSave());
}


private IEnumerator FinishDeckAfterSave()
{
    // Make sure to yield the result of SaveDeckCoroutine to ensure it completes
    yield return StartCoroutine(SaveDeckCoroutine());

    // Save changes to Mazo 1 if needed for persistence here
    // SaveMazo1(); // Implement this method to persist changes to Mazo 1 if necessary

    // Finally, load the menu scene
    SceneManager.LoadScene("Menu");
}






}


