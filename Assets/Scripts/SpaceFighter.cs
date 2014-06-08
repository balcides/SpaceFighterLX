using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// SpaceFighter.cs
/// 
/// This script is deisgned to run the menus and start on startup
/// This is meant to attach to a unity scene file named "runGame"
/// to start the game with and attach to a gameObject named "Global"
///
/// </summary>

[RequireComponent (typeof (Menu))]					//require Menu
[RequireComponent (typeof (Game))]					//require Game
[RequireComponent (typeof (Inputs))]				//require Input
[RequireComponent (typeof (Screensize))]			//require Screensize
[RequireComponent (typeof (Optimization))]			//require Optimization


public class SpaceFighter : MonoBehaviour {
	
	private	GameObject GlobalGO = null;
	
	private Menu menu;
	private Game game;
	private Inputs input;
	private Screensize screensize;
	private Optimization optimizations;
	
	// Use this to initialize any variables or game state before the game starts. 
	void Awake(){
		
		//check attached gameObjects
		GlobalGO = GameObject.Find("MasterGameController");						//check that this script is attached to a game object named "Global"
		
		menu = GetComponent<Menu>();					//initialize menu
		game = GetComponent<Game>(); 					//initialize game
		input = GetComponent<Inputs>();					//initialize input
		screensize = GetComponent<Screensize>();		//initialize screen
		optimizations = GetComponent<Optimization>();	//initialize optimization
		
	}
	
	// Use this for initialization
	void Start () {
			
			//checks if this is with the game object
			if(GlobalGO == null){ Debug.LogError("Make sure Menu.cs is attached to an empty gameObject named 'MasterGameController', or make one and assign"); }else{}
			
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
