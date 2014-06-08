using UnityEngine;
using System.Collections;

/// <summary>
/// Assets.cs
/// 
/// This script was designed to load and keep track of assets for the game
/// </summary>

public class Assets : MonoBehaviour {
	
	public Transform[] models;
	public AudioClip[] audioFiles;
	public Texture[] textures;
	
		
    void Awake (){
		
            //Loading the items into the array
           audioFiles[0] = (AudioClip)Resources.Load("Resources/Sound/intro");
		}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
