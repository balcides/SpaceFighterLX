using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Weapon system.cs
/// 
/// System designed to release and control weapons for any unit this is attached to
/// 
/// </summary>

[RequireComponent (typeof (Rigidbody))]	

public class WeaponSystem : MonoBehaviour {
	
	public enum weaponType {Bullets, Bomb, Missle};
	public weaponType WeaponType;
	
	public Rigidbody[] ammo;
	public float bulletFiringDelay;
	
	public float bulletXoffset;
	public float bulletYoffset;
	public float bulletZoffset;
	
	private float bulletTimer;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		shootWeapon();
	}
	
	//instantite weapon every num of seconds
	void launchWeapon(){
		
		Vector3 bulletPos = new Vector3(transform.position.x + bulletXoffset, transform.position.y + bulletYoffset, transform.position.z + bulletZoffset);
		
		//look at what weapon is chosen in enum
		switch (WeaponType){
			case weaponType.Bullets:
				Instantiate(ammo[0], bulletPos, transform.rotation);
				break;
			case weaponType.Bomb:
				Instantiate(ammo[1], bulletPos, transform.rotation);
				break;
			case weaponType.Missle:
				Instantiate(ammo[2], bulletPos, transform.rotation);
				break;
			default:
				print("no weapons being launched");
				break;
		}
		
	}
	
	//shoots the weapons every so often
    void shootWeapon() {
		
		bulletTimer += 1;
		if(bulletTimer >= bulletFiringDelay){
			bulletTimer = 0;
			launchWeapon();
		}
		
    }
}



