using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOver;
    public GameObject GOText;
    public SessionAPIHandler sessionAPIHandler;

    public void OnTowerDeath()
    {
        GOText.SetActive(true);
        sessionAPIHandler.PopulateSessionData();

    }    
}
