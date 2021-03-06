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
	private PlayerShip playerShip;
	private Score score;
	private GameObject playerAsset;
	
	public Transform spawnerGO;
	public bool isGameMenu;
	
	public TextMesh livesText;
	public TextMesh scoreText;

	//private livesText LivesText;

	//requires components if the game is not a menu
	private void initilizeGame(){
		if(isGameMenu){
			menu = GetComponent<Menu>();
			menu.systemsCheck();

			livesText.renderer.enabled = false;
			livesText.gameObject.SetActive(false);
			livesText.gameObject.renderer.enabled = false;
			livesText.GetComponent<MeshRenderer>().enabled = false;

			score = GetComponent<Score>();


		}
		else{
			spawner = GetComponent<Spawner>();
			weaponSystem = GetComponent<WeaponSystem>();
			assets = GetComponent<Assets>();
			score = GetComponent<Score>();
			

			
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
		
		if(isGameMenu){}
		else{ updatePlayerLives(); }

	}
	
	//updates player lives on update if the tag is found
	void updatePlayerLives()
	{
		playerAsset = GameObject.FindWithTag("Player");
		
		
		if(!playerAsset){ playerShip = null;}
		else{ 
			playerShip = playerAsset.GetComponent<PlayerShip>();	
			livesText.text = "Lives " + playerShip.playerLives.ToString("00"); 
			scoreText.text = "Score" + score.levelScore.ToString("00000");
		}
	}
	

}


