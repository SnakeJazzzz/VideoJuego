using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    Coroutine spawnWaveCoroutine;
    public WaveList waves;
    public UnityEvent WaveSpawnOver;
    public int currentWave = 0;
   //pdate is called once per frame
    void Start()
    {
        spawnWaveCoroutine = StartCoroutine(StartWave());
    }

    public void StartNewWave()
    {
        spawnWaveCoroutine = StartCoroutine(StartWave());
    }

    public IEnumerator StartWave()
    {
        yield return new WaitForSeconds(3f);
        float timer = 0f;
       
        foreach (var spawnInfo in waves.Waves[currentWave].WaveInformation)
        {
            yield return new WaitForSeconds(spawnInfo.spawnTime - timer);
            timer += spawnInfo.spawnTime;
            for (int i = 0; i < spawnInfo.count; i++)
            {
                Spawn(spawnInfo.prefab, spawnInfo.spawnPosition);
            }
        }
        currentWave++;
        //Debug.Log("Wave Spawning is done");
        WaveSpawnOver.Invoke();
    } 

    void Spawn(GameObject toSpawn, Vector3 position)
    {
        GameObject newNPC = Instantiate(toSpawn,position, transform.rotation);

        //newNPC.GetComponent<NPCController>().setOwnership(1, card); 
        //newNPC.SetActive(true);
    }
}
