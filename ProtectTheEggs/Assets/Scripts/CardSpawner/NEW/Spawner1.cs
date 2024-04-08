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
        Card card = cartasEnMano.Items[index];
        Vector3 clickPosition = Input.mousePosition;
        clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        clickPosition.z = 0;  

        for(int i = 0; i < card.numberOfNPCs; i++)
        {

            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + card.cardName);
            GameObject newNPC = Instantiate(prefab, clickPosition, transform.rotation);

            newNPC.GetComponent<NPCController>().setOwnership(0); 
            newNPC.SetActive(true);
        }

    }
}




