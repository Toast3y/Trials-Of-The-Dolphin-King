using UnityEngine;
using System.Collections;
using Fungus;

public class FlightScreen : Room {
	
	public Cockpit Cockpit;
	
	//public FlightConfirm FlightConfirm;

	int fuelCost;
	int xDifference;
	int yDifference;

	void CheckPos(){
		/*
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
		var cam = Camera.main.transform;

		Vector2 TranslatedHit = cam.InverseTransformPoint (hit.point.x, hit.point.y, 0);

		if(hit.collider != null && hit.collider.transform == this.transform){
			Say ("Raycast hit ( " + TranslatedHit.x + " , " + TranslatedHit.y + " )");
		}
		*/

		Vector3 clickedPosition = Input.mousePosition;
		Say ("Clicked position: ( " + clickedPosition.x + " , " + clickedPosition.y + " )");

	}


	void CalculateFlight(){
		Vector3 clickedPosition = Input.mousePosition;

		//Determine X coords
		if ((clickedPosition.x >= 490) && (clickedPosition.x < 579)) {
			Cockpit.xCoordChange = 1;
		}
		else if ((clickedPosition.x >= 579) && (clickedPosition.x < 668)) {
			Cockpit.xCoordChange = 2;
		}
		else if ((clickedPosition.x >= 668) && (clickedPosition.x < 757)) {
			Cockpit.xCoordChange = 3;
		}
		else if ((clickedPosition.x >= 757) && (clickedPosition.x < 846)) {
			Cockpit.xCoordChange = 4;
		}
		else if ((clickedPosition.x >= 846) && (clickedPosition.x < 935)) {
			Cockpit.xCoordChange = 5;
		}
		else if ((clickedPosition.x >= 935) && (clickedPosition.x < 1024)) {
			Cockpit.xCoordChange = 6;
		}
		else if ((clickedPosition.x >= 1024) && (clickedPosition.x < 1113)) {
			Cockpit.xCoordChange = 7;
		}
		else if ((clickedPosition.x >= 1113) && (clickedPosition.x < 1202)) {
			Cockpit.xCoordChange = 8;
		}


		//Determine Y Coords
		if ((clickedPosition.y >= 119) && (clickedPosition.y < 208)) {
			Cockpit.yCoordChange = 1;
		}
		else if ((clickedPosition.y >= 208) && (clickedPosition.y < 297)) {
			Cockpit.yCoordChange = 2;
		}
		else if ((clickedPosition.y >= 297) && (clickedPosition.y < 386)) {
			Cockpit.yCoordChange = 3;
		}
		else if ((clickedPosition.y >= 386) && (clickedPosition.y < 475)) {
			Cockpit.yCoordChange = 4;
		}
		else if ((clickedPosition.y >= 475) && (clickedPosition.y < 564)) {
			Cockpit.yCoordChange = 5;
		}
		else if ((clickedPosition.y >= 564) && (clickedPosition.y < 653)) {
			Cockpit.yCoordChange = 6;
		}
		else if ((clickedPosition.y >= 653) && (clickedPosition.y < 742)) {
			Cockpit.yCoordChange = 7;
		}
		else if ((clickedPosition.y >= 742) && (clickedPosition.y < 831)) {
			Cockpit.yCoordChange = 8;
		}

		xDifference = (int)Cockpit.playerOne.position.x - Cockpit.xCoordChange;
		
		if (xDifference < 0) {
			xDifference = -(xDifference);
		}
		
		yDifference = (int)Cockpit.playerOne.position.y - Cockpit.yCoordChange;
		
		if (yDifference < 0) {
			yDifference = -(yDifference);
		}
		
		fuelCost = xDifference + yDifference;
		
		if (fuelCost == 0) {
			Say ("Hang on, these are the same coordinates we're at right now! We can't fly to where we already are!");
			MoveToCockpit ();
		}
		else {
			AddOption ("Yes", AuthorizeFlight);
			AddOption ("No", MoveToCockpit);
			
			Choose ("Moving from ( " + Cockpit.playerOne.position.x + " , " + Cockpit.playerOne.position.y + " ) to ( " + Cockpit.xCoordChange + " , " + Cockpit.yCoordChange + " )\nThis will cost " + fuelCost + " fuel.\nDo you wish to continue?");
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void MoveToCockpit(){
		MoveToRoom (Cockpit);
	}
	
	void AuthorizeFlight(){
		Cockpit.startFlight = true;
		MoveToCockpit ();
	}
}
