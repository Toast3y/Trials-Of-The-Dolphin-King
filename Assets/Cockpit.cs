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


	void DoNothing(){
		//Method does nothing
		return;
	}


	void FlightPath(){
		AddOption ("1", DoNothing);
		AddOption ("2", DoNothing);
		AddOption ("3", DoNothing);
		AddOption ("4", DoNothing);
		AddOption ("5", DoNothing);
		AddOption ("6", DoNothing);
		AddOption ("7", DoNothing);
		AddOption ("8", DoNothing);

		Choose ("Currently at: (" + playerOne.position.x + " , " + playerOne.position.y + " )");

		MoveToRoom (this);
	}

	//void ChangeXCoords(int x){
	//	Say ("Coordinate changed ");
	//}
}
