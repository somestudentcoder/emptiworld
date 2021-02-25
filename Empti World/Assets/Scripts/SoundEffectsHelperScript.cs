using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class SoundEffectsHelperScript : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    public static SoundEffectsHelperScript Instance;

    public AudioSource menuHoveredSound;
    public AudioSource menuSelectedSound;
    public AudioSource digSound;
    public AudioSource doorSound;
    public AudioSource lootSound;
    public AudioSource miningSound;
    public AudioSource playerHitSound;
    public AudioSource stormSound;
    public AudioSource woodCutSound;
    public AudioSource walkingLoop;

    void Awake()
    {
        // Register the singleton
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
    public void playStormSound()
    {
        MakeSound(stormSound);
    }
    public void playWoodCutSound()
    {
        MakeSound(woodCutSound);
    }

    /// <summary>
    /// Play a given sound
    /// </summary>
    /// <param name="originalClip"></param>
    private void MakeSound(AudioSource originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip.clip, transform.position);
    }

    internal void playWalkingLoop()
    {
        //if (!walkingLoop.isActiveAndEnabled)
        if(!walkingLoop.isPlaying)
            walkingLoop.Play();
        
    }

    internal void stopWalkingLoop()
    {
        walkingLoop.Stop();
    }
}
