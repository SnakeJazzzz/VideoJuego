using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIGetter : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.musicClips[3], true);

    }

    
}
