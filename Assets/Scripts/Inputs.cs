using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// Input.cs
/// 
/// Handles all of the input controls for the game
/// 
/// Author : Gabe Betancourt
/// 
/// </summary>

[RequireComponent (typeof (Assets))]				//require Assets

public class Inputs : MonoBehaviour {

	public static Inputs use;	//calls itself to make it global 'i.e. Input.use.topScore, Input.use.resetScore, etc. etc. '

	public enum inputType {ios, iCade, osx, pc, android, oculous};
	public enum CtrlModes {mode1Starfox, mode2POV, mode3SideScroller, mode4Isometric};
	
	public inputType controls;
	public CtrlModes modes;
	
	Transform playerShip;
	Transform camParent;
	PlayerShip playerScript;
	Assets assets;
	
	public float inputMoveVertical;
	public float inputMoveHorizontal;
	private float PlayerSpeed;
	private float PlayerThrusterSpeed;
	
	private GameObject cam;
	
    inputType controlsUsed (inputType controls)
    {
        if(controls == inputType.ios){ 			print("iOS controls enabled"); }
        else if(controls == inputType.osx){ 	print("OSX controls enabled"); }
        else if(controls == inputType.pc){ 		print("PC controls enabled");  }
        else if(controls == inputType.android){ print("Droid controls enabled");  }
        else if(controls == inputType.iCade){ 	print("iCade controls enabled");  }
		else if(controls == inputType.oculous){ print("Oculous controls enabled");  }
		else{}
		
        return controls;     
    }
	
	void Awake(){

		use = this;
		cam = GameObject.FindWithTag("MainCamera");
		assets = GetComponent<Assets>();
		playerShip = assets.playerShipGO.transform;										//grabs the player ship model from the assets
		playerScript = playerShip.GetComponent<PlayerShip>();
		PlayerSpeed = playerScript.playerSpeed;											//grabs player speed from the ship's script on startup
		PlayerThrusterSpeed = playerScript.playerThrusterSpeed; 						//grabs players thruster speed
		camParent = cam.transform.parent;
		
	}
	
	// Use this for initialization
	void Start () {
		
		controlsUsed(controls);	//initialize controls
	}
	
	// Update is called once per frame
	void Update () {
		
		runInputHandler();

	}
	
	//Decides which input script to use set by the inputType enum
	void runInputHandler(){
		
		if(controls == inputType.osx){ osxInput(); }
		else{}
		
		if(modes == CtrlModes.mode1Starfox){
			playerScript.modes = PlayerShip.CtrlModes.mode1Starfox;}
		else if(modes == CtrlModes.mode2POV){
			playerScript.modes = PlayerShip.CtrlModes.mode2POV;}
		else if(modes == CtrlModes.mode3SideScroller){
			playerScript.modes = PlayerShip.CtrlModes.mode3SideScroller;}
		else if(modes == CtrlModes.mode4Isometric){
			playerScript.modes = PlayerShip.CtrlModes.mode4Isometric;}
		else{}
		
	}
	
	void osxInput(){
		
		PlayerSpeed = playerScript.playerSpeed; //Maybe expensive
		
		inputMoveVertical = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
		inputMoveHorizontal = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
		
		//MODE1
		if(playerScript.modes == PlayerShip.CtrlModes.mode1Starfox){ 
			
			cam.transform.Translate(0, 0, PlayerThrusterSpeed * Time.deltaTime); 
			
			if(playerScript.invertY){ playerShip.Translate(inputMoveHorizontal, 0, -inputMoveVertical); }
			else{ playerShip.Translate(inputMoveHorizontal, 0, inputMoveVertical); }
			
		}
		//MODE2
		else if(playerScript.modes == PlayerShip.CtrlModes.mode2POV){
			cam.transform.Translate(inputMoveHorizontal, inputMoveVertical, PlayerThrusterSpeed * Time.deltaTime);
		}
		//MODE3
		else if(playerScript.modes == PlayerShip.CtrlModes.mode3SideScroller){
			//cam.transform.Translate(inputMoveHorizontal, inputMoveVertical,0);
			
			cam.transform.Translate(PlayerThrusterSpeed * Time.deltaTime, 0, 0); 
			
			playerShip.Translate(cam.transform.position.x, inputMoveHorizontal, -inputMoveVertical); 
		}
		//MODE4
		else if(playerScript.modes == PlayerShip.CtrlModes.mode4Isometric){
			//cam.transform.Translate(inputMoveHorizontal, inputMoveVertical,0);
			camParent.Translate(0, 0, PlayerThrusterSpeed * Time.deltaTime); 
			
			//cam.transform.Translate(0, 0, PlayerThrusterSpeed * Time.deltaTime); 
			playerShip.Translate(inputMoveHorizontal, inputMoveVertical, 0);
		}
		else{}
		
	}
}
