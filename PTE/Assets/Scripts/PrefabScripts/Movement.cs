using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : NPCSystem
{
    Coroutine move;


    void Update()
    {
       if(npcController.closest != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, npcController.closest.transform.position, npcController.npcStats.speed * Time.deltaTime);
        }
    }
    /*
    public void inRange()
    {
         if (move != null)
        {
            StopCoroutine(move);
        }
    }

    public void outOfRange()
    {
        move = StartCoroutine(Move());
    }*/
    IEnumerator Move()
    {
        while(true)
        {
            if(npcController.closest != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, npcController.closest.transform.position, npcController.npcStats.speed * Time.deltaTime);
            }
            yield return null;
        }
    }
}

