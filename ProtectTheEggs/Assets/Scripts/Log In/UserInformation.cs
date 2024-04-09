using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "UserInformation", fileName =
"Set")] 
public class UserInformation : ScriptableObject
{
    public string username;
    public bool loadedDeck = false;

    public void Reset()
    {
        username = null;
        loadedDeck = false;
    }
}
