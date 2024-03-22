using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTest : MonoBehaviour
{
   
    public RSNPCStats npcList;
    
    
   

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
            Instantiate(npcList.Items[0].prefab, clickPosition, transform.rotation);
            
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = Input.mousePosition;
            // Convert the screen coordinates to world coordinates
            clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            clickPosition.z = 0;    
            // Instantiate the prefab at the click position
            Instantiate(npcList.Items[1].prefab,clickPosition, transform.rotation);
        }
    }
}
