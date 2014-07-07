using UnityEngine;
using System.Collections;
using System;


/// <summary>
/// Score system.cs
/// 
/// This script is designed to handle all scoring on a global level for the player
/// 
/// </summary>

public class Score : MonoBehaviour {

	private Game game;

    public int topScore = 0;       //overall top score
    public int levelScore = 0;     //current level score until mission complete then reset
    public int gameScore = 0;      //the overall score for the game after several levels

	public Vector2 boxStartLocation;
	public _GUIClasses center;

	public GUIStyle titleGUIStyle;
	public GUIStyle namesGUIStyle;
	public GUIStyle killsGUIStyle;
	public GUIStyle roundsGUIStyle;

	public float heightOffset;
	public Vector2 titleOffset;
	public Vector2 namesOffset;
	public Vector2 roundsOffset;
	public Vector2 killsOffset;

	public int numOfScoresToDisplay;
	public string newName;

	public bool displayScores;
	
	public Scores scores = new Scores();
	public Scores[] score = new Scores[10];

	private int newHighscorePos;
	private Color pulseColor;
	
	void Awake(){

		center = GetComponent<_GUIClasses>();
		game = GetComponent<Game>();

		boxStartLocation = new Vector2(-300,-200);
		heightOffset = 45;

		titleOffset = new Vector2(-232, -238);
		namesOffset = new Vector2(-232, -150);
		roundsOffset = new Vector2(-52, -150);
		killsOffset = new Vector2(90, -150);

		numOfScoresToDisplay = 8;
		newName = "- type you name here -";
		newHighscorePos = numOfScoresToDisplay + 1;

		for( int i = 0; i < 10; i++){ score[i] = new Scores(); }

		score[0].name = "Donny";
		score[1].name = "Kelper";
		score[2].name = "Harper";
		score[3].name = "Don";
		score[4].name = "Cisco Kid";
		score[5].name = "Unitee";
		score[6].name = "Gebee";
		score[7].name = "Gilbert";
		score[8].name = "Hopper";
		score[9].name = "Wilfredo";

		score[0].rounds = 98;
		score[1].rounds = 5;
		score[2].rounds = 2;

		score[0].kills = 99999;
		score[1].kills = 999;
		score[2].kills = 10;

	}
	
	// Use this for initialization
	void Start () {

		//overwritePlayerPrefs(); //Reset player prefs
		syncPlayerPrefs();
		addNewHighscore();

	}
	
	// Update is called once per frame
	void Update () {

		center.location.updateLocation();
		pulseColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time * 1.2f,0.5f));
	}


	void OnGUI() {

		if (game.isGameMenu == true && displayScores) {
			if(newHighscorePos < numOfScoresToDisplay){

				// SET NEW PLAYER NAME WITH NEW SCORE POS
				GUI.SetNextControlName("nameTextField");							
				newName = GUI.TextField(new Rect(-10, -10, 1, 1), newName, 22);
				GUI.FocusControl("nameTextField");

				PlayerPrefs.SetString("highscore" + newHighscorePos + "name", newName); //ask player for name
				score[newHighscorePos].name = newName;
			}else{}

				// TITLE GUI
				GUI.Box (new Rect (center.location.offset.x + titleOffset.x, 
		         center.location.offset.y + titleOffset.y, 120, 30),
				"Name            Rounds         Kills", titleGUIStyle);

				//SCORE - info gui text
				for (int i = 0; i < numOfScoresToDisplay; i++) {

					if(i == 0){
						GUI.color = new Color(1,1,0,1);
					}else if( i == newHighscorePos){
						GUI.color = pulseColor;
					}else{
						GUI.color = new Color(1,0.5f,0,1);
					}

					GUI.Box (new Rect (center.location.offset.x + namesOffset.x, 
	            					   center.location.offset.y + namesOffset.y + i * heightOffset, 120, 30),
	    							   score [i].name, namesGUIStyle);

					GUI.Box (new Rect (center.location.offset.x + roundsOffset.x, 
							           center.location.offset.y + roundsOffset.y + i * heightOffset, 120, 30),
							   		   score [i].rounds.ToString (), killsGUIStyle);

					GUI.Box (new Rect (center.location.offset.x + killsOffset.x, 
						               center.location.offset.y + killsOffset.y + i * heightOffset, 120, 30),
						   			   score [i].kills.ToString (), roundsGUIStyle);
				}
		} else {}
	}

	//updates score info
	void addNewHighscore(){

		//check if the new score are above hold high scores
		int currentRounds = PlayerPrefs.GetInt("currentRounds");
		int currentKills = PlayerPrefs.GetInt("currentKills");

		//if so, calc what the number of highhore would be
		for (int i = 0; i < numOfScoresToDisplay; i++) {
			if(currentRounds > score[i].rounds){ 			
				newHighscorePos = i;		// new score is higher
				break;

			}else if(currentRounds == score[i].rounds && currentKills > score[i].kills){
				newHighscorePos = i;		// new score is higher
				break;
			}
			else{Debug.Log("score calc complete...newHighscorePos = " + newHighscorePos);}
		}

		if(newHighscorePos < numOfScoresToDisplay){
			for (int i = numOfScoresToDisplay - 1; i >= newHighscorePos; i--) {

				if(i == newHighscorePos){

					PlayerPrefs.SetString("highscore" + i + "name", score[i].name); //ask player for name
					score[i].name = score[i].name;
					PlayerPrefs.SetInt("highscore" + i + "rounds", currentRounds);
					score[i].rounds = currentRounds;
					PlayerPrefs.SetInt("highscore" + i + "kills", currentKills);
					score[i].kills = currentKills;

				}else{

					PlayerPrefs.SetString("highscore" + i + "name", score[i-1].name);
					score[i].name = score[i-1].name;
					PlayerPrefs.SetInt("highscore" + i + "rounds", score[i-1].rounds);
					score[i].rounds = score[i-1].rounds;
					PlayerPrefs.SetInt("highscore" + i + "kills", score[i-1].kills);
					score[i].kills = score[i-1].kills;

				}
			}
		}
	}

	//syncs player data for the score using unity's player prefs class
	void syncPlayerPrefs(){

		for (int i = 0; i <= numOfScoresToDisplay; i++) {

			//Set and get score -------------- NAME -----------------------
			if(PlayerPrefs.HasKey("highscore" + i + "name")){
				//copy to local highscore prefs
				score[i].name = PlayerPrefs.GetString("highscore" + i + "name");

			}else{
				//set player prefs to local data
				PlayerPrefs.SetString("highscore" + i + "name", score[i].name);
			}

			//Set and get score ----------------- ROUNDS ----------------------
			if(PlayerPrefs.HasKey("highscore" + i + "rounds")){
				//copy to local highscore prefs
				score[i].rounds = PlayerPrefs.GetInt("highscore" + i + "rounds");
				
			}else{
				//set player prefs to local data
				PlayerPrefs.SetInt("highscore" + i + "rounds", score[i].rounds);
			}

			//Set and get score -------------- KILLS -----------------------
			if(PlayerPrefs.HasKey("highscore" + i + "kills")){
				//copy to local highscore prefs
				score[i].kills = PlayerPrefs.GetInt("highscore" + i + "kills");
				
			}else{
				//set player prefs to local data
				PlayerPrefs.SetInt("highscore" + i + "kills", score[i].kills);
			}
		}
	}

	//resets player prefs (USE WITH CAUTION)
	void overwritePlayerPrefs(){
		
		for (int i = 0; i <= numOfScoresToDisplay; i++) {

				PlayerPrefs.SetString("highscore" + i + "name", score[i].name);
				PlayerPrefs.SetInt("highscore" + i + "rounds", score[i].rounds);
				PlayerPrefs.SetInt("highscore" + i + "kills", score[i].kills);
				PlayerPrefs.SetInt("currentRounds", 13);
			    PlayerPrefs.SetInt("currentKills", 1287);
			
		}
	}

	[System.Serializable]
	public class Scores{

		public string name;
		public int rounds;
		public int kills;

		public void initialize(){
			print("Score System initialized");
		}
	}
	
}
