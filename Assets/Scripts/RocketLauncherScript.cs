using UnityEngine;
using System.Collections;

public class RocketLauncherScript : MonoBehaviour, IFire {
	//private GameObject so;

	void Awake()
	{
		Destroy(gameObject, 2.0f);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(ctime_reach_end != -1 && (Time.time - ctime_reach_end) > 2.0f) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("Triggered: "+col.gameObject.layer);
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if(col.gameObject.layer == LayerMask.NameToLayer("Ground")){
			Debug.Log("Collision with ground!!!");
			ctime_reach_end = 0;
		}if(col.gameObject.layer == LayerMask.NameToLayer("Monster")){
			Debug.Log("Collision with enemy!!!");
			Destroy(col.gameObject);
			ctime_reach_end = 0;
		}else if(col.gameObject.layer == LayerMask.NameToLayer("Player")){
			Destroy(gameObject);
		}
	}


	float ctime_reach_end = -1;
	public void fire(GameObject so){
		//this.so = so;
		IPlayerActions im = (IPlayerActions)so.GetComponent<PlayerController>();
		im.setIfCanFire(false);
		Rigidbody2D clone = this.GetComponent<Rigidbody2D>();
		clone.gravityScale = 0.0f;
		clone.velocity = so.transform.TransformDirection(Vector3.left * 30);
		Debug.Log(clone.velocity);
		ctime_reach_end = Time.time;
	}

}
