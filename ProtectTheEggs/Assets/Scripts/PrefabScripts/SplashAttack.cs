using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAttack : NPCSystem
{
    Coroutine attackCoroutine;
    ClosestFinder closestFinder;
    public int radius;
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
               Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        
                Debug.Log(hitColliders.Length);
                foreach (Collider2D hit in hitColliders)
                {
                    NPCController hitController = hit.GetComponent<NPCController>();
                    if (hitController == null){continue;}
                    if (hitController.owner != npcController.owner)
                    {
                        hit.GetComponent<IDamageable>().TakeDamage(npcController.npcStats.attack);
                    }
                }
            }
            //npcController.closest.GetComponent<IDamageable>().TakeDamage(1);
        }
        //Debug.Log("Enemy Disappeared!");
    }
}
