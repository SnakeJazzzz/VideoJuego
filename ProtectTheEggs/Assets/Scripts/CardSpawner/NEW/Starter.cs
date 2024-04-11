using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{

    public CardSOSystem cardSOSystem;
    
    void Awake()
    {
        //cardSOSystem.SetMazo();
    }
    void Start()
    {
        //Debug.Log("Start() Starter");
        //Invoke("RefillCards", 0.01f);
        cardSOSystem.RefillCards();
        //cardSOSystem.UIShow?.Invoke();
    }
    
    void RefillCards()
    {
        
        cardSOSystem.RefillCards();
    }

    void OnDisable()
    {
        cardSOSystem.cartasEnMano.Items.Clear();
    }
}
