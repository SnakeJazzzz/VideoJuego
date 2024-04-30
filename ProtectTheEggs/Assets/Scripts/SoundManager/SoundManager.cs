using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField]
    private AudioSource musicSource; // To play music
    [SerializeField]
    private AudioSource sfxSource; // To play sound effects
      


    public List<AudioClip> musicClips; // List to store music clips
    public List<AudioClip> sfxClips; // List to store sound effect clips
    

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip musicClip, bool loop = true)
    {
        musicSource.clip = musicClip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFXByName(string name)
{
    var clip = sfxClips.FirstOrDefault(s => s.name == name);
    if (clip != null)
    {
        sfxSource.PlayOneShot(clip);
    }
}

}
