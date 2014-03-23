using UnityEngine;
using System.Collections;
using Fungus;

public class FlightScreen : Room {
	
	public Cockpit Cockpit;

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
		if ((clickedPosition.x >= 336) && (clickedPosition.x < 380)) {
			Cockpit.xCoordChange = 1;
		}
		else if ((clickedPosition.x >= 380) && (clickedPosition.x < 424)) {
			Cockpit.xCoordChange = 2;
		}
		else if ((clickedPosition.x >= 424) && (clickedPosition.x < 468)) {
			Cockpit.xCoordChange = 3;
		}
		else if ((clickedPosition.x >= 468) && (clickedPosition.x < 512)) {
			Cockpit.xCoordChange = 4;
		}
		else if ((clickedPosition.x >= 512) && (clickedPosition.x < 556)) {
			Cockpit.xCoordChange = 5;
		}
		else if ((clickedPosition.x >= 556) && (clickedPosition.x < 600)) {
			Cockpit.xCoordChange = 6;
		}
		else if ((clickedPosition.x >= 600) && (clickedPosition.x < 644)) {
			Cockpit.xCoordChange = 7;
		}
		else if ((clickedPosition.x >= 644) && (clickedPosition.x < 688)) {
			Cockpit.xCoordChange = 8;
		}


		//Determine Y Coords
		if ((clickedPosition.y >= 212) && (clickedPosition.y < 256)) {
			Cockpit.yCoordChange = 1;
		}
		else if ((clickedPosition.y >= 256) && (clickedPosition.y < 300)) {
			Cockpit.yCoordChange = 2;
		}
		else if ((clickedPosition.y >= 300) && (clickedPosition.y < 344)) {
			Cockpit.yCoordChange = 3;
		}
		else if ((clickedPosition.y >= 344) && (clickedPosition.y < 388)) {
			Cockpit.yCoordChange = 4;
		}
		else if ((clickedPosition.y >= 388) && (clickedPosition.y < 432)) {
			Cockpit.yCoordChange = 5;
		}
		else if ((clickedPosition.y >= 432) && (clickedPosition.y < 476)) {
			Cockpit.yCoordChange = 6;
		}
		else if ((clickedPosition.y >= 476) && (clickedPosition.y < 520)) {
			Cockpit.yCoordChange = 7;
		}
		else if ((clickedPosition.y >= 520) && (clickedPosition.y < 564)) {
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
