using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// PlayerShip.cs
/// 
/// Lives, Assets, Shilds, and Controls for Player
/// 
/// </summary>
/// 

[RequireComponent (typeof (TextMesh))]

public class PlayerShip : MonoBehaviour {
	
	public enum CtrlMovement {up, down, left, right, center};
	public enum CtrlModes {mode1Starfox, mode2POV, mode3SideScroller, mode4Isometric};
	
	public CtrlMovement movement;
	public CtrlModes modes;
	
	public int playerLives;
	public int shields;
	public float playerSpeed;

	public float cameraSpeed;
	public float cameraAngle;
	public bool cameraConstrains;
	public bool invertY;
	
	private GameObject cam;
	
	public TextMesh livesText;
	
	Transform Asset; //Not sure but I kept this from my notes
	
	void Awake(){
		cam = GameObject.FindWithTag("MainCamera");
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		livesText.text = "Lives " + playerLives.ToString("00");
		runCameraMode();
	}
	
	void playerControls(){
	}
	
	//Limits the range of what the camera and ship can do/go 
	void ctrlConstrains(){
		//This section is for ship contrains
		//this section is for camera constrains
			//look at the position of minx, miny, maxx, and maxy of the camera
		
			        //Vector3 viewPos = camera.WorldToViewportPoint(target.position);
			       // if (viewPos.x > 0.5F)
			            //print("target is on the right side!");
			        //else
			           // print("target is on the left side!");
			//if the ship is past each one, keep the ship in place
	}
	
	//run changes needed to execute camera modes
	void runCameraMode(){
		if(modes == CtrlModes.mode1Starfox){
			//take cam rotation and ship rotation and set it
			cam.transform.eulerAngles = new Vector3(0,0,0);
		}
		else{}
	}
	
}
