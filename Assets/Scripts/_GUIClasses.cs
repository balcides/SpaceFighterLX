using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// _ GUI classes.cs
/// 
///  This was designed as a global class for the GUI system and score menu
/// 
/// </summary>

[System.Serializable]
public class _GUIClasses : MonoBehaviour {
	
	public static  _GUIClasses use;	//calls itself to make it global
	void Awake(){ use = this;}		//makes this easy to call from anywhere

	[SerializeField]
	public Location location = new Location();
	
	[System.Serializable]
	public class Location{
		
		[SerializeField]
		public enum Point { TopLeft, TopRight, BottomLeft, BottomRight, Center};
		[SerializeField]
		public Point pointLocation = Point.TopLeft;
		[SerializeField]
		public Vector2 offset;
		
		public void updateLocation(){
			switch(pointLocation){
				
			case Point.TopLeft:
				offset = new Vector2(0,0);
				break;
				
			case Point.TopRight:
				offset = new Vector2(Screen.width,0);
				break;
				
			case Point.BottomLeft:
				offset = new Vector2(0,Screen.height);
				break;
				
			case Point.BottomRight:
				offset = new Vector2(Screen.width, Screen.height);
				break;
				
			case Point.Center:
				offset = new Vector2(Screen.width/2, Screen.height/2);
				break;
			}
		}
	}



}



