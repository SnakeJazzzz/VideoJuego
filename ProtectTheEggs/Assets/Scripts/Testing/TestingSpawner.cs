using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSpawner : MonoBehaviour
{
    public RSCards AvailableCards;
    
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            // Get the position of the click in screen coordinates
            Vector3 clickPosition = Input.mousePosition;
            
            // Convert the screen coordinates to world coordinates
            clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            clickPosition.z = 0;    

            Card card = AvailableCards.Items.Find(x => x.cardName == "Knight");

            Debug.Log("Prefabs/" + card.cardName);
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + card.cardName);
            if (prefab != null)
            {
                GameObject newNPC = Instantiate(prefab, clickPosition, transform.rotation);

                newNPC.GetComponent<NPCController>().setOwnership(0, card.stats); 
                newNPC.SetActive(true);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = Input.mousePosition;
            // Convert the screen coordinates to world coordinates
            clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            clickPosition.z = 0;    
            // Instantiate the prefab at the click position
            //GameObject newNPC = Instantiate(npcList.Items[0].prefab,clickPosition, transform.rotation);


            /*newNPC.GetComponent<NPCController>().setOwnership(1);
            newNPC.SetActive(true);*/
        }
    }
}
