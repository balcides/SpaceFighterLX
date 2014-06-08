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
				break;
			
			case "Button-options":
				Debug.Log("cube OPTIONS working");
				break;
			
			case "Button-beginner":
				Debug.Log("cube BEGINNER working");
				break;
			
			case "Button-veteran":
				Debug.Log("cube VETERAN working");
				break;
			
			case "Button-mainmenu":
				Debug.Log("cube MAINMENU working");
			    cam.animation.Play("camPanMenuStartReturn");
				break;
			
			default:
				Debug.Log("something button related is not working. Check StartClick.cs for details");
				break;
		}
        		//Application.LoadLevel("SomeLevel");
   	}
	
	public bool safetyCheck(){
		
		print("initializing menu buttons");
		return true;
	}
}
