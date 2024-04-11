using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Image artworkImage; 
    public Card cardData;
    //public UnityEngine.UI.Button button; 

    private void Awake()
    {
        // If you need to get the Image component on the GameObject this script is attached to:
        artworkImage = GetComponent<Image>();
        
        //Sprite artwork = Resources.Load<Sprite>("Cards_Artwork/Knight");
        //artworkImage.sprite = artwork;

        //button.onClick.AddListener(() => FindObjectOfType<DeckBuilder>().AddCardToDeck(cardData));
        
    }


    // This method might be called elsewhere in your UI to update the card's display.
    public void Display(Card card)
    {
        cardData = card;
        Sprite artwork = Resources.Load<Sprite>("Cards_Artwork/" + card.cardName);
        artworkImage.sprite = artwork;
        
        // Additional display setup for card name, cost, etc., can go here if needed.
    }

    public void setActive(bool state)
    {
        gameObject.SetActive(state);
    }
    
}
