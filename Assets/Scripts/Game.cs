using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Game.cs
/// 
/// This is designed to run the game (runtime scripts)
/// this is the base script for running the game and elements. 
/// The spawner should be attached and required to make this work
/// 
/// Author: Gabe Betancourt
/// 
/// </summary>

[RequireComponent (typeof (Transform))]			//require Transform
[RequireComponent (typeof (Menu))]	

public class Game : MonoBehaviour {
	
	private Spawner spawner;
	private WeaponSystem weaponSystem;
	private Menu menu;
	private Assets assets;
	
	public Transform spawnerGO;
	public bool isGameMenu;
	
	//requires components if the game is not a menu
	private void initilizeGame(){
		if(isGameMenu){
			menu = GetComponent<Menu>();
			menu.systemsCheck();
		}
		else{
			spawner = GetComponent<Spawner>();
			weaponSystem = GetComponent<WeaponSystem>();
			assets = GetComponent<Assets>();
			
			
			//require a gameobject called "spawner"
			GameObject findSpawnerGO = GameObject.Find("SpawnerGO");
			
			//checks if this is with the game object
			if(findSpawnerGO == null){ 
				//Debug.LogError("Make sure Spawner.cs is attached to an empty gameObject named 'Spawner', or make one and assign");
				Transform spawnerT = Instantiate(spawnerGO) as Transform; spawnerGO = spawnerT;}
			else{  }
		}
	}
	
	void Awake(){
			
			initilizeGame(); 
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	

}


