using UnityEngine;
using System.Collections;
using Fungus;

public class Cockpit : Room {
	
	public Player playerOne = new Player();
	
	public MainMenuRoom MainMenuRoom;
	
	public BattleScreen BattleScreen;
	
	public FlightScreen FlightScreen;
	
	public int xCoordChange;
	public int yCoordChange;

	public bool startFlight;
	public bool stillFlying;
	public bool gameOver;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnEnter(){
		if (this.visitCount == 0) {
			playerOne.initialize();
		}

		if (this.startFlight) {
			InFlight ();
		}

		BattleScreen.chooseEncounter (0);
		
		Wait (1);
		
		AddOption ("Make a Flight", FlightPath);
		AddOption ("Event Interact", MoveToBattleRoom);
		AddOption ("View Resources", ShowResources);
		
		Choose ("Currently at: ( " + playerOne.position.x + " , " + playerOne.position.y + " )");
	}
	
	public void death (){
		this.visitCount = 0;
		playerOne.initialize ();
		startFlight = false;
		stillFlying = false;
		
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
		MoveToRoom (FlightScreen);
	}

	void InFlight(){
		startFlight = false;
		stillFlying = true;
		//Say ("You are currently in flight. Currently at ( " + playerOne.position.x + " , " + playerOne.position.y + " )");

		if (playerOne.fuel == 0) {
			Say ("Oh dear, you seem to have run out of fuel!");
			Say ("It's only a matter of time before the Vogon Fleet finds you and arrests you for blatant defiance of red tape. Game Over!");
			death ();
		}

		//Move coords and check if you're there.
		if (playerOne.position.x != xCoordChange) {
			//checks whether to increment or decrement first
			if (playerOne.position.x < xCoordChange) {
				playerOne.position.x++;
				playerOne.fuel--;
			} else if (playerOne.position.x > xCoordChange) {
				playerOne.position.x--;
				playerOne.fuel--;
			}
		}
		else if (playerOne.position.y != yCoordChange) {
			//checks whether to increment or decrement first
			if (playerOne.position.y < yCoordChange) {
				playerOne.position.y++;
				playerOne.fuel--;
			} else if (playerOne.position.y > yCoordChange) {
				playerOne.position.y--;
				playerOne.fuel--;
			}
		}

		if ((playerOne.position.x == xCoordChange) && (playerOne.position.y == yCoordChange)) {
			stillFlying = false;
		} 

		//Add battle chance code here.



		if (!stillFlying) {
			Say ("Now at destination. Have a safe, and productive, day.");
			MoveToRoom (this);
		}
		else {
			InFlight ();
		}
	}
}
