using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public Sound[] sounds;

    // AudioManagerin her sahne yüklenmesinde tekrar tekrar çalışmaması için.
    public static AudioManager instance;

    private int index;

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

    private void Update()
    {
        if(playsNothing() == 1)
        {
            Play();
        }
       
    }
    private int playsNothing()
    {
        int check = 1;
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].source.isPlaying)
            {
                check = -1;
            }
 
        }
        return check;
    }
    void PlayNextSong()
    {
        Sound s = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        s.source.Play();

    }

    //isime göre ses oynatmak için.
    public void Play()
    {
        //Sound a = Array.Find(sounds, sound => sound.name == name);
        //Sound b = Array.Find(sounds, sound => sound.name == name2);
        //Sound c = Array.Find(sounds, sound => sound.name == name3);
        //if (a == null) //yanlış isim girme durunlarında hatalardan kaçınmak için.
        //{   
        //    Debug.LogWarning("Sound "+ name +" not found!");
        //    return;
        //}else if(b == null)
        //{
        //    Debug.LogWarning("Sound " + name2 + " not found!");
        //    return;
        //}
        //else if(c == null) {
        //    Debug.LogWarning("Sound " + name3 + " not found!");
        //    return;
        //}else if(!a.source.isPlaying && !b.source.isPlaying && !b.source.isPlaying)
        //{
        //    PlayNextSong();
        //}

        while (playsNothing() == 1)
        {
            PlayNextSong();

        }          
    }

}

//sounds[0].source.isPlaying == false && sounds[1].source.isPlaying == false && sounds[2].source.isPlaying == false