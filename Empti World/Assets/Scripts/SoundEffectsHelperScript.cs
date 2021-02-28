using UnityEngine;
using System.Collections;
using System;

public class SoundEffectsHelperScript : MonoBehaviour
{
    /// Singleton
    public static SoundEffectsHelperScript Instance;

    public AudioSource menuHoveredSound;
    public AudioSource menuSelectedSound;
    public AudioSource digSound;
    public AudioSource doorSound;
    public AudioSource lootSound;
    public AudioSource miningSound;
    public AudioSource playerHitSound;
    public AudioSource stormLoop;
    public AudioSource woodCutSound;
    public AudioSource walkingLoop;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of MenuSoundEffectsHelper!");
        }
        Instance = this;
    }

    public void playMenuHoveredSound()
    {
        MakeSound(menuHoveredSound);
    }

    public void playMenuSelectedSound()
    {
        MakeSound(menuSelectedSound);
    }

    public void playDigSound()
    {
        MakeSound(digSound);
    }

    public void playDoorSound()
    {
        MakeSound(doorSound);
    }

    public void playLootSound()
    {
        MakeSound(lootSound);
    }

    public void playMiningSound()
    {
        MakeSound(miningSound);
    }

    public void playPlayerHitSound()
    {
        MakeSound(playerHitSound);
    }
    public void playWoodCutSound()
    {
        MakeSound(woodCutSound);
    }

    private void MakeSound(AudioSource originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip.clip, transform.position);
    }

    internal void playWalkingLoop()
    {
        if(!walkingLoop.isPlaying)
            walkingLoop.Play();
        
    }

    internal void stopWalkingLoop()
    {
        walkingLoop.Stop();
    }

    internal void playStormLoop()
    {
        if (!stormLoop.isPlaying)
            stormLoop.Play();
    }

    internal void stopStormLoop()
    {
        stormLoop.Stop();
    }
}
