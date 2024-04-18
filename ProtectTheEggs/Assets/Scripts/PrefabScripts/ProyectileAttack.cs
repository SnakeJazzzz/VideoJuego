using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileAttack : NPCSystem
{
    public GameObject proyectile;
    public float Pspeed;
    public float Radius;

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
                GameObject Proyectile = Instantiate(proyectile, gameObject.transform.position, Quaternion.identity);

                Proyectile.GetComponent<PController>().SetData(closestFinder.closest, Pspeed, npcController.npcStats.attack, Radius, npcController.owner);
                Proyectile.SetActive(true);
            }
            //npcController.closest.GetComponent<IDamageable>().TakeDamage(1);
        }
        //Debug.Log("Enemy Disappeared!");
    }
}
