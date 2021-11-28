using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticHandler : MonoBehaviour
{
    public static StaticHandler i;

    public void StaticDestroy(GameObject obj , float time = 0)
    {
        Destroy(obj,time);
    }

	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

	


	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (i == null)
		{
			i = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (i != this)
		{
			StaticDestroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}

	// Play a single clip through the sound effects source.
	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	public void PlayOneShot(AudioClip clip)
	{

		EffectsSource.PlayOneShot(clip);
	}

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

	// Play a random clip from an array, and randomize the pitch slightly.
	public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

		EffectsSource.pitch = randomPitch;
		EffectsSource.clip = clips[randomIndex];
		EffectsSource.Play();
	}

}
