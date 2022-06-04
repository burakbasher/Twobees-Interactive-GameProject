using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public Sound[] sounds;

    // AudioManagerin her sahne yüklenmesinde tekrar tekrar çalışmaması için.
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null){// sahnede audio manager yoksa,
            instance = this;
        }else { // sahnede auido manager varsa bu objeyi kaldırmak istiyoruz.
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)   
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        
        }
    }

    void Start ()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if (s == null) //yanlış isim girme durunlarında hatalardan kaçınmak için.
        {   
            Debug.LogWarning("Sound "+ name +" not found!");
            return;
        }
        s.source.Play();
    }
}

