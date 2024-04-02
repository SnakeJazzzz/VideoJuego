using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirGenerator : MonoBehaviour
{
    
    public Elixir elixir;
    public float timer = 5f;
    public int valueToAdd = 5;
    Coroutine generate;
    void Start()
    {
        generate = StartCoroutine(GenerateCoroutine());
    }


    IEnumerator GenerateCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);

            elixir.Add(valueToAdd);
        }

    }
}
