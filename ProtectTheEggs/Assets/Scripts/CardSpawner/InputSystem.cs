using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{
    public UnityEvent OnClick;
    public UnityIntEvent NewSelected;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("1 selected.");
            NewSelected.Invoke(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Debug.Log("2 selected.");
            NewSelected.Invoke(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Debug.Log("3 selected.");
            NewSelected.Invoke(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Debug.Log("4 selected.");
            NewSelected.Invoke(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Debug.Log("5 selected.");
            NewSelected.Invoke(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Debug.Log("6 selected.");
            NewSelected.Invoke(6);
        }
        
    }
}
