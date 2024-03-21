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
    }
}
