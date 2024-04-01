using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    
    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void setActive(bool state)
    {
        gameObject.SetActive(state);
    }

    public void Display(Card card)
    {
        
        image.sprite = card.artwork;

    }

    
}
