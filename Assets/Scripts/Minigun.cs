using UnityEngine;
using System;

public class Minigun : Weapon
{
	public Minigun()
	{
		this.name_weapon = "Minigun";
		this.rateo_fire = 0.02f;
		this.is_spammable_fire = true;
		this.prefab_weapon = null; // Not available still
	}

	// sovrascrittura
	public override void fire(GameObject player, Vector3 weapon_position){
		// qua dice come sparare col minigun
	}
}
