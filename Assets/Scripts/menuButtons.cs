using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// menuButtons.cs
/// 
/// This script is for handling the buttons for the menu
/// 
/// 
///
/// </summary>

public class menuButtons : MonoBehaviour {
	
	Camera cam;
	
	void Awake(){
		cam = Camera.main;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//handles all the button inputs for the game menu
	void OnMouseDown() {

		//Case swtich, case: name
		switch (transform.name)
		{
			case "Button-start":
				//Debug.Log("cube START working");
				//move camera to start menu section
				cam.animation.Play("camPanMenuStart");
				break;
			
			case "Button-scores":
				Debug.Log("cube SCORES working");
				Application.LoadLevel("HighScore");
				break;
			
			case "Button-options":
				Debug.Log("cube OPTIONS working");
				break;
			
			case "Button-beginner":
				Debug.Log("cube BEGINNER working");
				PlayerPrefs.Save();
				Debug.Log ("Saving player prefs....");
				Application.LoadLevel("Debug_level_test");
				break;
			
			case "Button-veteran":
				Debug.Log("cube VETERAN working");
				break;

			case "Button-dataDebug":
				Debug.Log("cube VETERAN working");
				Application.LoadLevel("Debug_DataPrefs");
				break;
			
			case "Button-mainmenu":

				if(!Game.use.isGameMenu || Score.use.displayScores){
					Debug.Log ("Saving player prefs....");
					PlayerPrefs.Save();
					Application.LoadLevel("RunGame"); 	
				}else{
					Debug.Log("cube MAINMENU working");
					if(cam.animation == null){} else{	cam.animation.Play("camPanMenuStartReturn");	}
				}
			break;

			case "Button-resetScore":
				Debug.Log("reset score working");
				Score.use.overwritePlayerPrefs();
				PlayerPrefs.Save();
				Debug.Log ("Saving player prefs....");
				if(Score.use.resetScore){ Score.use.resetScore = false;}
				else{ Score.use.resetScore = true;}
				break;
			
			default:
				Debug.Log("Your button is not being called properly by name in script. Check menuButton.cs for details");
				break;
		}
        		//Application.LoadLevel("SomeLevel");
   	}
	
	public bool safetyCheck(){
		
		print("initializing menu buttons");
		return true;
	}
}
