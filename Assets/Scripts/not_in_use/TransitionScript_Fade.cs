using UnityEngine;
using System.Collections;

public class TransitionScript_Fade : MonoBehaviour {
	public Texture screenTransTexture;
	public float fadeSpeed = 0.1f; // the fading speed

	private float alpha = 1.0f; // 1.0 stands for totally opaque
	private int fadeDir = -1; // the direction to fade: in = -1 , out = +1



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		// fade, in or out, using fadeDir, at fadeSpeed, depending on deltatime
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		// force (clamp) the number between 0 and 1 because GUI.color uses alpha between 0 and 1
		alpha = Mathf.Clamp01(alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), screenTransTexture);
	}
}
