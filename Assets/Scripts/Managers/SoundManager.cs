using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    //Singleton
    public static SoundManager Instance;
    
    [Header("Audio Clips")]
    public AudioClip mouseOverClip;
    public AudioClip clickClip;
    public AudioClip music;
    
     [Header("Audio Settings")]
     [SerializeField]private float sfxVolume = 0.5f;
     [SerializeField]private float musicVolume = 0.5f;
     [SerializeField]private AudioSource sfxSource;
     [SerializeField]private AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        
        musicSource.clip = music;
        musicSource.Play();
    }

    private void Update()
    {
        sfxSource.volume = sfxVolume;
        musicSource.volume = musicVolume;
    }

    public void PlayMouseOverSfx()
    {
        sfxSource.PlayOneShot(mouseOverClip);
    }
    
    public void PlayClickSfx()
    {
        PlaySfx(clickClip);
    }
    
    public void StopSfx()
    {
        sfxSource.Stop();
    }
    
    public void PlaySfx(AudioClip clip)
    {
        //Assign random pitch
        float randomPitch = Random.Range(0.8f, 1.1f);
        sfxSource.pitch = randomPitch;
        sfxSource.PlayOneShot(clip, sfxVolume);
    }
    
}
