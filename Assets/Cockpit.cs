using UnityEngine;
using System.Collections;
using Fungus;

public class Cockpit : Room {

	public Player playerOne;

	public Room MainMenuRoom;

	public bool GameOver;

	// Use this for initialization
	void Start () {
		if (this.visitCount == 0) {
			GameOver = false;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnEnter(){
		Wait (1);



			AddOption ("Make a Flight", FlightPath);
			AddOption ("Event Interact", DoNothing);
			AddOption ("Do things!", DoNothing);

			Choose ("");


	}

	void DoNothing(){
		MoveToRoom (MainMenuRoom);

	}

	void FlightPath(){
		playerOne.position.x += 1;
		playerOne.position.y += 1;
		Say ("Now at position " + playerOne.position.x + ", " + playerOne.position.y);
		OnEnter();
	}
}
