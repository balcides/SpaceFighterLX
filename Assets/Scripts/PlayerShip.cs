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
	
	public TextMesh livesText;
	
	
	Transform Asset; //Not sure but I kept this for the graph notation
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		livesText.text = "Lives " + playerLives.ToString("00");
	}
	
	void playerControls(){
	}
	
	//Limits the range of what the camera and ship can do/go 
	void ctrlConstrains(){
		//This section is for ship contrains
		//this section is for camera constrains
	}
	
	
}
