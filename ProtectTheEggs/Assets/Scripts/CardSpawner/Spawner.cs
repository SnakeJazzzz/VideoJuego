using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    
    public RSNPCStats cartasEnMano;
    public int selected = -1;
    public UnityEvent GetNewCard;
    public UnityEvent OutOfCards;


    void Start()
    {
        GetNewCard.Invoke();
    }
    public void NewSelected(int newValue)
    {
        //Debug.Log("Received "+ newValue);
        selected = newValue - 1;
    }

    public void OnClick()
    {   
        if (selected == -1)
        {
            Debug.Log("No hay carta seleccionada.");
            return;
        }
        if (selected >= cartasEnMano.Items.Count)
        {
            Debug.Log("No hay carta en ese lugar.");
            return;
        }

        Vector3 clickPosition = Input.mousePosition;
        clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        clickPosition.z = 0;  

        Spawn(cartasEnMano.Items[selected].prefab, clickPosition);
        cartasEnMano.Items.RemoveAt(selected);
        selected = -1;
        GetNewCard.Invoke();
        if (cartasEnMano.Items.Count == 0)
        {
            OutOfCards.Invoke();
        }

    }

    
   void Spawn(GameObject toSpawn, Vector3 position)
    {
        GameObject newNPC = Instantiate(toSpawn,position, transform.rotation);

        newNPC.GetComponent<NPCController>().setOwnership(0); 
        newNPC.SetActive(true);
    }
}




