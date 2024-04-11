using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CardCounter : MonoBehaviour
{
    public int count;
    public string textToAdd = "/20 Cards";
    public TMP_Text counterText;

    public void ChangeCount(int x)
    {
        count += x;
        counterText.text = count.ToString() + textToAdd;
        
    }
}
