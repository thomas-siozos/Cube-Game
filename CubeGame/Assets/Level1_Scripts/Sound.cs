using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;     //name of the sound

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;        //volume in range (0f, 1f)
    [Range(.1f, 3f)]
    public float pitch;     //pitch in range (.1f, 3f)

    [HideInInspector]
    public AudioSource source;      //Object
}
