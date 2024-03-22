using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttack : NPCSystem
{
    
    Coroutine attackCoroutine;
    ClosestFinder closestFinder;

    protected override void Awake()
    {
        base.Awake();
        closestFinder = GetComponent<ClosestFinder>();
    }

    public void InTest()
    {
        //Debug.Log("IM IN RANGE!");
        attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    public void OutTest()
    {
        if (attackCoroutine!= null)
        {
            StopCoroutine(attackCoroutine);
        }
        //Debug.Log("IM OUT OF RANGE!");
    }

    
    IEnumerator AttackCoroutine()
    {
        while (closestFinder.closest != null) // Creates an infinite loop that's controlled by starting/stopping the coroutine
        {
            //Debug.Log("NPC Attacks!");
            yield return new WaitForSeconds(npcController.npcStats.attackCooldown);
            if (closestFinder.closest != null)
            {
                closestFinder.closest.GetComponent<IDamageable>().TakeDamage(npcController.npcStats.attack);
            }
            //npcController.closest.GetComponent<IDamageable>().TakeDamage(1);
        }
        //Debug.Log("Enemy Disappeared!");
    }
}
