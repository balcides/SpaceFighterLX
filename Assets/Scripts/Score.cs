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

	void Awake(){

		center = GetComponent<_GUIClasses>();

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
		GUI.Box(new Rect(center.location.offset.x + boxStartLocation.x, center.location.offset.y + boxStartLocation.y, 120, 30), "This is a title");
	}
	
}
