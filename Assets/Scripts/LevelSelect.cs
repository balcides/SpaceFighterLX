using UnityEngine;
using System.Collections;
/// <summary>
/// Level select.cs
/// 
/// This will setup any specifics with the level loading, game over, mission complete, etc.
/// 
///  levels class included for rounds
/// </summary>
/// 
/// 



public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// runs all the gamer over events
	public void gameOver(){
		print ("gameover initialized");
	}
	
	//runs the entire mission complete sequence including score tally, messages, animation, sound, events after all levels complete
	public void missionComplete(){
		print ("missionComplete initialized");
	}
	
	
	// rounds and bonus loaded here
	public class Levels
	{
		public int rounds;
        public int bonus;
	}
	
	public Levels levels = new Levels();
}




