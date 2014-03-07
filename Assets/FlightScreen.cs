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
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);

		if(hit.collider != null && hit.collider.transform == this.transform){
			Say ("Raycast hit");
		}
		

	}

	void CalculateFlight(){
		Vector3 clickedPosition = Input.mousePosition;

		//Determine X coords
		if ((clickedPosition.x >= 310) && (clickedPosition.x < 365)) {
			Cockpit.xCoordChange = 1;
		}
		else if ((clickedPosition.x >= 365) && (clickedPosition.x < 420)) {
			Cockpit.xCoordChange = 2;
		}
		else if ((clickedPosition.x >= 420) && (clickedPosition.x < 475)) {
			Cockpit.xCoordChange = 3;
		}
		else if ((clickedPosition.x >= 475) && (clickedPosition.x < 530)) {
			Cockpit.xCoordChange = 4;
		}
		else if ((clickedPosition.x >= 530) && (clickedPosition.x < 585)) {
			Cockpit.xCoordChange = 5;
		}
		else if ((clickedPosition.x >= 585) && (clickedPosition.x < 640)) {
			Cockpit.xCoordChange = 6;
		}
		else if ((clickedPosition.x >= 640) && (clickedPosition.x < 695)) {
			Cockpit.xCoordChange = 7;
		}
		else if ((clickedPosition.x >= 695) && (clickedPosition.x < 750)) {
			Cockpit.xCoordChange = 8;
		}


		//Determine Y Coords
		if ((clickedPosition.y >= 75) && (clickedPosition.y < 130)) {
			Cockpit.yCoordChange = 1;
		}
		else if ((clickedPosition.y >= 130) && (clickedPosition.y < 185)) {
			Cockpit.yCoordChange = 2;
		}
		else if ((clickedPosition.y >= 185) && (clickedPosition.y < 240)) {
			Cockpit.yCoordChange = 3;
		}
		else if ((clickedPosition.y >= 240) && (clickedPosition.y < 295)) {
			Cockpit.yCoordChange = 4;
		}
		else if ((clickedPosition.y >= 295) && (clickedPosition.y < 350)) {
			Cockpit.yCoordChange = 5;
		}
		else if ((clickedPosition.y >= 350) && (clickedPosition.y < 405)) {
			Cockpit.yCoordChange = 6;
		}
		else if ((clickedPosition.y >= 405) && (clickedPosition.y < 460)) {
			Cockpit.yCoordChange = 7;
		}
		else if ((clickedPosition.y >= 460) && (clickedPosition.y < 515)) {
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
