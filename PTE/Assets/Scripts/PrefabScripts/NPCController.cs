using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCController : MonoBehaviour
{
    public NPCStats npcStats;
    public NPCManager manager;
    public int owner;
    public GameObject closest;

    void OnEnable()
    {
        manager.Register(gameObject, owner, npcStats.isStructure);
        //Debug.Log("I belong to" + owner.ToString());
    }

    void OnDisable()
    {
        manager.Delete(gameObject, owner, npcStats.isStructure);
        
    }

    /*
    void Update()
    {
        closest = manager.ClosestTarget(gameObject, owner, npcStats.attackTowers, npcStats.attackEnemies);
    }*/

    public void setOwnership(int x)
    {
        owner = x;
    }
}
