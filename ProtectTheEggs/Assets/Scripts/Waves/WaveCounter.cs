using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    private Text waveText;
    /*
    void Start()
    {
        waveText = GetComponent<Text>();
        UpdateWaveCounter();
    }

    void UpdateWaveCounter()
    {
        //Debug.Log("Horda: " + (waveSpawner.currentWave + 1));
        waveText.text = (waveSpawner.currentWave + 1).ToString();
    }

    void OnEnable()
    {
        waveSpawner.WaveSpawnOver.AddListener(UpdateWaveCounter);
    }

    void OnDisable()
    {
        waveSpawner.WaveSpawnOver.RemoveListener(UpdateWaveCounter);
    }*/
}
