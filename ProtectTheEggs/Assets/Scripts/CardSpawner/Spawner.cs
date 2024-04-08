using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    
    public RSCards cartasEnMano;
    public int selected = -1;
    public UnityEvent CardPlaced;
    public UnityEvent OutOfCards;


    void Start()
    {
        CardPlaced.Invoke();
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

        Spawn(cartasEnMano.Items[selected]);

        cartasEnMano.Items.RemoveAt(selected);
        selected = -1;
        CardPlaced.Invoke();

        if (cartasEnMano.Items.Count == 0)
        {
            OutOfCards.Invoke();
        }

    }

    
   void Spawn(Card card)
    {   
        Vector3 clickPosition = Input.mousePosition;
        clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        clickPosition.z = 0;  

        for(int i = 0; i < card.numberOfNPCs; i++)
        {
            /*
            GameObject newNPC = Instantiate(card.prefab ,clickPosition, transform.rotation);
            newNPC.GetComponent<NPCController>().setOwnership(0); 
            newNPC.SetActive(true);*/
        }

    }
}




