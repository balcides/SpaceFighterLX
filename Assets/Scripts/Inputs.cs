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
	public inputType controls = inputType.ios;
	
	public Transform playerShip;
	Assets assets;
	
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
		playerShip = assets.models[0];
	}
	
	// Use this for initialization
	void Start () {
		
		//initialize controls
		controlsUsed(controls);

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
