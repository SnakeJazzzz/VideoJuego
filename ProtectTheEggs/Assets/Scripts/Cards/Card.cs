using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardStats
{
    public string name;
    public int health;
    public int speed;
    public int attack;
    public float attackCooldown;
    public int range;
    public bool isStructure;
    public bool attackTowers;
    public bool attackEnemies;
}

[System.Serializable]
public class Card
{
    public int ID;
    public string cardName;
    public string description;
    public int cost;
    public int numberOfNPCs;
    public CardStats stats;
}

[System.Serializable]
public class CardArray
{
    public Card[] cards; // The variable name should match the key in your JSON array
}