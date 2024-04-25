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
            if (isAttacking) // Stop attacking if previously attacking
            {
                Debug.Log("Stopping attack because there is no target.");
                StopAttack.Invoke();
                isAttacking = false;
            }
            if (isMoving) // Stop moving if previously moving
            {
                Debug.Log("Stopping movement because there is no target.");
                StopMovement.Invoke();
                isMoving = false;
            }
            yield return new WaitForSeconds(0.5f);
            continue;
        }

        float distanceToClosest = Vector3.Distance(transform.position, closestFinder.closest.transform.position);

        if (distanceToClosest <= npcController.npcStats.range)
        {
            if (!isAttacking)
            {
                Debug.Log("Starting to attack: Enemy within range.");
                StopMovement.Invoke(); // Ensure movement is stopped before attacking
                StartAttack.Invoke();
                isAttacking = true;
            }
            if (isMoving) // Ensure no movement during attack
            {
                Debug.Log("Stopping movement to attack.");
                StopMovement.Invoke();
                isMoving = false;
            }
        }
        else if (distanceToClosest > npcController.npcStats.range)
        {
            if (isAttacking)
            {
                Debug.Log("Stopping attack: Enemy out of range.");
                StopAttack.Invoke();
                isAttacking = false;
            }
            if (!isMoving)
            {
                Debug.Log("Starting movement to chase enemy.");
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
