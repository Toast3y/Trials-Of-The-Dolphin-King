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
		if ((clickedPosition.x >= 225) && (clickedPosition.x < 297)) {
			Cockpit.xCoordChange = 1;
		}
		else if ((clickedPosition.x >= 297) && (clickedPosition.x < 369)) {
			Cockpit.xCoordChange = 2;
		}
		else if ((clickedPosition.x >= 369) && (clickedPosition.x < 441)) {
			Cockpit.xCoordChange = 3;
		}
		else if ((clickedPosition.x >= 441) && (clickedPosition.x < 513)) {
			Cockpit.xCoordChange = 4;
		}
		else if ((clickedPosition.x >= 513) && (clickedPosition.x < 585)) {
			Cockpit.xCoordChange = 5;
		}
		else if ((clickedPosition.x >= 585) && (clickedPosition.x < 657)) {
			Cockpit.xCoordChange = 6;
		}
		else if ((clickedPosition.x >= 657) && (clickedPosition.x < 729)) {
			Cockpit.xCoordChange = 7;
		}
		else if ((clickedPosition.x >= 729) && (clickedPosition.x < 801)) {
			Cockpit.xCoordChange = 8;
		}


		//Determine Y Coords
		if ((clickedPosition.y >= 100) && (clickedPosition.y < 172)) {
			Cockpit.yCoordChange = 1;
		}
		else if ((clickedPosition.y >= 172) && (clickedPosition.y < 244)) {
			Cockpit.yCoordChange = 2;
		}
		else if ((clickedPosition.y >= 244) && (clickedPosition.y < 316)) {
			Cockpit.yCoordChange = 3;
		}
		else if ((clickedPosition.y >= 316) && (clickedPosition.y < 388)) {
			Cockpit.yCoordChange = 4;
		}
		else if ((clickedPosition.y >= 388) && (clickedPosition.y < 460)) {
			Cockpit.yCoordChange = 5;
		}
		else if ((clickedPosition.y >= 460) && (clickedPosition.y < 532)) {
			Cockpit.yCoordChange = 6;
		}
		else if ((clickedPosition.y >= 532) && (clickedPosition.y < 604)) {
			Cockpit.yCoordChange = 7;
		}
		else if ((clickedPosition.y >= 604) && (clickedPosition.y < 676)) {
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
