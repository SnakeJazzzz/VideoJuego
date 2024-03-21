using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RangeFinder : NPCSystem
{
    float distanceToClosest;
    bool trigger = true;
    
    public UnityEvent InRange;
    public UnityEvent OutOfRange;
    Coroutine checkCoroutine;

    public void Start()
    {
        checkCoroutine = StartCoroutine(FindClosest());
    }

    IEnumerator FindClosest()
    {
        while (true)
        {
            npcController.closest = npcController.manager.ClosestTarget(gameObject, npcController.owner, npcController.npcStats.attackTowers, npcController.npcStats.attackEnemies);
            yield return new WaitForSeconds(0.5f);
        }


    } 



    void Update()
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
               //Debug.Log("IM IN RANGE");
            }
        }
        else
        {
            if(!trigger && npcController.closest != null)
            {
                OutOfRange.Invoke();
                trigger = true;
                //Debug.Log("IM OUT OF RANGE");
            }
            
        }
    }
}
