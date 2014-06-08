using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// 	Screensize.cs
/// 
///  	Used to run any scripts that help set the camera, 
/// 	game objects, and boundries to the set device resoltion preset
/// 
/// </summary>

public class Screensize : MonoBehaviour {
	
	public enum screenSize {web, droid, iphone, ipad, tablet, pc, osx, fullScreen};
	public screenSize rez;
	
	
    screenSize ScreenSize (screenSize resolution)
    {
        if(resolution == screenSize.web){ 				print("web rez enabled"); 			}
        else if(resolution == screenSize.droid){ 		print("droid rez  enabled"); 		}
        else if(resolution == screenSize.iphone){ 		print("iphone rez enabled");  		}
        else if(resolution == screenSize.ipad){ 		print("ipad rez enabled");  		}
        else if(resolution == screenSize.tablet){ 		print("tablet rez enabled");  		}
		else if(resolution == screenSize.pc){ 			print("pc rez enabled");  			}
		else if(resolution == screenSize.osx){ 			print("OSX rez enabled");  	 Screen.SetResolution(1024, 768, false);}
		else if(resolution == screenSize.fullScreen){ 	print("fullScreen rez enabled");  	}
		else{}
		
        return resolution;     
    }
	
	void Awake(){
		//rez = screenSize.osx;
	}
	
	// Use this for initialization
	void Start () {
		
		
		//initialize screensize
		ScreenSize(rez);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
