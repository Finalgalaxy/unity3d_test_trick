using UnityEngine;
using System.Collections;

public class TransitionScript : MonoBehaviour {
	public Texture screenTransTexture;
	public int delay_seconds;

	private bool GUIvisible;


	// Use this for initialization
	void Start () {
		GUIvisible = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUIvisible) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), screenTransTexture);
			this.StartCoroutine (KillGUI (delay_seconds));
		}
	}

	IEnumerator KillGUI(int delay){
		yield return new WaitForSeconds (delay_seconds);
		GUIvisible = false;
	}
}
