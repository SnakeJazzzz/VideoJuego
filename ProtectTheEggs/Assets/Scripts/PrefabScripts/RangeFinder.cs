using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RangeFinder : NPCSystem
{
    float distanceToClosest;
    bool isAttacking = false;
    bool isMoving = false;
    float range;
    public UnityEvent StartAttack;
    public UnityEvent StopAttack;
    public UnityEvent StartMovement;
    public UnityEvent StopMovement;
    Coroutine checkCoroutine;

    ClosestFinder closestFinder;

    protected override void Awake()
    {
        base.Awake();
        closestFinder = GetComponent<ClosestFinder>(); 
    }

    void Start()
    {
        Debug.Log("Starting Coroutine");
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
                   // Debug.Log("Enemy is null");

                    StopAttack.Invoke();
                    isAttacking = false; // Update the state
                }
                if (isMoving)
                {
                    StopMovement.Invoke();
                    isMoving = false;
                }
                yield return new WaitForSeconds(0.5f); // Wait before the next iteration
                continue;
            }
            
            distanceToClosest = Vector3.Distance(transform.position, closestFinder.closest.transform.position); 
           
            if (distanceToClosest <= npcController.npcStats.range) 
            {
                if (!isAttacking)
                {
                    Debug.Log("Starting to attack");
                    StopMovement.Invoke();
                    StartAttack.Invoke();
                    isAttacking = true; // Update the state
                }
                if (isMoving)
                {
                    StopMovement.Invoke();
                    isMoving = false;
                }
            }
            else if (distanceToClosest > npcController.npcStats.range)
            {
                if (isAttacking)
                {   
                    Debug.Log("Stopping attack");
                    StopAttack.Invoke();
                    isAttacking = false; // Update the state
                }
                if (!isMoving)
                {
                    StartMovement.Invoke();
                    isMoving = true;
                }                
            }
            
            yield return new WaitForSeconds(0.1f);

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
