﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// SetPlayerPrefs.cs
/// 
/// saves, accesses, and modifies player data via playerPrefs in Unity
/// 
/// </summary>

public class SetPlayerPrefs : MonoBehaviour {

	public int totalRoundsWon;
	public int totalEnemyKills;


	public float buttonx;
	public float buttony;
	public float buttonWidth;
	public float buttonHeight;
	public string buttonLabel;

	void Awake(){

		buttonx = -78;
		buttony = -24;
		buttonWidth = 463;
		buttonHeight = 44;
		buttonLabel = "Activate Player Prefs";
	
	}


	// Use this for initialization
	void Start () {

		PlayerPrefs.SetString("Player Name", "Fulano");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button(new Rect(buttonx + _GUIClasses.instance.location.offset.x, 
		                        buttony + _GUIClasses.instance.location.offset.y, 
		                        buttonWidth, buttonHeight), buttonLabel)){
			PlayerPrefs.SetInt("highscore4rounds", totalRoundsWon);
			PlayerPrefs.SetInt("highscore4kills", totalEnemyKills);

			Debug.Log("highscore4rounds set int to : " + totalRoundsWon);
			Debug.Log("highscore4kills set int to : " + totalEnemyKills);
		}
	}
}
