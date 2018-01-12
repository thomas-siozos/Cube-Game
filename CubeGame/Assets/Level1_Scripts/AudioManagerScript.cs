using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds;      //Array with sounds

    void Awake()
    {
        foreach (Sound s in sounds)     //For each sound
        {
            s.source = gameObject.AddComponent<AudioSource>();      //Object type of AudioSource
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);      //Find sound with the same name
        s.source.Play();        //play sound
    }
}
