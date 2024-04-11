using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DeckBuilderManager", menuName = "DeckBuilderManager")]
public class DeckBuilderManager : ScriptableObject
{
    
    public RSCards AvailableCards;
    public Mazo MazoSeleccionado;
    public GameObject CardPrefab;
    public Action GetOver;

   

}
