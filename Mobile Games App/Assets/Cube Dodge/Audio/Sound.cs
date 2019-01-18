/// Sound.cs
/// Controls the sound variables with volume, pitch and loop

using UnityEngine.Audio;
using UnityEngine;

/// The following section is from Brackeys (2018) [Accessed 2018]
/// Available from <https://www.youtube.com/watch?v=6OT43pvUyfY&t=661s>

[System.Serializable]
public class Sound
{
    public string nameOf;   // Give the sound a name variable

    public AudioClip clip;   // Give the sound an AudioClip

    [Range(0f, 1f)]
    public float volume;   // Give the sound adjustable volume between 0 and 1

    [Range(.1f, 3f)]
    public float pitch;   // Give the sound adjustable pitch between 0.1 and 3

    public bool loop;   // Give the sound a boolean to control looping

    [HideInInspector]
    public AudioSource source;
}

/// End of Citation