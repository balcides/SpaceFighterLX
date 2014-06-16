using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Optimization.cs
/// 
/// This script was designed for loading and unloading assets, managing triggers, and visibility
/// A great place to put all the debug info data such as fps, particle count, etc.
/// 
/// </summary>
/// 

[RequireComponent (typeof (TextMesh))]

public class Optimization : MonoBehaviour {
	
	public enum DebugGUI {FullDetail, FPS, ParticleCount, None};
	public DebugGUI debugSelection;
	public TextMesh fpsText;
	public float fps;
	
	Debug_FPS debugFps;
	
	void Awake(){
		debugFps = fpsText.GetComponent<Debug_FPS>();
		fps = Convert.ToSingle(debugFps.fcount);
	}
	
	// Use this for initialization
	void Start () {
		
		if(debugSelection == DebugGUI.FPS){ debugFps.enabled = true; fpsText.renderer.enabled = true; }
		else if(debugSelection == DebugGUI.FullDetail) {
				debugFps.enabled = true; 
				fpsText.renderer.enabled = true;
		}
		else{ 
				debugFps.enabled = false;
				fpsText.renderer.enabled = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		fps = Convert.ToSingle(debugFps.fcount);
	}
	
	//to manage triggers in the game globallys
	public void triggerManager(){
	}
	
	//to manage common visibility for optimization
	public void vizManager(){
	}
	
	//manages assets to load with the game
	public void assetLoader(){
		//background loading
		//foreground loading
	}
	
}


