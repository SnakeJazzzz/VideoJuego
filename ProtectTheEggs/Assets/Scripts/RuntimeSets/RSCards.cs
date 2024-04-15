using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Runtime Set/Cards", fileName =
"Set")]

public class RSCards: RuntimeSet<Card>
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

    public string nombreMazo;
    public int ID;

    public void Reset()
    {
        nombreMazo = "";
        ID =0;
        Items.Clear();
    }
    public void Copy(RSCards rSCards)
    {
        nombreMazo = rSCards.nombreMazo;
        ID = rSCards.ID;
        Items.Clear();  

        foreach (var item in rSCards.Items)
        {
            Items.Add(item);  
        }
    }
}   
