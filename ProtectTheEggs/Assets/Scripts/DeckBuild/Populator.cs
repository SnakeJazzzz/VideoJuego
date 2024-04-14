using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populator : MonoBehaviour
{
    public DeckBuilderManager deckBuilderManager;
    public Transform AvailableCardsContainer;
    public GameObject CardPrefab;

   

    public void Start()
    {
        foreach (Card card in deckBuilderManager.AvailableCards.Items)
        {
            CardDisplay display = Instantiate(CardPrefab, AvailableCardsContainer).GetComponent<CardDisplay>();
            display.Display(card); // true indicates this card is in the available pool and should be set up for addition
        }
    }
}
