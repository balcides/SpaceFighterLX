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
	
	public enum inputType {ios, iCade, osx, pc, android, oculous};
	public inputType controls;
	
	Transform playerShip;
	Assets assets;
	
	public float inputMoveVertical;
	public float inputMoveHorizontal;
	private float PlayerSpeed;
	
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
		assets = GetComponent<Assets>();
		playerShip = assets.models[0];										//grabs the player ship model from the assets
		PlayerSpeed = playerShip.GetComponent<PlayerShip>().playerSpeed;	//grabs player speed from the ship's script on startup
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
		
		
	}
	
	void osxInput(){
		
		PlayerSpeed = playerShip.GetComponent<PlayerShip>().playerSpeed; //Maybe expensive
		
		inputMoveVertical = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
		inputMoveHorizontal = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
		
		playerShip.Translate(inputMoveHorizontal, inputMoveVertical, 0);
	}
}
