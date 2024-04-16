using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Populator : MonoBehaviour
{
    public DeckBuilderManager deckBuilderManager;
    public Transform AvailableCardsContainer;
    public GameObject CardPrefab;
    public UserInformation userInformation;
    public RSRSCards mazos;
    public TMP_InputField nameText;
   

    public void Start()
    {

        if(mazos.Items[userInformation.selectedDeck].nombreMazo != "")
        {
            deckBuilderManager.CreateOrEdit = false;
            EditedDeck();
            
            Debug.Log("Edit Deck");
        }
        else
        {
            deckBuilderManager.CreateOrEdit = true;
            NewDeck();
        }
    }

    public void NewDeck()
    {
        foreach (Card card in deckBuilderManager.AvailableCards.Items)
        {
            MenuCard display = Instantiate(CardPrefab, AvailableCardsContainer).GetComponent<MenuCard>();
            display.Display(card); // true indicates this card is in the available pool and should be set up for addition
        }
        
        //deckBuilderManager.PopulationOver?.Invoke();
    }
    public void EditedDeck()
    {
        RSCards mazoEditado = mazos.Items[userInformation.selectedDeck];

        foreach (Card card in deckBuilderManager.AvailableCards.Items)
        {
            int count = 0;
            for(int i = 0; i < mazoEditado.Items.Count; i++)
            {
                bool found = false;
                if (card.ID == mazoEditado.Items[i].ID)
                {
                    count++;
                }
                else if (found)
                {
                    break;
                }
            }
            MenuCard display = Instantiate(CardPrefab, AvailableCardsContainer).GetComponent<MenuCard>();
            display.Display(card); // true indicates this card is in the available pool and should be set up for addition
            display.SetValue(count);

        }

        Debug.Log("Setting text box to "+mazoEditado.nombreMazo);
        nameText.text = mazoEditado.nombreMazo;
    }
}
