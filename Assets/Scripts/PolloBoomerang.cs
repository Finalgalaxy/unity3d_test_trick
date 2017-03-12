using UnityEngine;
using System;

public class PolloBoomerang : Weapon
{
	public PolloBoomerang(GameObject prefab_weapon)
	{
		this.name_weapon = "PolloBoomerang";
		this.rateo_fire = 6f;
		this.is_spammable_fire = false;
		this.prefab_weapon = prefab_weapon; // Not available still
	}

	// sovrascrittura
	public override void fire(GameObject player, Vector3 weapon_position){
		// qua dice come sparare col minigun
		GameObject go = MonoBehaviour.Instantiate(prefab_weapon, weapon_position, player.transform.rotation) as GameObject;
		((IFire)go.GetComponent<PolloBoomerangScript>()).fire(player);
	}
}
