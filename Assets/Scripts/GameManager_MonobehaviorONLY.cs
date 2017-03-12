using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager_MonobehaviorONLY : MonoBehaviour {
	/*private static class GMLoader {
		public static readonly GameManager instance = new GameManager();
	}
	public static GameManager getInstance() {
		return GMLoader.instance;
	}*/

	public AudioClip MusicSound,ClickSound;
	public Texture background,blackbg;

	private Settings m_Settings = new Settings ();
	private bool IsShownMainMenu;
	private AudioSource m_MusicSource, m_SoundSource;

	public void setMusic(AudioClip ac){
		m_MusicSource.clip = ac;
		m_MusicSource.Play();
	}

	private enum SceneList : byte{
		Loading = 0,
		Menu = 1,
		Level1 = 2
	}
	private SceneList active_scene;

	public enum MenuTypes : byte{
		MainMenu = 0,
		OptionsMenu = 1,
		PauseMenu = 2,
		GameOverMenu = 3
	}

	public readonly string[] MenuNames = new string[]{
		"Main Menu",
		"Options Menu",
		"Pause Menu",
		"Game Over Menu"
	};

	public MenuTypes ActiveMenu { get; set; }

	public readonly GUI.WindowFunction[] MenuFunctions = null;

	public bool IsMenuActive { get; set; }

	public GameManager_MonobehaviorONLY(){
		MenuFunctions = new GUI.WindowFunction[] {
			MainMenu,
			OptionsMenu,
			PauseMenu,
			GameOverMenu
		};
	}
		
	private void MainMenu (int id)
	{
		GUILayout.Label ("Test");
		if (GUILayout.Button ("Start Game")) {
			this.active_scene = SceneList.Loading;
			Debug.Log ("Start game calling...");

			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackbg);
			SceneManager.LoadScene ("SceneLevel1");
			this.active_scene = SceneList.Level1;

			Debug.Log ("Start game called!");
		}

		if (GUILayout.Button ("Options")) {
			m_SoundSource.PlayOneShot (ClickSound);
			ActiveMenu = MenuTypes.OptionsMenu;
			// Code for options
		}

		if (!Application.isWebPlayer && !Application.isEditor) {
			if (GUILayout.Button ("Exit")) {
				Application.Quit ();
			}
		}
	}

	private void OptionsMenu (int id)
	{
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Music volume");
		m_Settings.MusicVolume = GUILayout.HorizontalSlider (m_Settings.MusicVolume, 0.0f, 1.0f);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Sound volume");
		m_Settings.SoundVolume = GUILayout.HorizontalSlider (m_Settings.SoundVolume, 0.0f, 1.0f);
		GUILayout.EndHorizontal ();


		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Reset high score")) {
			m_Settings.HighScore = 0; // Reset to 0
		}
		GUILayout.EndHorizontal ();

		if (GUILayout.Button ("Back")) {
			m_Settings.Save (); // Save settings
			m_SoundSource.PlayOneShot (ClickSound); // *click* sound
			ActiveMenu = MenuTypes.MainMenu; // "Back" button returns from this menu to MainMenu
		}


	}

	private void PauseMenu (int id){}
	private void GameOverMenu (int id){}

	void Awake(){
		Debug.Log("GameManager creato");
		Application.runInBackground = true;
		DontDestroyOnLoad (gameObject);

		active_scene = SceneList.Menu;
		ActiveMenu = MenuTypes.MainMenu;

		m_MusicSource = transform.FindChild ("Music").GetComponent<AudioSource> ();
		m_SoundSource = transform.FindChild ("Sound").GetComponent<AudioSource> ();

		m_Settings.Load (m_MusicSource, m_SoundSource);

		m_MusicSource.clip = MusicSound;
		m_MusicSource.Play ();
		Debug.Log("GameManager creato");
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	const int Width=300;
	const int Height=100;
	void OnGUI(){
		if(active_scene == SceneList.Menu) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
			string str_highscore = "Highscore: " + m_Settings.HighScore;
			Vector2 highscoreTextDim = getPreferredLabelSize(str_highscore);
			GUI.Label(new Rect(Screen.width - highscoreTextDim.x, 0, highscoreTextDim.x, 100), str_highscore);

			Rect windowRect = new Rect(
				                  ((Screen.width - Width) / 2),
				                  ((Screen.height - Height) / 2),
				                  Width,
				                  Height
			                  );
			GUILayout.Window(0, windowRect, MenuFunctions[(byte)ActiveMenu], MenuNames[(byte)ActiveMenu]);
			//GUI.Label (new Rect (0, 0, 100, 100), "It's working! Lol");
		} else if(active_scene == SceneList.Loading) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackbg);
		}
	}

	private Vector2 getPreferredLabelSize(string str){
		return GUI.skin.label.CalcSize (new GUIContent (str));
	}

}
