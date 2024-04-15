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
     public CardStats(CardStats other)
     {
        

        name = other.name;
        health = other.health;
        speed = other.speed;
        attack = other.attack;
        attackCooldown = other.attackCooldown;
        range = other.range;
        isStructure = other.isStructure;
        attackTowers = other.attackTowers;
        attackEnemies = other.attackEnemies;
    }
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
     public Card(Card other)
    {
        ID = other.ID;
        cardName = other.cardName;
        description = other.description;
        cost = other.cost;
        numberOfNPCs = other.numberOfNPCs;

        // Assuming CardStats has a copy constructor or a method to create a deep copy
        // This is necessary to avoid both Card objects pointing to the same CardStats instance
        stats = new CardStats(other.stats);
    }
}

[System.Serializable]
public class CardArray
{
    public Card[] cards; // The variable name should match the key in your JSON array
}