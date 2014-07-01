using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// SetPlayerPrefs.cs
/// 
/// saves, accesses, and modifies player data via playerPrefs in Unity
/// 
/// </summary>

public class SetPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString("Player Name", "Fulano");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
