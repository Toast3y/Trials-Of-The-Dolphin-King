using UnityEngine;
using System.Collections;
using Fungus;

public class Cockpit : Room {

	public Player playerOne = new Player();

	public Room MainMenuRoom;

	public Room BattleScreen;

	public int xCoordChange;
	public int yCoordChange;

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
		if (this.visitCount == 0) {
			playerOne.initialize();
		}

		Wait (1);
		
		AddOption ("Make a Flight", FlightPath);
		AddOption ("Event Interact", MoveToBattleRoom);
		AddOption ("Do things!", ShowResources);
		
		Choose ("");
	}

	public void death (){
		this.visitCount = 0;

		MoveToRoom (MainMenuRoom);
	}

	void MoveToBattleRoom(){
		MoveToRoom (BattleScreen);
	}

	void ShowResources(){
		Say ("Fuel: " + playerOne.fuel + "\nMetal: " + playerOne.metal + "\nRock Candy: " + playerOne.rock + "\nFish: " + playerOne.fish + "\nMissiles: " + playerOne.missiles);

		MoveToRoom (this);
	}

	void FlightPath(){
		AddOption ("1", ChangeXCoords (1));
		AddOption ("2", ChangeXCoords (2));
		AddOption ("3", ChangeXCoords (3));
		AddOption ("4", ChangeXCoords (4));
		AddOption ("5", ChangeXCoords (5));
		AddOption ("6", ChangeXCoords (6));
		AddOption ("7", ChangeXCoords (7));
		AddOption ("8", ChangeXCoords (8));

		Say ("Currently at: (" + playerOne.position.x + " , " + playerOne.position.y + " )");

		MoveToRoom (this);
	}

	void ChangeXCoords(int x){
		Say ("Coordinate changed ");
	}
}
