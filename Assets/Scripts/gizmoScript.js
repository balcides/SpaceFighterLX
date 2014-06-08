///////////////////////////
// gizmoScript.js
//
// Use on any gameObject to see it 
// on screen in the editor
//////////////////////////
var color : Color;
var GizmoDisplayCore : float = 1;
var GizmoDisplayRange : float = 1;

// for future reference, would love to add a floating text in the editor to ID the Gizmos representation as a 3d label
function Update () {
}

function OnDrawGizmos()
{
	// keeps the iunner core from exceeding the outercore
	if(GizmoDisplayCore >=  GizmoDisplayRange)
	{
		GizmoDisplayCore = GizmoDisplayRange;
	}
	
	if(GizmoDisplayCore <= 0)
	{
		GizmoDisplayCore = 0;
	}
	
	if(GizmoDisplayRange <= 0)
	{
		GizmoDisplayRange = 0;
	}
	
	Gizmos.color=color;
	Gizmos.DrawWireSphere
			(transform.position, GizmoDisplayRange);
	Gizmos.DrawWireSphere
			(transform.position, GizmoDisplayCore);
}