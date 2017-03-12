using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManagerKeeper : MonoBehaviour {
	private GameManager GM;

	public AudioClip MusicSound,ClickSound;
	public Texture background,blackbg;

	void Awake(){
		DontDestroyOnLoad (gameObject);

		GM = GameManager.getInstance();
		GM.MusicSound = this.MusicSound;
		GM.ClickSound = this.ClickSound;
		GM.background = this.background;
		GM.blackbg = this.blackbg;

		GM.m_MusicSource = transform.FindChild ("Music").GetComponent<AudioSource> ();
		GM.m_SoundSource = transform.FindChild ("Sound").GetComponent<AudioSource> ();


		GM.m_Settings.Load (GM.m_MusicSource, GM.m_SoundSource);

		GM.m_MusicSource.clip = GM.MusicSound;
		GM.m_MusicSource.Play ();



		GM.active_scene = SceneList.Menu;
		GM.ActiveMenu = MenuTypes.MainMenu;
	}

	void OnGUI(){
		GM.OnGUI();
	}

}
