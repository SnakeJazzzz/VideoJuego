using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirSetter : MonoBehaviour
{
    public Elixir elixir;
    public int valueToSet = 10;
    void Start()
    {
        elixir.Set(valueToSet);
    }

    
}
