using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuCard : MonoBehaviour
{
   public int value = 0;
   public TMP_Text text;
   public CardCounter cardCounter;
    public Image artworkImage; 
    public Card cardData;
    public StatsShower statsShower;
    public string soundMinus;
    public string soundPlus;

    public void ShowStats()
    {
        statsShower.ShowStats(cardData);
    }
    public void Display(Card card)
    {
        cardData = card;
        Sprite artwork = Resources.Load<Sprite>("Cards_Artwork/" + card.cardName);
        artworkImage.sprite = artwork;
    }
    private void Awake()
    {
        artworkImage = GetComponent<Image>();
        text = GetComponentInChildren<TMP_Text>();
        cardCounter = GetComponentInParent<CardCounter>();
        statsShower= GetComponentInParent<StatsShower>();
    }
    public void Plus()
    {
        value++;
        text.text = value.ToString();
        cardCounter.ChangeCount(1);
        SoundManager.Instance.PlaySFXByName(soundPlus);
        
    }

    public void Minus()
    {
        if (value == 0){return;}
        value--;
        text.text = value.ToString();
        cardCounter.ChangeCount(-1);
        SoundManager.Instance.PlaySFXByName(soundMinus);
    }
    public void SetValue(int x)
    {
        value = x;
        text.text = value.ToString();
        cardCounter.ChangeCount(x);
    }
}
