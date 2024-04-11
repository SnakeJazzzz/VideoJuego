using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMenuSceneButton : MonoBehaviour
{
    public SceneLoader sceneLoader;
    
    public void CND()
    {
        sceneLoader.CreateNewDeck();
    }
}
