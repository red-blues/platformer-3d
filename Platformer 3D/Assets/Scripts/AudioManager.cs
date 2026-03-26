using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource uiSfxAudioSource;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioSource levelSfxAudioSource;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayUISfx() =>
        uiSfxAudioSource.Play();

    public void PlayPlayerSfx(AudioClip clip)
    {
        playerAudioSource.clip = clip;
        playerAudioSource.Play();
    }
    
    public void PlayLevelSfx(AudioClip clip)
    {
        levelSfxAudioSource.clip = clip;
        levelSfxAudioSource.Play();
    }

    public void PlayEnemySound(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
