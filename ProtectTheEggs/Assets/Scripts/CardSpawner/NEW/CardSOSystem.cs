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
    public Action ShuffleOverA;
    public Action UIShow;
    public Action<int> Select;
    public Action NoCardSelected;
    public Action NotEnoughElixir;

    public void SetMazo()
    {
        Debug.Log("Index: " + userInformation.selectedDeck);
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
        ShuffleOverA?.Invoke();
        RefillCards();
    }

    public void RefillCards()
    {
        Debug.Log("Número de cartas antes de rellenar: " + cartasEnMano.Items.Count);

        for (int i = 0; i < 6; i++)
        {
            GetNewCard?.Invoke();
        }

        Debug.Log("Número de cartas después de rellenar: " + cartasEnMano.Items.Count);

        UIShow?.Invoke();
    }
}
