using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCSystem : MonoBehaviour
{
    protected NPCController npcController;

    protected virtual void Awake()
    {
        npcController = GetComponent<NPCController>();
    }
    
}
