using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Runtime Set/RSCards", fileName =
"Set")]

public class RSRSCards: RuntimeSet<RSCards>
{

   public void Reset()
   {
    for (int i = 0; i<Items.Count; i++)
    {
        Items[i].Items.Clear();
    }
   }
}   
    

