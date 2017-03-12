using UnityEngine;
using System.Collections;

public class Ghiacciolo : MonoBehaviour {
	public bool going_right = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Chiamata ad ogni frame per operazioni non-fisiche
	void Update () {
	
	}

	// Chiamata ad ogni frame dal motore fisico
	void FixedUpdate(){
		int x_direction = (going_right == true) ? 1 : -1;
		//MovePosition(transform.position + direction * 10.0f * Time.deltaTime);
		//gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(x_direction, 0, 0) * 2.0f * Time.deltaTime);
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x_direction*2.0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
}
