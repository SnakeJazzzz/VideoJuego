using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DeckBuilderManager", menuName = "DeckBuilderManager")]
public class DeckBuilderManager : ScriptableObject
{
    public RSCards AvailableCards;
    public DeckData MazoSeleccionado;
    public GameObject CardPrefab;
    public bool CreateOrEdit; //True = Create False = Edit
    public Action StartPost;
    public Action StartPut;
    public Action<int> SavedInDB;
    //public Action PopulationOver;

}
