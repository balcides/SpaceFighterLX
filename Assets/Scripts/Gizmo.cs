using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour {
	
	public Color gizColor;
	public float GizmoDisplayCore;
	public float GizmoDisplayRange;
	
	// Use this for initialization
	void Start () {
			OnDrawGizmos();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDrawGizmos(){
		
		// keeps the iunner core from exceeding the outercore
		if(GizmoDisplayCore >=  GizmoDisplayRange){
			GizmoDisplayCore = GizmoDisplayRange;
		}
		
		if(GizmoDisplayCore <= 0){
			GizmoDisplayCore = 0;
		}
		
		if(GizmoDisplayRange <= 0){
			GizmoDisplayRange = 0;
		}
		
		gizColor.a = 100;
        Gizmos.color = gizColor;
        Gizmos.DrawWireSphere(transform.position, GizmoDisplayRange);
		Gizmos.DrawWireSphere(transform.position, GizmoDisplayCore);
	}
}
