using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDestruction : NPCSystem
{
 
    public GameEvent gameOver;
    
    public void TriggerGameOver()
    {
        gameOver.TriggerEvent();
        Destroy(gameObject);
    }
    
}

