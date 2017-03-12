using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public Transform target;
	//private Camera cam;
	// Use this for initialization
	void Start () {
		//cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); 
	}
}
