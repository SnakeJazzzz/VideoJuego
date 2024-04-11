using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckData
{
    public string username;
    public List<CardData> cards;
}

[System.Serializable]
public class CardData
{
    public int IDCarta;
    public int Cantidad;
}

[System.Serializable]
public class CardList
{
    public List<Card> Cartas;
}
