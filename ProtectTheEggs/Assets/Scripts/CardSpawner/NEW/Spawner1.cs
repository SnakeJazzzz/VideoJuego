using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner1 : MonoBehaviour
{
    public RSCards cartasEnMano;
    public CardSOSystem cardSOSystem;

    void OnEnable()
    {
        cardSOSystem.Spawn += Spawn;
    }

    void OnDisable()
    {
       cardSOSystem.Spawn -= Spawn; 
    }

   void Spawn(int index)
    {   
        Debug.Log("Spawning NPC!");
        Card card = cartasEnMano.Items[index];
        Vector3 clickPosition = Input.mousePosition;
        clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        clickPosition.z = 0;  

        for(int i = 0; i < card.numberOfNPCs; i++)
        {
            Debug.Log("Prefabs/" + card.cardName);
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + card.cardName);
            if (prefab != null)
            {
                GameObject newNPC = Instantiate(prefab, clickPosition, transform.rotation);

                newNPC.GetComponent<NPCController>().setOwnership(0, card.stats); 
                newNPC.SetActive(true);
            }
        }
    }
}




