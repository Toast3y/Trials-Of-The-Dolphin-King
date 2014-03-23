using UnityEngine;
using System.Collections;
using Fungus;

public class Map : MonoBehaviour {

	public FlightScreen FlightScreen;

	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
		var cam = Camera.main.transform;
		
		Vector2 TranslatedHit = cam.InverseTransformPoint (hit.point);
		
		//if(hit.collider != null && hit.collider.transform == this.transform){
			//Say ("Raycast hit ( " + TranslatedHit.x + " , " + TranslatedHit.y + " )");
			//FlightScreen.xCoord = TranslatedHit.x;
			FlightScreen.Say ("Raycast hit: ( " + TranslatedHit.x + " , " + TranslatedHit.y + " )");
		//}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
