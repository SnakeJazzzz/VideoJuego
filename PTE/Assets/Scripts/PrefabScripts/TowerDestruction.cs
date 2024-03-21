using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDestruction : NPCSystem
{
 
    public GameEvent gameOver;
    
    public void DestroyGameObject()
    {
        gameOver.TriggerEvent();
        Destroy(gameObject);
    }
    
}

