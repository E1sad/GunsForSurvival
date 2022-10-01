using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager Instance;


  [SerializeField] private AudioSource musicSource, soundSource;
  [SerializeField] private AudioClip BackgroundMusic;

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
    Debug.Log(volume);
    AudioListener.volume = volume;
  }

  public void ChangeMusicVolume(float volume)
  {
    Debug.Log(volume);
    musicSource.volume = volume;
  }

  public void ChangeSoundVolume(float volume)
  {
    soundSource.volume = volume;
  }
}
