using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioSource source;
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    public bool loop;
    public bool playOnAwake;

}
