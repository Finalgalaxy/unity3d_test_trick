using UnityEngine;
using System.Collections;

public class Settings {
	private AudioSource m_MusicSource;
	private AudioSource m_SoundSource;

	public float MusicVolume{
		get{ return m_MusicSource.volume; }
		set{ m_MusicSource.volume = value; }
	}

	public float SoundVolume{
		get{ return m_SoundSource.volume; }
		set{ m_SoundSource.volume = value; }
	}

	public int HighScore{get; set;}

	public void Load(AudioSource music, AudioSource sound){
		m_MusicSource = music;
		m_SoundSource = sound;

		MusicVolume = PlayerPrefs.GetFloat ("MusicVolume", 0.5f);
		SoundVolume = PlayerPrefs.GetFloat ("SoundVolume", 1.0f);
		HighScore = PlayerPrefs.GetInt ("HighScore", 0);
	}

	public void Save(){
		PlayerPrefs.SetFloat ("MusicVolume", MusicVolume);
		PlayerPrefs.SetFloat ("SoundVolume", SoundVolume);
		PlayerPrefs.SetInt ("HighScore", HighScore);
	}
}
