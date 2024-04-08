using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    public RSCards npcList;
    
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            // Get the position of the click in screen coordinates
            Vector3 clickPosition = Input.mousePosition;
            
            // Convert the screen coordinates to world coordinates
            clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            clickPosition.z = 0;    
            // Instantiate the prefab at the click position
            /*
            GameObject newNPC = Instantiate(npcList.Items[0].prefab,clickPosition, transform.rotation);

            newNPC.GetComponent<NPCController>().setOwnership(0); 
            newNPC.SetActive(true);*/
            GameObject prefab = Resources.Load<GameObject>("Knight");
            GameObject newNPC = Instantiate(prefab ,clickPosition, transform.rotation);
            newNPC.SetActive(true);
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
