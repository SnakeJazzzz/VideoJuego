using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CardAdder : MonoBehaviour
{
    public DeckBuilderManager deckBuilderManager;
    List<MenuCard> menuCards;

    

    void Start()
    {
        //StartCoroutine(Test());
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(5f);
        CountAllCards();
    }

    public void CountAllCards()
    {
        menuCards = GetComponentsInChildren<MenuCard>().ToList();


        for (int i = 0; i < menuCards.Count; i++)
        {
            if (menuCards[i].value > 0)
            {
                deckBuilderManager.MazoSeleccionado.Datos.Add(new Dato(menuCards[i].value, menuCards[i].cardDisplay.cardData));
            }
        }
        //Debug.Log(count);
    }

}
