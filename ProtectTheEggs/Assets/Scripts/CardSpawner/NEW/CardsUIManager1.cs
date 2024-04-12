using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsUIManager1 : MonoBehaviour
{
    public CardSOSystem cardSOSYstem;
    public RSCards cartasEnMano;
    public List<CardDisplay> cardPanels;
    int selectChange = 40;
    int lastselected = -1;

    void OnEnable()
    {
        cardSOSYstem.UIShow += Show;
        cardSOSYstem.UIShow += Deselect;
        cardSOSYstem.Select += SelectACard;
    }

    void OnDisable()
    {
        cardSOSYstem.UIShow -= Show;
        cardSOSYstem.UIShow -= Deselect;
        cardSOSYstem.Select -= SelectACard;
    }

    public void Show()
    {
        int num = cartasEnMano.Items.Count;
        //Debug.Log("Hay " + num + " cartas");
        for (int i = 0; i < 6; i++)
        {
            if (i < num)
            {
                cardPanels[i].Display(cartasEnMano.Items[i]);
                cardPanels[i].setActive(true);
            }
            else
            {
                cardPanels[i].setActive(false);
            }
        }
    }

    public void SelectACard(int index)
    {
        //Debug.Log("Index: " + index);
        if (index == lastselected) {return;}
        Deselect();

        Vector3 pos = cardPanels[index].transform.position;
        pos.y += selectChange;
        cardPanels[index].transform.position = pos;

        lastselected = index;
    }

    public void Deselect()
    {
        if (lastselected == -1) {return;}

        Vector3 pos = cardPanels[lastselected].transform.position;
        pos.y -= selectChange;
        cardPanels[lastselected].transform.position = pos;
        lastselected = -1;

    }
}
