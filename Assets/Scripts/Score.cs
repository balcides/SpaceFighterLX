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

	public string[] highscoreName = new string[10];



	void Awake(){

		center = GetComponent<_GUIClasses>();

		highscoreName[0] = "Juan";
		highscoreName[1] = "Kelper";
		highscoreName[2] = "Harper";
		highscoreName[3] = "Don";
		highscoreName[4] = "Cisco Kid";
		highscoreName[5] = "Unitee";
		highscoreName[6] = "Gebee";
		highscoreName[7] = "Gilbert";
		highscoreName[8] = "Hopper";
		highscoreName[9] = "Wilfredo";

		boxStartLocation = new Vector2(-300,-200);
		heightOffset = 50;

	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		center.location.updateLocation();
	}
	
	public class Scores
	{
		public void initialize()
		{
			print("Score System initialized");
		}
		
	}
	
	public Scores scores = new Scores();
	

	void OnGUI() {

		for( int i = 0; i < 9; i++){
			GUI.Box(new Rect(center.location.offset.x + boxStartLocation.x, 
			                 center.location.offset.y + boxStartLocation.y + i * heightOffset, 120, 30),
			        		 highscoreName[i], textGUIStyle);
		}
	}
	
}
