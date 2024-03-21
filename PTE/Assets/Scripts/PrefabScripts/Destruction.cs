using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : NPCSystem
{
    
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    
}
