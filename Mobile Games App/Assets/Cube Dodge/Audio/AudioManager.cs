/// AudioManager.cs
/// Manages all the audio, controlling the volume, pitch and loop

using UnityEngine.Audio;
using UnityEngine;
using System;

/// The following section is from Brackeys (2018) [Accessed 2018]
/// Available from <https://www.youtube.com/watch?v=6OT43pvUyfY&t=661s>

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;   // Initialise an array of Sound called sounds 

	void Awake()
    {
		foreach ( Sound s in sounds )   // Loop through each Sound in the sounds array
        {
            s.source = gameObject.AddComponent<AudioSource>();   // Add an audio source component

            s.source.clip = s.clip;   // Set the clip

            s.source.volume = s.volume;   // Set the volume

            s.source.pitch = s.pitch;   // Set the pitch

            s.source.loop = s.loop;   // Set if it will loop
        }
	}

    void Start()
    {
        Play( "MainTheme" );   // When the scene loads, play the main theme song
    }

    public void Play( string name )
    {
       Sound s = Array.Find( sounds, sound => sound.nameOf == name );   // Find the correct sound to play
       
       s.source.Play();   // Call the Play function to play sound
    }
}

/// End of Citation