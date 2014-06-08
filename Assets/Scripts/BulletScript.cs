using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Bullet script.cs
/// 
/// controls the speed of the bullet and direction
/// 
/// </summary>



public class BulletScript : MonoBehaviour {
	
	public float speed;
	public float damage;
	public float lifespan;
	public Transform explostionFX;
	
	private float bulletTimer = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.down * Time.deltaTime * speed);
		bulletLifeSpan();
	}
	
	//Controls how long a bullet lasts before self-destruction
	void bulletLifeSpan(){
		
		bulletTimer += 1;
		if(bulletTimer >= lifespan){
			bulletTimer = 0;
			Transform FX = (Transform)Instantiate(explostionFX, transform.position, transform.rotation);
			Destroy(FX.gameObject, FX.particleSystem.duration);
			Destroy(gameObject);
		}
	}
}
