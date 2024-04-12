using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CardSystem", menuName = "CardSystem")]
public class CardSOSystem : ScriptableObject
{
    public RSCards cartasEnMano;
    public RSRSCards mazos;
    public RSCards mazo;
    public UserInformation userInformation;
    public Elixir elixir;
    public int selected = -1;
    public int currentIndex = 0;
    public bool useElixir = true;
    public float shuffleTime = 5f;
    public Action<int> Spawn;
    public Action GetNewCard;
    public Action<float> Shuffle;
    public Action UIShow;
    public Action<int> Select;
    public Action NoCardSelected;
    public Action NotEnoughElixir;

    public void SetMazo()
    {
        mazo = mazos.Items[userInformation.selectedDeck];
    }

    public void NewSelected(int newvalue)
    {
        newvalue--;
        if (newvalue >= cartasEnMano.Items.Count)
        {
            Debug.Log("No hay carta en ese lugar.");
            selected = -1;
            return;
        }

        //Debug.Log("Carta "+newvalue + " selecionada.");
        selected = newvalue;
        Select?.Invoke(selected);
    }

    public void OnClick()
    {
        if (selected == -1)
        {
            Debug.Log("No hay carta seleccionada.");
            NoCardSelected?.Invoke();
            return;
        }
        if (useElixir && elixir.elixirLevel < cartasEnMano.Items[selected].cost)
        {
            Debug.Log("No hay suficiente elixir.");
            NotEnoughElixir?.Invoke();
            return;
        }

        Spawn?.Invoke(selected);
        elixir.Remove(cartasEnMano.Items[selected].cost);
        cartasEnMano.Items.RemoveAt(selected);
        GetNewCard?.Invoke();
        selected = -1;
        
        UIShow?.Invoke();

        if (cartasEnMano.Items.Count == 0)
        {
            OutOfCards();
        }
    }

    public void OutOfCards()
    {
        Shuffle?.Invoke(shuffleTime);
    }

    public void ShuffleOver()
    {
       RefillCards();
    }

    public void RefillCards()
    {
        //Debug.Log("Refill cards called!" + cartasEnMano.Items.Count);
    
        while (cartasEnMano.Items.Count < 6)
        //while (x < 6)
        {
            GetNewCard?.Invoke();
            //Debug.Log("Giving Card!");
        }

        //Debug.Log("Refilling over there are "+ cartasEnMano.Items.Count + " cards");

        UIShow?.Invoke();
    }
}