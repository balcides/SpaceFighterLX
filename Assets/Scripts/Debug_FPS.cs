using UnityEngine;
using System.Collections;



/// <summary>
/// 
/// Debug_ FPS.cs
/// 
///Attach this to a GUIText to make a frames/second indicator.
//
// It calculates frames/second over each updateInterval,
// so the display does not keep changing wildly.
//
// It is also fairly accurate at very low FPS counts (<10).
// We do this not by simply counting frames per interval, but
// by accumulating FPS for each frame. This way we end up with
// correct overall FPS even if the interval renders something like
// 5.5 frames.
/// 
/// </summary>

[RequireComponent (typeof (TextMesh))]	

public class Debug_FPS : MonoBehaviour {
	
	double updateInterval = 0.5;
	
	private double accum = 0.0; 	// FPS accumulated over the interval
	private double frames = 0;	 // Frames drawn over the interval
	private double timeleft;			 // Left time for current interval
	
	public double fcount;
	
	TextMesh textMesh;   //in this case, guiText is known as the component attached to the gameObject this script is running on

	// Use this for initialization
	void Start () {
		
		textMesh = GetComponent<TextMesh>();
	
//	    if( !TextMesh )
//	    {
//	        print ("FramesPerSecond needs a GUIText component!");
//	        enabled = false;
//	        return;
//	    }
//		else{}
		
	    timeleft = updateInterval; 
	
	}
	
	// Update is called once per frame
	void Update () {
		 
		timeleft -= Time.deltaTime;
	    accum += Time.timeScale/Time.deltaTime;
	    ++frames;
	   
	    // Interval ended - update GUI text and start new interval
	    if( timeleft <= 0.0 )
	    {
			fcount = (accum/frames);
	        // display two fractional digits (f2 format)
			
			textMesh.text = "fps:" + fcount.ToString("f2");
	        //guiText.text = "fps:" + (accum/frames).ToString("f2");
	        timeleft = updateInterval;
	        accum = 0.0;
	        frames = 0;
	    }
	}
	
}
