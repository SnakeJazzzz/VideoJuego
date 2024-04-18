using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSingleAttack : MonoBehaviour
{
    PController pController;
    void Awake()
    {
        pController = GetComponent<PController>();
    }

    void OnEnable()
    {
        pController.Attack += SingleAttack;
    }
     void OnDisable()
    {
        pController.Attack -= SingleAttack;
    }

    void SingleAttack()
    {
        Debug.Log("Atacando!");
        pController.target.GetComponent<IDamageable>().TakeDamage(pController.damage);
        Destroy(this.gameObject);
        return;
    }
}
