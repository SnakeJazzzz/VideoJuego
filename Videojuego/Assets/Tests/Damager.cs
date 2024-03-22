using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public GameObject knight;
    Coroutine myCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Starting Coroutine");
        //myCoroutine = StartCoroutine(damage());
        //Debug.Log("After Coroutine");

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //knight.GetComponent<NPCHealth>().TakeDamage(10);
            myCoroutine = StartCoroutine(damage());
        }
    }

    // Update is called once per frame
    IEnumerator damage()
    {
        while(knight != null)
        {
            knight.GetComponent<Damageable>().TakeDamage(10);
            yield return new WaitForSeconds(10);
        }
        Debug.Log("Coroutine is over.(inside)");
        
    }
}
