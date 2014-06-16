// Attach this to a GUIText to make a frames/second indicator.
//
// It calculates frames/second over each updateInterval,
// so the display does not keep changing wildly.
//
// It is also fairly accurate at very low FPS counts (<10).
// We do this not by simply counting frames per interval, but
// by accumulating FPS for each frame. This way we end up with
// correct overall FPS even if the interval renders something like
// 5.5 frames.

var updateInterval = 0.5;

private var accum = 0.0; // FPS accumulated over the interval
private var frames = 0; // Frames drawn over the interval
private var timeleft : float; // Left time for current interval

var fcount : float;
//var guiText : GUIText;   //in this case, guiText is known as the component attached to the gameObject this script is running on
	

function Start()
{
	//guiText = GetComponent(GUIText);
	
    if( !guiText )
    {
        print ("FramesPerSecond needs a GUIText component!");
        enabled = false;
        return;
    }
    timeleft = updateInterval; 
}

function Update()
{
    timeleft -= Time.deltaTime;
    accum += Time.timeScale/Time.deltaTime;
    ++frames;
   
    // Interval ended - update GUI text and start new interval
    if( timeleft <= 0.0 )
    {
		fcount = (accum/frames);
        // display two fractional digits (f2 format)
		
		guiText.text = "fps:" + fcount.ToString("f2");
        //guiText.text = "fps:" + (accum/frames).ToString("f2");
        timeleft = updateInterval;
        accum = 0.0;
        frames = 0;
    }
	
	
}
 