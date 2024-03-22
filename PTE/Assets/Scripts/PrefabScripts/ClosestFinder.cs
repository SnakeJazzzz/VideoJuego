using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestFinder : NPCSystem
{
    
    Coroutine checkCoroutine;
    public GameObject closest;

    public void Start()
    {
        checkCoroutine = StartCoroutine(FindClosest());
    }

    IEnumerator FindClosest()
    {
        while (true)
        {
            closest = npcController.manager.ClosestTarget(gameObject, npcController.owner, npcController.npcStats.attackTowers, npcController.npcStats.attackEnemies);
            yield return new WaitForSeconds(0.1f);
        }
    }

   
}
