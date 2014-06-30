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

	public Scores scores = new Scores();
	public Highscore[] score = new Highscore[10];


	void Awake(){

		center = GetComponent<_GUIClasses>();
		boxStartLocation = new Vector2(-300,-200);
		heightOffset = 50;

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

	}
	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		center.location.updateLocation();
	}


	void OnGUI() {

		for( int i = 0; i < 9; i++){
			GUI.Box(new Rect(center.location.offset.x + boxStartLocation.x, 
			                 center.location.offset.y + boxStartLocation.y + i * heightOffset, 120, 30),
			        		 score[i].name, textGUIStyle);
		}
	}

	public class Scores{
		public void initialize(){
			print("Score System initialized");
		}
	}

	public class Highscore{
		public string name { get; set; }
		//public string name;
		public int rounds;
		public int kills;

		public Highscore(){}
	}
	
}
