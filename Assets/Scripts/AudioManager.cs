using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    public AudioClipTable audioClipTable;

    public AudioSource effectsSource;
    public AudioSource musicSource;

    private static AudioManager instance = null;

    private Dictionary<AudioClipId, AudioClip> audioClipDict;

    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            audioClipDict = AudioClipTable.Instance.GetDictionary();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetMusicEnable(bool enabled)
    {
        musicSource.mute = !enabled;
    }

    public void SetEffectEnable(bool enabled)
    {
        effectsSource.mute = !enabled;
    }

    public void StopMusic()
    {
        if (musicSource)
            musicSource.Stop();
    }

    public void StopEffect()
    {
        if (effectsSource)
            effectsSource.Stop();
    }

    public Tween CrossOut(float duration, bool stop = false)
    {
        return DOTween.To(() => musicSource.volume, (value) => musicSource.volume = value, 0f, duration).OnComplete(() => { if (stop) musicSource.Stop(); });
    }

    public Tween CrossIn(float duration)
    {
        return DOTween.To(() => musicSource.volume, (value) => musicSource.volume = value, 1f, duration);
    }

    public static void Play_SFX(AudioClipId key)
    {
        instance.PlaySFX(key);
    }

    public void PlaySFX(AudioClipId key)
    {
        if (audioClipDict.ContainsKey(key))
        {
            PlaySFX(effectsSource, audioClipDict[key]);
        }
    }

    public void PlayMusic(AudioClipId key, bool forceReplay = false)
    {
        if (audioClipDict.ContainsKey(key))
        {
            PlayMusic(musicSource, audioClipDict[key], forceReplay);
        }
    }

    public void PlaySFX(AudioSource audioSource)
    {        
        audioSource.Play();
    }

    public void PlaySFX(AudioSource audioSource, AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioSource audioSource, AudioClip clip, bool forceReplay)
    {
        audioSource.clip = clip;
        audioSource.loop = forceReplay;
        audioSource.Play();
    }
}
