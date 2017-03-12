using UnityEngine;
using System;

public abstract class Weapon
{
	public String name_weapon;
	public float rateo_fire;
	public bool is_spammable_fire = false;
	public GameObject prefab_weapon;

	public virtual void fire(GameObject player, Vector3 weapon_position){
		// To override
	}
}


