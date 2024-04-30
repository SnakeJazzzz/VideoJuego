using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOver;
    public GameObject GOText;
    public string buttonClickSoundName;


    public void OnTowerDeath()
    {
        GOText.SetActive(true);
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
    }    
}
