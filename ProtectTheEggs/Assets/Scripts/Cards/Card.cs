using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card 
{
    public string cardName;
    public int cost;
    public int numberOfNPCs;
   public Stats stats;
}

[System.Serializable]
public class Stats
{
    public string name;
    public int health;
    public float speed;
    public int attack;
    public float attackCooldown;
    public int range;
    public bool isStructure;
    public bool attackTowers;
    public bool attackEnemies;
}