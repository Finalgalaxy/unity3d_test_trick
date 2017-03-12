using UnityEngine;
using System;

public class RocketLauncher : Weapon
{
	public RocketLauncher(GameObject prefab_weapon)
	{
		this.name_weapon = "RocketLauncher";
		this.rateo_fire = 0.05f;
		this.is_spammable_fire = true;
		this.prefab_weapon = prefab_weapon; // Not available still
	}

	// sovrascrittura
	public override void fire(GameObject player, Vector3 weapon_position){
		// qua dice come sparare col minigun
		GameObject go = MonoBehaviour.Instantiate(prefab_weapon, weapon_position, player.transform.rotation) as GameObject;
		go.transform.localScale = new Vector3(((player.transform.localScale.x<0)?1:-1)*go.transform.localScale.x, go.transform.localScale.y, go.transform.localScale.z);
		((IFire)go.GetComponent<RocketLauncherScript>()).fire(player);
	}
}
