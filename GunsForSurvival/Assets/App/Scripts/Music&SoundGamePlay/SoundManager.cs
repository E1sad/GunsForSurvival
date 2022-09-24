using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager Instance;


  [SerializeField] private AudioSource musicSource, soundSource;
  [SerializeField] private AudioClip BackgroundMusic, TakeSFX, GiveSFX;

  private void Awake()
  {
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

  private void Start()
  {
    musicSource.clip = BackgroundMusic;
    musicSource.Play();
  }

  public void PlaySound(AudioClip clip)
  {
    soundSource.PlayOneShot(clip); 
  }

  public void ChangeMasterVolume(float volume)
  {
    AudioListener.volume = volume;
  }
}
