using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    Coroutine spawnWaveCoroutine;
    public WaveList waves;
    public RSCards AvailableCards;
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

            Debug.Log("Prefabs/" + spawnInfo.fileName);
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + spawnInfo.fileName);
            
            Card card = AvailableCards.Items.Find(x => x.cardName == spawnInfo.fileName);

            for (int i = 0; i < spawnInfo.count; i++)
            {
                if (prefab != null)
                {
                    Spawn(prefab, spawnInfo.spawnPosition, card.stats);
                }
            }
        }
        currentWave++;
        //Debug.Log("Wave Spawning is done");
        WaveSpawnOver.Invoke();
    } 

    void Spawn(GameObject prefab, Vector3 position, CardStats stats)
    {
        
        GameObject newNPC = Instantiate(prefab,position, transform.rotation);

        newNPC.GetComponent<NPCController>().setOwnership(1, stats); 
        newNPC.SetActive(true);
            
        
    }
}