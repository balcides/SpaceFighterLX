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
	
	public float povOffsetX;
	public float povOffsetY;
	public float povOffsetZ;
	
	private GameObject cam;
	private Vector3 camPos;
	
	Transform Asset; //Not sure but I kept this from my notes
	
	void Awake(){
		cam = GameObject.FindWithTag("MainCamera");
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
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
		
		camPos = cam.transform.position;
		
		if(modes == CtrlModes.mode1Starfox){
			
			//take cam rotation and ship rotation and set it
			cam.transform.eulerAngles = new Vector3(0,0,0);
			
			//move the ship to xyz offset from camera
			povOffsetZ = 4.5f;
			transform.position = new Vector3(transform.position.x, transform.position.y, camPos.z + povOffsetZ);
	
		}
		else if(modes == CtrlModes.mode2POV){
			
			//move the ship to xyz offset from camera
			povOffsetX = 0.03f;
			povOffsetY = -0.69f;
			povOffsetZ = 0;
			
			transform.position = new Vector3(camPos.x + povOffsetX, camPos.y + povOffsetY, camPos.z + povOffsetZ);
			//cam.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			
			
		}
		else{}
	}
	
}
