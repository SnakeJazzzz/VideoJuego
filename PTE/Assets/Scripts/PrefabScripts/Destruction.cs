using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameEvent gameEvent;
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    
    public void TriggerSOEvent()
    {
        gameEvent.TriggerEvent();
        Destroy(gameObject);
    }

}
