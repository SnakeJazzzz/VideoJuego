using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckData
{
    public string username;
    public string nombreMazo;
    public List<CardData> cards;
}

[System.Serializable]
public class CardData
{
    public int Cantidad;
    public int IDCarta;
    public CardData(int cantidad, int id)
   {
      Cantidad = cantidad;
      IDCarta = id;
   }
    
}

[System.Serializable]
public class CardList
{
    public List<Card> Cartas;
}
