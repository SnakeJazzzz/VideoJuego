using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WaveOverChecker : MonoBehaviour
{
    public NPCManager npcManager;
    public UnityEvent WaveIsOver;
    public WaveCounter waveCounter;
    public string buttonClickSoundName;
    Coroutine checkCoroutine;
    public void WaveOver()
    {
        checkCoroutine = StartCoroutine(CheckIfWaveOver());
        
    }

    IEnumerator CheckIfWaveOver()
    {
        while (!(npcManager.Entities[1][0].Count == 0 && npcManager.Entities[1][1].Count== 0))
        {
            yield return new WaitForSeconds(0.5f);
            //Debug.Log("Still "+ npcManager.Entities[1][0].Count+ " enemies remaining");
        }
        //Debug.Log("WAVE IS OVER");
        WaveIsOver.Invoke();
        SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
    }



    private void Awake()
{
    // Subscribe the OnWaveCompleted method to the WaveIsOver event
    WaveIsOver.AddListener(waveCounter.OnWaveCompleted);
}

private void OnDestroy()
{
    // Unsubscribe when the object is destroyed
    WaveIsOver.RemoveListener(waveCounter.OnWaveCompleted);
}
}