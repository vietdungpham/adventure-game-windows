using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public GameObject prefab;
    public AudioClip items, jump, doubleJump, background, gameOver;
    private AudioSource itemSrc, jumpSrc, doubleJumpSrc, backgroundSrc, gameOverSrc;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        /*items = Resources.Load<AudioClip>("earn_items");
        jump = Resources.Load<AudioClip>("jump1_effect");
        doubleJump = Resources.Load<AudioClip>("jump1_effect");
        background = Resources.Load<AudioClip>("background_1(tropical_mix)");*/
    }
    public void PlaySound(AudioClip clip, float volume, bool isLoopback)
    {
        if (clip == this.background)
        {
            Play(clip, ref backgroundSrc, volume, isLoopback);
        }
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        if (clip == this.items)
        {
            Play(clip, ref itemSrc, volume);
            return;
        }
        if (clip == this.jump)
        {
            Play(clip, ref jumpSrc, volume);
            return;
        }
        if (clip == this.doubleJump)
        {
            Play(clip, ref doubleJumpSrc, volume);
            return;
        }
        if (clip == this.gameOver)
        {
            Play(clip, ref gameOverSrc, volume);
            return;
        }
    }
    private void Play(AudioClip clip, ref AudioSource audioSrc, float volume, bool isLoopback=false)
    {
        if(audioSrc!=null&& audioSrc.isPlaying)
        {
            return;
        }
        audioSrc = Instantiate(instance.prefab).GetComponent<AudioSource>();
        audioSrc.volume = volume;
        audioSrc.loop = isLoopback;
        audioSrc.clip = clip;
        audioSrc.Play();
        Destroy(audioSrc.gameObject, audioSrc.clip.length);
    }
    public void StopSound(AudioClip clip)
    {
        if (clip == this.items)
        {
            itemSrc?.Stop();
            return;
        }
        if (clip == this.jump)
        {
            jumpSrc?.Stop();
            return;
        }
        if (clip == this.doubleJump)
        {
            doubleJumpSrc?.Stop();
            return;
        }
        if (clip == this.gameOver)
        {
            gameOverSrc?.Stop();
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
