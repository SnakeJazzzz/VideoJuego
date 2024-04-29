using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMenuSceneButton : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string buttonClickSoundName;

    void Start()
    {
    SoundManager.Instance.PlayMusic(SoundManager.Instance.musicClips[2], true); 
    }


    
    public void CND()
    {
        sceneLoader.CreateNewDeck();
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
    }

    public void ED()
    {
        sceneLoader.EditDeck();
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
    }

    
    

}
