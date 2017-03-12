using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log("Collision entered for coin");
		if(col.gameObject.layer == LayerMask.NameToLayer("Player")) {
			Destroy(gameObject);
		}
	}
}
