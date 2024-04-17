using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UserInformation", fileName =
"Set")] 
public class UserInformation : ScriptableObject
{
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public string username;
    public bool loadedDeck = false;
    public int selectedDeck = -1;

    public void Reset()
    {
        //Debug.Log("UserInfo Reset!");
        username = null;
        loadedDeck = false;
        selectedDeck = -1;
    }
}
