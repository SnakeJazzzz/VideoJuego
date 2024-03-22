using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour, IDamageable
{
    public UnityFloatEvent OnDamage;
    public void TakeDamage(float damage)
    {
       OnDamage.Invoke(-damage);
       
    }

}
