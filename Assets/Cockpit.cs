using UnityEngine;
using System.Collections;
using Fungus;

public class Cockpit : Room {

	public Player playerOne = new Player();

	public Room MainMenuRoom;

	public Room BattleScreen;

	public bool gameOver;

	// Use this for initialization
	void Start () {
		if (this.visitCount == 0) {
			gameOver = false;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnEnter(){
		Wait (1);
		
		AddOption ("Make a Flight", FlightPath);
		AddOption ("Event Interact", DoNothing);
		AddOption ("Do things!", ShowResources);
		
		Choose ("");
	}


	void DoNothing(){
		MoveToRoom (BattleScreen);

		playerOne.position.x = 0;
		playerOne.position.y = 0;
		MoveToRoom (MainMenuRoom);


	}

	void ShowResources(){
		Say ("Fuel: " + playerOne.fuel + "\nMetal: " + playerOne.metal + "\nRock Candy: " + playerOne.rock + "\nFish: " + playerOne.fish + "\nMissiles: " + playerOne.missiles);

		MoveToRoom (this);
	}

	void FlightPath(){
		playerOne.position.x += 1;
		playerOne.position.y += 1;
		Say ("Now at position " + playerOne.position.x + ", " + playerOne.position.y);

		MoveToRoom (this);
	}
}
