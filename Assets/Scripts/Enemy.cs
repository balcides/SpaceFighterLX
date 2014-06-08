using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// 
/// Enemy.cs
/// 
/// This script controls the enemy 
/// 
/// </summary>

[RequireComponent (typeof (WeaponSystem))]					//require weapon system

public class Enemy : MonoBehaviour {
	
	public enum AI {Drone, Boss};
	public AI aiSelection = AI.Drone;
	
	public int health;
	public int damage;
	
	AI aiType (AI behavior)
    {
        if(behavior == AI.Drone){ 		Drone (); 	}
        else if(behavior == AI.Boss){ 	Boss (); 	}
		else{}
		
        return behavior;     
    }
	
	// Use this for initialization
	void Start () {
		aiType(aiSelection);	//initialize controls
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
			
			
	public void initializeEnemy(){
		print("enemy class initialized");
	}
	
		
	public void Drone(){
		print("Drone Initialized");
	}

		
	public void Boss(){
		print("Boss Initialized");
	}
			


}//end of Enemy class
		
