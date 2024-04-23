using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSplashDamage : MonoBehaviour
{
    PController pController;

    void Awake()
    {
        pController = GetComponent<PController>();
    }

    void OnEnable()
    {
        pController.Attack += Explode;
    }
     void OnDisable()
    {
        pController.Attack -= Explode;
    }


    void Explode()
    {
        Debug.Log("Explode function called!");
        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, pController.radius);
        
        Debug.Log(hitColliders.Length);
        foreach (Collider2D hit in hitColliders)
        {
            NPCController hitController = hit.GetComponent<NPCController>();
            if (hitController == null)
            {
                Debug.Log("hitController es null");
                continue;
            }
            if (hitController.owner != pController.team)
            {
                hit.GetComponent<IDamageable>().TakeDamage(pController.damage);
            }
        }

        // Optionally destroy the explosion object itself (if it's an instant effect)
        Destroy(gameObject);
    }
}
