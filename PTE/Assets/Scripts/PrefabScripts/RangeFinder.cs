using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RangeFinder : NPCSystem
{
    float distanceToClosest;
    bool isAttacking = false;
    float range;
    public UnityEvent StartAttack;
    public UnityEvent StopAttack;
    Coroutine checkCoroutine;

    ClosestFinder closestFinder;

    protected override void Awake()
    {
        base.Awake();
        closestFinder = GetComponent<ClosestFinder>(); 
    }

    void Start()
    {
        range = npcController.npcStats.range;
        checkCoroutine = StartCoroutine(ChecktoAttack());
    }

    IEnumerator ChecktoAttack()
    {
        while (true)
        {
            if (closestFinder.closest == null)
            {
                if (isAttacking) // Only invoke StopAttack if we were previously attacking
                {
                    Debug.Log("Enemy is null");
                    StopAttack.Invoke();
                    isAttacking = false; // Update the state
                }
                yield return new WaitForSeconds(0.5f); // Wait before the next iteration
                continue;
            }
            
            distanceToClosest = Vector3.Distance(transform.position, closestFinder.closest.transform.position); // Ensure you're using the `closest` variable correctly

            if (distanceToClosest <= npcController.npcStats.range && !isAttacking)
            {
                
                    Debug.Log("Starting to attack");
                    StartAttack.Invoke();
                    isAttacking = true; // Update the state
                
            }
            else if (distanceToClosest > npcController.npcStats.range && isAttacking)
            {
                
                    Debug.Log("Stopping attack");
                    StopAttack.Invoke();
                    isAttacking = false; // Update the state
                
            }
            
            yield return new WaitForSeconds(0.5f);

        }


    } 


    /*
    void Test()
    {   

        if (npcController.closest != null)
        {
            distanceToClosest = Vector3.Distance(transform.position, npcController.closest.transform.position);
        }
        else 
        {
            distanceToClosest = Mathf.Infinity;
        }
    
        if (distanceToClosest <= npcController.npcStats.range)
        {
            //npcController.InRange = true;
            if (trigger)
            {
               InRange.Invoke();
               trigger = false;
               Debug.Log("IM IN RANGE");
            }
        }
        else
        {
            if(!trigger && npcController.closest != null)
            {
                OutOfRange.Invoke();
                trigger = true;
                Debug.Log("IM OUT OF RANGE");
            }
            
        }
    }*/
}
