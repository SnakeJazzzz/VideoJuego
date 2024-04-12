using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CardAdder : MonoBehaviour
{
    public DeckBuilderManager deckBuilderManager;
    List<MenuCard> menuCards;
    public GameObject CardContainer;
    public CardCounter cardCounter;
    

    void Awake()
    {
       cardCounter = CardContainer.GetComponent<CardCounter>();
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(5f);
        //CountAllCards();
    }

    public void AddAllCardss()
    {

        if (!cardCounter.status) 
        {Debug.Log("Tienes que seleccionar "+ cardCounter.deckSize+ " cartas.");return;}

        menuCards = CardContainer.GetComponentsInChildren<MenuCard>().ToList();


        for (int i = 0; i < menuCards.Count; i++)
        {
            if (menuCards[i].value > 0)
            {
                deckBuilderManager.MazoSeleccionado.Datos.Add(new Dato(menuCards[i].value, menuCards[i].cardDisplay.cardData));
            }
        }
        /*
        for (int i = 0; i < deckBuilderManager.MazoSeleccionado.Datos.Count; i++)
        {
            Debug.Log("Carta: "+ deckBuilderManager.MazoSeleccionado.Datos[i].Carta.cardName+"\nCantidad: "+ deckBuilderManager.MazoSeleccionado.Datos[i].Cantidad);
        }*/
    }

}
