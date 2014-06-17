using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Spawner.cs
/// 
/// Script to control the spawner 
/// 
/// </summary>

public class Spawner : MonoBehaviour {
	
	bool enableSpawning;
	public enum Spawn {Enemy, PlayerShip, Powerup, Nothing};
	public Spawn spawnSelection;
	
	//public GameObject[] enemiesGO;
	//public GameObject[] powerupGO;
	//public GameObject playerShipGO;
	
	public Color gizmoColor;
	public float gizmoScale;
	
	private Assets assets;
	
	Spawn spawnType (Spawn spawning)
    {
        if(spawning == Spawn.Enemy){ 				enemy(); 	}
        else if(spawning == Spawn.PlayerShip){ 		ship(); 	}
		else if(spawning == Spawn.Powerup){ 		powerup(); 	}
		else{}
		
        return spawning;     
    }
	
	//connect components on start
	void Awake(){
		assets = transform.parent.GetComponent<Assets>();
	}
	
	// Use this for initialization
	void Start () {
		spawnType(spawnSelection);	//initialize controls
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//supposed to spew enemies from the array
	public void enemy(){
		
		spawn(2, assets.enemiesGO[0],"Enemy spawn initialized");
	}
	
	
	//supposed to spew ship player from the array
	public void ship(){
		
		spawn(5, assets.playerShipGO,"Player spawn initialized");
	}
	
	//supposed to spew the powerups from the array
	public void powerup(){
		
		spawn(5, assets.powerupGO[0],"Power Up spawn initialized");
	}
	
	//global spawn script
	public void spawn(float spawnOffset, GameObject spawnGO, string spawnMessage){
		print(spawnMessage);
		Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y - spawnOffset, transform.position.z);
		GameObject spawn0 = Instantiate(spawnGO, spawnPos, transform.rotation) as GameObject;
		spawn0.transform.parent = transform;
	}
	
	//Diplays the Spawner
	void OnDrawGizmos(){
		gizmoColor.a = 255;
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere(transform.position, gizmoScale);
	}
}
