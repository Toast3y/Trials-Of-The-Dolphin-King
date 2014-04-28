/*Flight screen scripting that allows the player to travel
 * 
 * Author: Christopher Jerrard-Dunne
 */

using UnityEngine;
using System.Collections;
using Fungus;

public class FlightScreen : Room {
	
	public Cockpit Cockpit;

	int fuelCost;
	int xDifference;
	int yDifference;


	//Testing for raycasthit processing of flight confirm screen
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

	//Checks the position clicked by the mouse on the grid, then asks if the coordinates are right.
	//Note: This is horribly hard coded. I tried to get raycasthits to work, but nothing I did got things to work right.
	//This mostly did the job.
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

		//Calculates the fuel cost by difference of X and Y coordinates as a positive integer
		xDifference = (int)Cockpit.playerOne.position.x - Cockpit.xCoordChange;
		
		if (xDifference < 0) {
			xDifference = -(xDifference);
		}
		
		yDifference = (int)Cockpit.playerOne.position.y - Cockpit.yCoordChange;
		
		if (yDifference < 0) {
			yDifference = -(yDifference);
		}
		
		fuelCost = xDifference + yDifference;

		//If fuelcost is 0, you clicked in the coordinates you're at now
		if (fuelCost == 0) {
			Say ("Hang on, these are the same coordinates we're at right now! We can't fly to where we already are!");
			MoveToCockpit ();
		}
		else {
			//Asks you if you chose the right coordinates
			AddOption ("Yes", AuthorizeFlight);
			AddOption ("No", MoveToCockpit);
			
			Choose ("Moving from ( " + Cockpit.playerOne.position.x + " , " + Cockpit.playerOne.position.y + " ) to ( " + Cockpit.xCoordChange + " , " + Cockpit.yCoordChange + " )\nThis will cost " + fuelCost + " fuel.\nDo you wish to continue?");
		}
	}
	
	// Use this for initialization
	//Not used in script. Kept for compatibility purposes
	void Start () {
		
	}
	
	// Update is called once per frame
	//Not used in script. Kept for compatibility purposes
	void Update () {
		
	}

	//Moves you back to cockpit
	void MoveToCockpit(){
		MoveToRoom (Cockpit);
	}

	//Initializes flight and moves to cockpit
	void AuthorizeFlight(){
		Cockpit.startFlight = true;
		MoveToCockpit ();
	}
}