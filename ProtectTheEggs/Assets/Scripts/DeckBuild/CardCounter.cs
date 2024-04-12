using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CardCounter : MonoBehaviour
{
    public int count;
    //public string textToAdd = "/20 Cards";
    public TMP_Text counterText;
    public int deckSize = 20;
    public bool status = false;
    
    public void ChangeCount(int x)
    {
        count += x;
        status = count == deckSize;
        counterText.text = count.ToString() + "/" +deckSize + " Cards";
        
    }
}
