 using UnityEngine;
using System.Collections;
using Fungus;

public class FlightConfirm : Room {

	public Cockpit Cockpit;

	int fuelCost;
	int xDifference;
	int yDifference;

	void OnEnter (){
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

	void AuthorizeFlight(){
		Cockpit.startFlight = true;
		MoveToCockpit ();
	}

	void MoveToCockpit(){
		MoveToRoom (Cockpit);
	}
}
