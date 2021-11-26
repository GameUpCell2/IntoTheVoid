using System;
using UnityEngine;
using UnityEngine.Audio;

public class MyAudioManager : MonoBehaviour
{
    public static MyAudioManager Instance;

	public MySoundController[] sounds;

	void Start ()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		} else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (MySoundController s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void Play (string sound)
	{		
		if(GameManager.Instance.IsMute)
			return;
		Debug.Log("Playing " + sound);			
		MySoundController s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}

}

// }