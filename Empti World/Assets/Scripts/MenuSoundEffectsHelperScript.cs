using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class MenuSoundEffectsHelperScript : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    public static MenuSoundEffectsHelperScript Instance;

    public AudioClip menuHoveredSound;
    public AudioClip menuSelectedSound;

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

    /// <summary>
    /// Play a given sound
    /// </summary>
    /// <param name="originalClip"></param>
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
