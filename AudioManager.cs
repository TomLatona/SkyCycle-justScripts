using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //array of sounds

    void Awake(){ //on game start
        foreach (Sound s in sounds){ //creats AudioSources for each item in array
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //applies following attributes to each AudioSource component
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start(){
        Play("Music");
        Play("Engine");
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        s.source.Play();
    }

    public void Stop(string name){
        Sound ss = Array.Find(sounds, sound => sound.name == name);
        if(ss == null){
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        ss.source.Stop();
    }
}
