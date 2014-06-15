using UnityEngine;
using System.Collections;

/// <summary>
/// Optimization.cs
/// 
/// This script was designed for loading and unloading assets, managing triggers, and visibilitys
/// A great place to put all the debug info data such as fps, particle count, etc.
/// 
/// </summary>

public class Optimization : MonoBehaviour {
	
	public enum DebugGUI {FullDetail, FPS, ParticleCount, None};
	public DebugGUI debugSelection;
	
	public float fps;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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


