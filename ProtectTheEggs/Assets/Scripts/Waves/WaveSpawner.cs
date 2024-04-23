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
   public int BaseEnemyCount = 5; // The starting number of enemies per wave
    public int EnemyCountIncrement = 1; // How much to increase the enemy count per wave

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
        if(currentWave < waves.Waves.Count){
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

        }else{
            StartNewDynamicWave();
        }
    
        
    } 

    void Spawn(GameObject prefab, Vector3 position, CardStats stats)
    {
        
        GameObject newNPC = Instantiate(prefab,position, transform.rotation);

        newNPC.GetComponent<NPCController>().setOwnership(1, stats); 
        newNPC.SetActive(true);
            
        
    }




//Infinete wave sistem...

public void StartNewDynamicWave()
{
    // Check if we are beyond the predefined waves
    if (currentWave >= waves.Waves.Count)
    {
        // Generate a new wave dynamically
        List<EnemyInfo> newWaveInfo = GenerateDynamicWaveInfo(currentWave);
        
        // Call the coroutine with the dynamically generated wave info
        spawnWaveCoroutine = StartCoroutine(SpawnDynamicWave(newWaveInfo));
    }
    else
    {
        // Otherwise, continue with the predefined waves
        StartNewWave();
    }
}

private List<EnemyInfo> GenerateDynamicWaveInfo(int waveNumber)
{
    List<EnemyInfo> dynamicWaveInfo = new List<EnemyInfo>();

    // Simple example logic for dynamic wave generation

    // Increase the count of enemies as the wave number gets higher
    int enemyCount = BaseEnemyCount + (waveNumber * EnemyCountIncrement);

    // Here we could define the different types of enemies that could spawn
    string[] enemyTypes = new string[] { "Archer", "Goblin", "Troll", "Knight", "Mage", "Orc", "Ghost", "Assassin", "Berserker","Centaur","Elf","Giant","Scout","Stone Golem"};

    // Randomly decide how many different types of enemies will be in this wave
    int typesInThisWave = Random.Range(1, enemyTypes.Length);

    for (int i = 0; i < typesInThisWave; i++)
    {
        // Choose a random enemy type
        string chosenEnemy = enemyTypes[Random.Range(0, enemyTypes.Length)];

        // Create a new EnemyInfo
        EnemyInfo enemyInfo = new EnemyInfo();
        enemyInfo.fileName = chosenEnemy;
        enemyInfo.spawnPosition = GetRandomSpawnPosition();
        enemyInfo.spawnTime = GetSpawnDelay(i); // Stagger spawn times for each type
        enemyInfo.count = enemyCount / typesInThisWave; // Divide the enemy count evenly among the types

        dynamicWaveInfo.Add(enemyInfo);
    }

    return dynamicWaveInfo;
}
private Vector3 GetRandomSpawnPosition()
{
    // Set the x position to 45 for the first two maps
    float xPosition = 45f;

    // Randomly choose the y position between -4 and 4
    float yPosition = Random.Range(-4f, 4f);

    // Assuming that the z position is 0 or some other fixed value for these maps
    float zPosition = 0f;

    return new Vector3(xPosition, yPosition, zPosition);
}

private float GetSpawnDelay(int enemyTypeIndex)
{
    // Your logic to get spawn delay, for example:
    return enemyTypeIndex * 2f; // 2 seconds delay per enemy type index
}

private IEnumerator SpawnDynamicWave(List<EnemyInfo> dynamicWaveInfo)
{
    // Similar spawning logic to StartWave, but with dynamicWaveInfo instead of a predefined wave
    yield return new WaitForSeconds(3f);
    float timer = 0f;
    foreach (var spawnInfo in dynamicWaveInfo)
    {
        yield return new WaitForSeconds(spawnInfo.spawnTime - timer);
        timer += spawnInfo.spawnTime;
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
    WaveSpawnOver.Invoke();


}
}