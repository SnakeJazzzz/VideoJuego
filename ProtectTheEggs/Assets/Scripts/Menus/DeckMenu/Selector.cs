using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
public List<DeckButton> deckButtons;
public UserInformation userInformation;
public GameObject buttonsContainer;

    void Start()
    {
         if(userInformation.selectedDeck != -1)
        {
            deckButtons[userInformation.selectedDeck].Highlight();
        }
        buttonsContainer.SetActive(true);
    }


    public void NewSelect(int index)
    {

        if (userInformation.selectedDeck == index)
        {
            deckButtons[index].UnHighlight();
            userInformation.selectedDeck = -1;
        }
        else
        {
            if (userInformation.selectedDeck != -1) {deckButtons[userInformation.selectedDeck].UnHighlight();}
            userInformation.selectedDeck = index;
            deckButtons[index].Highlight();
        }
        

        if (userInformation.selectedDeck != -1)
        {
            buttonsContainer.SetActive(true);
        }
        else
        {
            buttonsContainer.SetActive(false);
        }
    }
    
}
