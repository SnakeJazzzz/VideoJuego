using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckBuilder : MonoBehaviour
{
    public Transform selectedDeckPanel; // The panel where selected cards are shown
    public List<Card> availableCards; // List of all available cards
    public List<Card> selectedDeck = new List<Card>(); // Current selected deck
    public CardDisplay cardDisplayPrefab; // Reference to the CardDisplay prefab
    public Transform availableCardsPanel; // Add this line to declare the panel

    public RSCards mazo1;


    void Start()
    {
        PopulateAvailableCards();
    }

    private void PopulateAvailableCards()
    {
        
        foreach (Card card in availableCards)
        {
            CardDisplay display = Instantiate(cardDisplayPrefab, availableCardsPanel).GetComponent<CardDisplay>();
            display.Initialize(card, true); // true indicates this card is in the available pool and should be set up for addition
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
            CardDisplay display = Instantiate(cardDisplayPrefab, selectedDeckPanel).    GetComponent<CardDisplay>();
            display.Initialize(card, false); // false indicates this card is in the selected deck and   should be set up for removal
        }
    }

    public void FinishDeckAndLoadMenu()
    {
        // Clear the current deck list in Mazo 1
        mazo1.Items.Clear();
    
        // Add the selected deck cards to Mazo 1
        foreach (Card card in selectedDeck)
        {
            mazo1.Items.Add(card);
        }

        // Optionally save changes to Mazo 1 if you want these changes to persist between sessions
        // This would require a custom save/load system or Editor Utility if you want it to persist in  the editor

        // Load the main menu scene
        SceneManager.LoadScene("Menu"); // Replace "MainMenu" with your main menu scene name
    }   
}

