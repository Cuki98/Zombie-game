using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{
    private static Dictionary<float, SoundData> activeSounds = new Dictionary<float, SoundData>();
    private static GameObject globalSoundPlayer;
    public enum SoundCategory
    {
        music , sfx , voice
    }
    public class SoundSettings
    {
        public float volume;

        public SoundSettings(float volume)
        {
            this.volume = volume;
        }
    }

    public class SoundData
    {
        public AudioClip clip;
        public SoundSettings soundSettings;
        public SoundCategory soundCategory;

        public SoundData(AudioClip clip , SoundSettings soundSettings, SoundCategory soundCategory)
        {
            this.clip = clip;
            this.soundSettings = soundSettings;
            this.soundCategory = soundCategory;
        }
    }

    public static void ReproduceLocalSound(this GameObject gameObject ,AudioClip clip , SoundSettings soundSettings = null, SoundCategory soundCategory = SoundCategory.sfx )
    {
        AudioSource aSource = null;
        if (!activeSounds.ContainsKey(gameObject.GetInstanceID()))
        {
            aSource = gameObject.AddComponent<AudioSource>();
            activeSounds.Add(gameObject.GetInstanceID(), new SoundData(clip, soundSettings, soundCategory));
        }
        aSource = gameObject.GetComponent<AudioSource>();
        aSource.spatialBlend = 1;
        aSource.rolloffMode = AudioRolloffMode.Linear;

        aSource.clip = clip;

       if (soundSettings!= null)
        {
            aSource.volume = soundSettings.volume;
        }

        aSource.Play();
    }

    
    public static void ReproduceGlobalSound(this GameObject gameobject , AudioClip clip, SoundSettings soundSettings = null, SoundCategory soundCategory = SoundCategory.sfx)
    {
        AudioSource audio= null;
        if (globalSoundPlayer == null)
        {
            globalSoundPlayer = new GameObject("Global Sound Manager");
            audio = globalSoundPlayer.AddComponent<AudioSource>();
        }
        else
        {
            audio = globalSoundPlayer.GetComponent<AudioSource>();
        }

        audio.PlayOneShot(clip);
    }
}
