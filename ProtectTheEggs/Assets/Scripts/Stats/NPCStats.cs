using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "NPCStats", menuName = "NPCStats")]
public class NPCStats : ScriptableObject
{
    public new string name;
    public float health;
    public float speed;
    public float attack;
    public float attackCooldown;
    public float range;
    public float cost;
    public GameObject prefab;
    public bool isStructure;
    public bool attackTowers;
    public bool attackEnemies;
    

    

}
