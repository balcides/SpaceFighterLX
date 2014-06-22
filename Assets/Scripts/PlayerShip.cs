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
	
	//Control
	public enum CtrlMovement {up, down, left, right, center};
	public enum CtrlModes {mode1Starfox, mode2POV, mode3SideScroller, mode4Isometric};
	
	public CtrlMovement movement;
	public CtrlModes modes;
	
	//Player
	public int playerLives;
	public int shields;
	public float playerSpeed;
	public float playerThrusterSpeed;

	//Camera
	public float cameraSpeed;
	public float cameraAngle;
	public bool cameraConstrains;
	public bool invertY;
	private GameObject cam;
	private Vector3 camPos;
	
	//Position
	public float povShipPosOffsetX;
	public float povShipPosOffsetY;
	public float povShipPosOffsetZ;
	
	//rotation
	public float povShipRotateOffsetX;
	public float povShipRotateOffsetY;
	public float povShipRotateOffsetZ;
	
	public float povCamRotateOffsetX;
	public float povCamRotateOffsetY;
	public float povCamRotateOffsetZ;
	
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
			//cam.transform.eulerAngles = new Vector3(0,0,0);
			
			
			//move the ship to xyz offset from camera
			//povShipPosOffsetX = 0f;
			//povShipPosOffsetY = 0f;
			povShipPosOffsetZ = 4.5f;
			
			//rotation offset
			povShipRotateOffsetX = 90f;
			povShipRotateOffsetY = 0;
			povShipRotateOffsetZ = 0;
		
			povCamRotateOffsetX = 0;
			povCamRotateOffsetY = 0;
			povCamRotateOffsetZ = 0;
			
			
			//transform.position = new Vector3(transform.position.x, transform.position.y, camPos.z + povShipPosOffsetZ);
			
			shipOffset(transform.position.x,transform.position.y,povShipPosOffsetZ,povShipRotateOffsetX, povShipRotateOffsetY, povShipRotateOffsetZ, true);
	
		}
		else if(modes == CtrlModes.mode2POV){
			
			
			//move the ship to xyz offset from camera
			povShipPosOffsetX = 0f;
			povShipPosOffsetY = -0.94f;
			povShipPosOffsetZ = 0.36f;
			
			//rotation offset
			povShipRotateOffsetX = 90f;
			povShipRotateOffsetY = 0;
			povShipRotateOffsetZ = 0;
		
			povCamRotateOffsetX = 0;
			povCamRotateOffsetY = 0;
			povCamRotateOffsetZ = 0;
			
			//ship transform
			shipOffset(povShipPosOffsetX,povShipPosOffsetY,povShipPosOffsetZ,povShipRotateOffsetX, povShipRotateOffsetY, povShipRotateOffsetZ, false);
		
			//take cam rotation and ship rotation and set it
			cameraOffset(povCamRotateOffsetX, povCamRotateOffsetY, povCamRotateOffsetZ);
			
		}
		else if(modes == CtrlModes.mode3SideScroller){
			
			    //move the ship to xyz offset from camera
				povShipPosOffsetX = -5.24f;
				povShipPosOffsetY = 0;
				povShipPosOffsetZ = 0;
			
				//rotation offset
				povShipRotateOffsetX = 90f;
				povShipRotateOffsetY = 0;
				povShipRotateOffsetZ = 0;
			
				povCamRotateOffsetX = 0;
				povCamRotateOffsetY = -90f;
				povCamRotateOffsetZ = 0;
				
				//ship transform
				shipOffset(povShipPosOffsetX,povShipPosOffsetY,povShipPosOffsetZ,povShipRotateOffsetX, povShipRotateOffsetY, povShipRotateOffsetZ, false);
			
				//take cam rotation and ship rotation and set it
				cameraOffset(povCamRotateOffsetX, povCamRotateOffsetY, povCamRotateOffsetZ);

		}
		else if(modes == CtrlModes.mode4Isometric){
			
			/*
			    //move the ship to xyz offset from camera
				povShipPosOffsetX = -5.24f;
				povShipPosOffsetY = 0;
				povShipPosOffsetZ = 0;
			
				//rotation offset
				povShipRotateOffsetX = 90f;
				povShipRotateOffsetY = 0;
				povShipRotateOffsetZ = 0;
			
				povCamRotateOffsetX = 0;
				povCamRotateOffsetY = -90f;
				povCamRotateOffsetZ = 0;
				*/
			
				//ship transform
				shipOffset(povShipPosOffsetX,povShipPosOffsetY,povShipPosOffsetZ,povShipRotateOffsetX, povShipRotateOffsetY, povShipRotateOffsetZ, false);
			
				//take cam rotation and ship rotation and set it
				cameraOffset(povCamRotateOffsetX, povCamRotateOffsetY, povCamRotateOffsetZ);

		}
		else{}
	}
	
	//Method for camera rotation and transform offset
	void cameraOffset(float camRotOffsetX, float camRotOffsetY, float camRotOffsetZ){
				
		
				//take cam rotation and ship rotation and set it
				cam.transform.eulerAngles = new Vector3(camRotOffsetX, camRotOffsetY, camRotOffsetZ);
		
	}
	
	//Method for ship rotation and transform offset
	void shipOffset(float shipPosOffsetX, float shipPosOffsetY, float shipPosOffsetZ, 
					float povShipRotOffsetX, float povShipRotOffsetY, float povShipRotOffsetZ, bool lockToCam){
		
			if(lockToCam){
			
				transform.position = new Vector3(transform.position.x, transform.position.y, camPos.z + povShipPosOffsetZ); 
			}
			else{
				transform.position = new Vector3(camPos.x + shipPosOffsetX, 
												 camPos.y + shipPosOffsetY, 
												 camPos.z + shipPosOffsetZ);
			}

				// ship rotation
				transform.eulerAngles = new Vector3(povShipRotOffsetX,
											        povShipRotOffsetY,
											        povShipRotOffsetZ);
	}
}
