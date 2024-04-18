using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : NPCSystem
{
    Coroutine movementCoroutine;
    ClosestFinder closestFinder;

    protected override void Awake()
    {
        base.Awake();
        closestFinder = GetComponent<ClosestFinder>();
    }

    public void StartMove()
    {
        movementCoroutine = StartCoroutine(Move());
    }

    public void StopMove()
    {
        if (movementCoroutine != null)
        {
            StopCoroutine(movementCoroutine);
        }

    }

   IEnumerator Move()
    {
        while (true)
        {
            if(closestFinder.closest != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, closestFinder.closest.transform.position, npcController.npcStats.speed * Time.deltaTime);
            }
            yield return null;
        }
       
    }
}
