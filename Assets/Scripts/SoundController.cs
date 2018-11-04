using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public Sound[] sounds;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        InstantiateSounds();
        PlayBgMusic();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    private void InstantiateSounds()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void PlayBgMusic()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "bg");
        s.source.Play();
    }
}
