using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
	public static bool isMuted;
	
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
			s.source.mute = isMuted;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }

    public void AdjustVolume(string name, float volPerFrame)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume += volPerFrame;
    }

    public void Mute()
    {
        foreach(Sound s in sounds)
        {
            s.source.mute = true;
        }
		isMuted = true;
    }

    public void UnMute()
    {
        foreach (Sound s in sounds)
        {
            s.source.mute = false;
        }
		isMuted = false;
    }
}
