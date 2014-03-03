using UnityEngine;
using System.Collections;
using Fungus;

public class FlightScreen : Room {
	
	public Cockpit Cockpit;
	public FlightConfirm FlightConfirm;
	
	void OnEnter(){
		Wait (1);
		
		AddOption ("1", MoveXOne);
		AddOption ("2", MoveXTwo);
		AddOption ("3", MoveXThree);
		AddOption ("4", MoveXFour);
		AddOption ("5", MoveXFive);
		AddOption ("6", MoveXSix);
		AddOption ("7", MoveXSeven);
		AddOption ("8", MoveXEight);
		AddOption ("Cancel", MoveToCockpit);
		
		Choose ("Currently at: (" + Cockpit.playerOne.position.x + " , " + Cockpit.playerOne.position.y + " )\nChoose X Coordinates:");
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//All X Coordinate methods
	//Unfortunately Fungus doesn't allow many options for choice inside unity, which means our hopes for a map would take at least a month to program
	//So all of this hacking is the only way Fungus will let us do this operation
	
	void MoveXOne(){
		Cockpit.xCoordChange = 1;
		CalculateYCoords ();
	}
	
	void MoveXTwo(){
		Cockpit.xCoordChange = 2;
		CalculateYCoords ();
	}
	
	void MoveXThree(){
		Cockpit.xCoordChange = 3;
		CalculateYCoords ();
	}
	
	void MoveXFour(){
		Cockpit.xCoordChange = 4;
		CalculateYCoords ();
	}
	
	void MoveXFive(){
		Cockpit.xCoordChange = 5;
		CalculateYCoords ();
	}
	
	void MoveXSix(){
		Cockpit.xCoordChange = 6;
		CalculateYCoords ();
	}
	
	void MoveXSeven(){
		Cockpit.xCoordChange = 7;
		CalculateYCoords ();
	}
	
	void MoveXEight(){
		Cockpit.xCoordChange = 8;
		CalculateYCoords ();
	}
	
	
	//Calculate the Y Coordinates, similar to the above
	//The Y coords move you to another room to OK your coordinates afterwards.
	//The main reason this is done is to allow us to redraw the page dialog box.
	
	
	void CalculateYCoords(){
		Wait (1);
		
		AddOption ("1", MoveYOne);
		AddOption ("2", MoveYTwo);
		AddOption ("3", MoveYThree);
		AddOption ("4", MoveYFour);
		AddOption ("5", MoveYFive);
		AddOption ("6", MoveYSix);
		AddOption ("7", MoveYSeven);
		AddOption ("8", MoveYEight);
		AddOption ("Cancel", MoveToCockpit);
		
		Choose ("Currently at: (" + Cockpit.playerOne.position.x + " , " + Cockpit.playerOne.position.y + " )\nChoose Y Coordinates:");
	}
	
	void MoveYOne(){
		Cockpit.yCoordChange = 1;
		MoveToRoom (FlightConfirm);
	}
	
	void MoveYTwo(){
		Cockpit.yCoordChange = 2;
		MoveToRoom (FlightConfirm);
	}
	
	void MoveYThree(){
		Cockpit.yCoordChange = 3;
		MoveToRoom (FlightConfirm);
	}
	
	void MoveYFour(){
		Cockpit.yCoordChange = 4;
		MoveToRoom (FlightConfirm);
	}
	
	void MoveYFive(){
		Cockpit.yCoordChange = 5;
		MoveToRoom (FlightConfirm);
	}
	
	void MoveYSix(){
		Cockpit.yCoordChange = 6;
		MoveToRoom (FlightConfirm);
	}
	
	void MoveYSeven(){
		Cockpit.yCoordChange = 7;
		MoveToRoom (FlightConfirm);
	}
	
	void MoveYEight(){
		Cockpit.yCoordChange = 8;
		MoveToRoom (FlightConfirm);
	}
	
	
	
	void MoveToCockpit(){
		MoveToRoom (Cockpit);
	}
	
	
}
