using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class Health : NPCSystem
{
    
    public float health;
    public UnityFloatEvent OnHealthChange;
    public UnityEvent OnZeroHealth;
   
    public  void Start()
    {
        health = npcController.npcStats.health;
    }

    public void UpdateHealth(float damage)
    {
        health += damage;
        health = health > npcController.npcStats.health ?  npcController.npcStats.health : health;
        OnHealthChange.Invoke(health);
        if (health <= 0)
        {
            OnZeroHealth.Invoke();
        }
    }
}
