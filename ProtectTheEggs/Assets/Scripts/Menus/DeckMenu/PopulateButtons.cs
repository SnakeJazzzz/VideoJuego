using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateButtons : MonoBehaviour
{
    public List<DeckButton> deckButtons;
    public UserInformation userInformation;
    public RSRSCards mazos;

    void Start()
    {
        for(int i = 0; i < mazos.Items.Count; i++)
        {
            if(mazos.Items[i].nombreMazo != "")
            {
               // Debug.Log( mazos.Items[i].nombreMazo);
                deckButtons[i].SetText(mazos.Items[i].nombreMazo, true);
            }
            else
            {
                deckButtons[i].SetText("Empty Slot", false);
            }
        }
    }
}
