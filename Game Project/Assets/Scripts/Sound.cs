using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;


    [HideInInspector] //Değişken public olsa bile, gözükmemesi için
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;
    
    [Range(.1f, 3f)]
    public float pitch; //gerek olmayabilir    

    public bool loop;
}
