using UnityEngine;
using System.Collections;
using Fungus;

public class FlightScreen : Room {
	
	public Cockpit Cockpit;
	
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
	
	
	//Calculate the Y Coordinates
	
	
	void CalculateYCoords(){
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
	
	void MoveYOne(){
		MoveToRoom (Cockpit);
	}
	
	void MoveYTwo(){
		MoveToRoom (Cockpit);
	}
	
	void MoveYThree(){
		MoveToRoom (Cockpit);
	}
	
	void MoveYFour(){
		MoveToRoom (Cockpit);
	}
	
	void MoveYFive(){
		MoveToRoom (Cockpit);
	}
	
	void MoveYSix(){
		MoveToRoom (Cockpit);
	}
	
	void MoveYSeven(){
		MoveToRoom (Cockpit);
	}
	
	void MoveYEight(){
		MoveToRoom (Cockpit);
	}
	
	
	
	void MoveToCockpit(){
		MoveToRoom (Cockpit);
	}
	
	
}
