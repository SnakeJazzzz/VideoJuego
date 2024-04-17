using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSystem1 : MonoBehaviour
{
    public CardSOSystem cardSOSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //cardSOSystem.OnClick();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("1 selected.");
            cardSOSystem.NewSelected(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Debug.Log("2 selected.");
            cardSOSystem.NewSelected(2);        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Debug.Log("3 selected.");
            cardSOSystem.NewSelected(3);        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Debug.Log("4 selected.");
            cardSOSystem.NewSelected(4);        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Debug.Log("5 selected.");
            cardSOSystem.NewSelected(5);        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Debug.Log("6 selected.");
            cardSOSystem.NewSelected(6);        
        }
    }
}
