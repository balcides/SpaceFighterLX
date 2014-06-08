using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Menu.cs
/// 
/// This script is deisgned to run the menus and start on startup
/// This is meant to attach to a unity scene file named "runGame"
/// to start the game with and attach to a gameObject named "Global"
///
/// </summary>

[RequireComponent (typeof (LevelSelect))]			//require the level select script to load with this
[RequireComponent (typeof (Score))]					//require score system

public class Menu : MonoBehaviour {
	
	private LevelSelect levelSelect; 											//loading level select class
	private Score scoree; 														//loading level select class
	private menuButtons MenuButtons;
	
	private	GameObject startButton = null;
	private	GameObject scoreButton = null;
	private	GameObject optionsButton = null;
	

	// Use this to initialize any variables or game state before the game starts. 
	void Awake(){
		
		levelSelect = GetComponent<LevelSelect>(); 								//initializing scripts (make sure it's attached)
		scoree = GetComponent<Score>(); 										//initializing scripts (make sure it's attached)
		
	}

	// Use this for initialization
	void Start () {
		
		levelSelect.gameOver();													//Here Im calling gameOver
		levelSelect.missionComplete();											//Here Im calling MissionComplete as part af a class test
		print("level rounds initiated = " + levelSelect.levels.rounds); 		//level rounds initialized	
		print("level bouns  initiated = " + levelSelect.levels.bonus);			//bonus rounds added
		
		scoree.scores.initialize();												//initializes score system
		print("game score initiated = " + scoree.gameScore);				
        print("level score initiated = " + scoree.levelScore);
        print("top score initiated = " + scoree.topScore);


	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	// Scripts the Start menu and anything that has to get going when the game starts
	void startMenu(){
	}
	
	
	//checks to make sure everything works - (runs from Game)
	public void systemsCheck(){
		
		//check for gameObjects buttons
		optionsButton = GameObject.Find("Button-options");
		startButton = GameObject.Find("Button-start");
		scoreButton = GameObject.Find("Button-scores");
		
		if(startButton == null || optionsButton == null || scoreButton == null){
			Debug.LogError("One or more of the button objects are missing or dont have thier proper scripts assigned (gabeNote)");
		}
		
		//check the connection of the menu buttons
		//check if the buttons exist and if the script is attached.
		MenuButtons = optionsButton.GetComponent<menuButtons>();
		if(MenuButtons.safetyCheck()){ }else{ Debug.LogError("optionsButton missing scripts"); }
		MenuButtons = startButton.GetComponent<menuButtons>();
		if(MenuButtons.safetyCheck()){ }else{ Debug.LogError("startButton missing scripts"); }
		MenuButtons = scoreButton.GetComponent<menuButtons>();
		if(MenuButtons.safetyCheck()){ }else{ Debug.LogError("scoreButton missing scripts"); }
	}

}


