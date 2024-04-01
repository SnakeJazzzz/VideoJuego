using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "FloatVariable")]
public class Elixir : ScriptableObject
{
    public int elixirLevel;
    public int limit;

    public Action<int,int> UpdateUI;

    public void Add(int toAdd)
    {
        elixirLevel += toAdd;

        if (elixirLevel > limit)
        {
            elixirLevel = limit;
        }

        UpdateUI?.Invoke(elixirLevel, limit);
    }

    public void Remove(int toRemove)
    {
        elixirLevel -= toRemove;
    

        UpdateUI?.Invoke(elixirLevel, limit);
    }

    public void Set(int setValue)
    {
        elixirLevel = setValue;
       

        UpdateUI?.Invoke(elixirLevel, limit);
    }

    
}
