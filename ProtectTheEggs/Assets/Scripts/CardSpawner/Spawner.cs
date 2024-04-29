using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public RSCards cartasEnMano;
    public CardSOSystem cardSOSystem;

    void OnEnable()
    {
        cardSOSystem.Spawn += Spawn;
    }

    void OnDisable()
    {
       cardSOSystem.Spawn -= Spawn; 
    }

   void Spawn(int index)
    {   
        Debug.Log("Spawning NPC!");
        Card card = cartasEnMano.Items[index];
        Vector3 clickPosition = Input.mousePosition;
        clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        clickPosition.z = 0;  

        for(int i = 0; i < card.numberOfNPCs; i++)
        {
            Debug.Log("Prefabs/" + card.cardName);
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + card.cardName);
            if (prefab != null)
            {
                GameObject newNPC = Instantiate(prefab, clickPosition, transform.rotation);

                newNPC.GetComponent<NPCController>().setOwnership(0, card.stats); 
                newNPC.SetActive(true);

                PlayRandomSpawnSound();
            }
        }
    }

    private void PlayRandomSpawnSound()
    {
        if (SoundManager.Instance.sfxClips.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, SoundManager.Instance.sfxClips.Count);
            AudioClip randomClip = SoundManager.Instance.sfxClips[index];
            SoundManager.Instance.PlaySFX(randomClip);
        }
    }
}




