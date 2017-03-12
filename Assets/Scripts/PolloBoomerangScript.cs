using UnityEngine;
using System.Collections;

public class PolloBoomerangScript : MonoBehaviour, IFire {
	float time_coming_back=0.5f;
	private GameObject so;
	private bool checkCollisionWithPlayer=false;
	private bool isComingBack=false;

	void Awake()
	{
		Destroy(gameObject, 6.0f);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D clone = this.GetComponent<Rigidbody2D>();
		if(ctime_reach_end != -1 && (Time.time - ctime_reach_end) > time_coming_back) {
			checkCollisionWithPlayer = true;
			clone.velocity = Vector2.zero;//new Vector2(-clone.velocity.x, so.transform.position.y - this.transform.position.y);//new Vector2(Mathf.Abs(this.transform.position.x - so.transform.position.x), so.transform.position.y - this.transform.position.y);//so.transform.position - this.transform.position;		//				so.transform.TransformDirection(Vector3.right * 10);
			ctime_reach_end = -1;
			isComingBack = true;
			IPlayerActions im = (IPlayerActions)so.GetComponent<PlayerController>();
			im.setIfCanMove(true);
		} else if(isComingBack) {
			//transform.position = Vector3.Lerp(transform.position, so.transform.position, 5.0f*Time.deltaTime);
			Vector3 direction = (so.transform.position - transform.position).normalized;
			clone.MovePosition(transform.position + direction * 10.0f * Time.deltaTime);
			//Debug.Log(clone.velocity);
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
		}else if(checkCollisionWithPlayer) {
			if(col.gameObject.layer == LayerMask.NameToLayer("Player")){
				//Destroy(col.gameObject);
				//add an explosion or something
				//destroy the projectile that just caused the trigger collision
				Destroy(gameObject);
			}
		}
	}


	float ctime_reach_end = -1;
	public void fire(GameObject so){
		this.so = so;
		IPlayerActions im = (IPlayerActions)so.GetComponent<PlayerController>();
		im.setIfCanMove(false);
		im.setIfCanFire(false);
		Rigidbody2D clone = this.GetComponent<Rigidbody2D>();
		clone.gravityScale = 0.0f;
		clone.velocity = so.transform.TransformDirection(Vector3.left * 10);
		Debug.Log(clone.velocity);
		ctime_reach_end = Time.time;
	}

	void OnDestroy(){
		IPlayerActions im = (IPlayerActions)so.GetComponent<PlayerController>();
		im.setIfCanFire(true);
	}

}
