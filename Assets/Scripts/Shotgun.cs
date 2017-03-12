using UnityEngine;
using System;

public class Shotgun : Weapon
{
	private int apertura_ad_ombrello;
	// altre variabili...

	public Shotgun()
	{
		this.name_weapon = "Shotgun";
		this.rateo_fire = 3.0f;
		this.is_spammable_fire = false;
		this.prefab_weapon = null; // Not available still
	}

	// sovrascrittura
	public override void fire(GameObject player, Vector3 weapon_position){
		// qua dice come sparare con lo shotgun
	}
}
