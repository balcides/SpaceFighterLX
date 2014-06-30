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
	
    public int topScore = 0;       //overall top score
    public int levelScore = 0;     //current level score until mission complete then reset
    public int gameScore = 0;      //the overall score for the game after several levels

	public Vector2 boxStartLocation;
	public _GUIClasses center;
	public GUIStyle textGUIStyle;

	public float heightOffset = 50;
	public Vector2 titleOffset;
	public Vector2 namesOffset;
	public Vector2 roundsOffset;
	public Vector2 killsOffset;

	public Scores scores = new Scores();


	public Highscore[] score = new Highscore[10];


	void Awake(){

		center = GetComponent<_GUIClasses>();
		boxStartLocation = new Vector2(-300,-200);
		heightOffset = 32;

		titleOffset = new Vector2(-254, -215);
		namesOffset = new Vector2(-254, -137);
		roundsOffset = new Vector2(-51, -137);
		killsOffset = new Vector2(145, -137);

		for( int i = 0; i < 10; i++){ score[i] = new Highscore(); }

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

		score[0].rounds = 9;
		score[1].rounds = 5;
		score[2].rounds = 2;

		score[0].kills = 99999;
		score[1].kills = 999;
		score[2].kills = 10;

	}
	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		center.location.updateLocation();
	}


	void OnGUI() {

		// TITLE GUI
		GUI.Box(new Rect(center.location.offset.x + titleOffset.x, 
		                 center.location.offset.y + titleOffset.y, 120, 30),
		        "Name            Rounds         Kills", textGUIStyle);

		//SCORE - info gui text
		for( int i = 0; i < 9; i++){
			GUI.Box(new Rect(center.location.offset.x + namesOffset.x, 
			                 center.location.offset.y + namesOffset.y + i * heightOffset, 120, 30),
			        		 score[i].name, textGUIStyle);

			GUI.Box(new Rect(center.location.offset.x + roundsOffset.x, 
			                 center.location.offset.y + roundsOffset.y + i * heightOffset, 120, 30),
			        	     score[i].rounds.ToString(), textGUIStyle);

			GUI.Box(new Rect(center.location.offset.x + killsOffset.x, 
			                 center.location.offset.y + killsOffset.y + i * heightOffset, 120, 30),
			       			 score[i].kills.ToString(), textGUIStyle);
		}
	}

	public class Scores{
		public void initialize(){
			print("Score System initialized");
		}
	}


	[System.Serializable]
	public class Highscore{
		//public string name { get; set; }
		public string name;
		public int rounds;
		public int kills;

		//public Highscore(){}
	}
	
}
