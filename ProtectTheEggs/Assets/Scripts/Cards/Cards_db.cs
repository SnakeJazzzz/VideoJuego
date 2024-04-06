using System;

// Esta clase representa la información básica de una carta en el juego.
[System.Serializable]
public class Cards
{
    public string cardName;
    public string description;
    public int cost;
    public int numberOfNPCs;
   
    public Stats stats;
    // Constructor
    
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

