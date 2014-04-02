using UnityEngine;
using System.Collections;
using Fungus;

public class Cockpit : Room {

	//playerOne holds all relevant stats for the player to use.
	public Player playerOne = new Player();

	//Allows fungus to move to different room views
	public MainMenuRoom MainMenuRoom;
	public BattleScreen BattleScreen;
	public FlightScreen FlightScreen;

	//Stores all the events for the first zone
	levelOne LevelOne = new levelOne();


	//Randomized level flags
	public bool randomLevels;
	LevelRandom levelRandom = new LevelRandom ();

	//Holds coordinated position changes for fuel costs
	public int xCoordChange;
	public int yCoordChange;

	//Holds battle chance percentage
	public int battleChance = 5;

	//Holds bools to determine if you're flying in space, landed on a coordinate or triggered a game over
	public bool startFlight;
	public bool stillFlying;
	public bool EventFlag;
	public bool gameOver;

	//Start is not used
	void Start(){
	}
	
	// Use this for initialization
	public void Initialise () {
		if (randomLevels == false) {
			LevelOne.Initialise (this);
		} else if (randomLevels == true) {
			levelRandom.Initialise(this);
		}
	}
	
	// Update is called once per frame
	//Update is not used, but is kept for legacy purposes
	void Update () {
		
	}


	//Main entry point of scripted area in game
	void OnEnter(){

		//Checks if the player is flying in space or about to trigger an event
		if (this.startFlight) {
			//If starting a flight, loops into flight time
			InFlight ();
		} else if (this.EventFlag) {
			//Otherwise, if entering a coordinate, calls an event based on position and level.

			if (randomLevels){
				EventFlag = false;
				levelRandom.checkEvent((int)playerOne.position.x, (int)playerOne.position.y);
			}else if (!randomLevels){
				if (playerOne.levelOne){
					EventFlag = false;
					LevelOne.CallEvent((int)playerOne.position.x, (int)playerOne.position.y);
					//Say ("You are at level 1");
				}
				else if (playerOne.levelTwo){
					EventFlag = false;
					//LevelTwo.CallEvent();
					//Say ("You are at level 2");
				}
				else if (playerOne.levelThree){
					EventFlag = false;
					//LevelThree.CallEvent();
					//Say ("You are at level 3");
				}
			}
		}
		

		//Otherwise, lets you choose one of three options from the Cockpit
		AddOption ("Make a Flight", FlightPath);
		AddOption ("Event Interact", TriggerEvent);
		AddOption ("View Resources", ShowResources);
		
		Choose ("Currently at: ( " + playerOne.position.x + " , " + playerOne.position.y + " )");
	}

	//De-initialises all player variables and wipes stats for new game
	public void death (){
		this.visitCount = 0;
		playerOne.initialize ();
		startFlight = false;
		stillFlying = false;
		EventFlag = false;

		
		MoveToRoom (MainMenuRoom);
	}

	//TriggerEvent used for Event Testing purposes
	void TriggerEvent(){
		EventFlag = true;
		MoveToRoom (this);
	}


	//Displays all game resources under your command.
	void ShowResources(){
		Say ("Fuel: " + playerOne.fuel + "\nMetal: " + playerOne.metal + "\nRock Candy: " + playerOne.rock + "\nFish: " + playerOne.fish + "\nMissiles: " + playerOne.missiles);
		
		MoveToRoom (this);
	}
	
	//Does nothing for testing purposes.
	void DoNothing(){
		//Method does nothing
		return;
	}
	

	//Moves to the flightscreen to plot a course through the galaxy
	void FlightPath(){
		MoveToRoom (FlightScreen);
	}


	//Moves the player through the universe
	void InFlight(){
		startFlight = false;
		stillFlying = true;
		EventFlag = true;
		//Say ("You are currently in flight. Currently at ( " + playerOne.position.x + " , " + playerOne.position.y + " )");

		Wait (1);

		//If you run out of fuel mid flight, game over
		if (playerOne.fuel == 0) {
			Say ("Oh dear, you seem to have run out of fuel!");
			Say ("It's only a matter of time before the Vogon Fleet finds you and arrests you for blatant defiance of space travel laws. Game Over!");
			death ();
		}

		//Move coords and check if you're there.
		//Moves through X coordinates first because of Vogon space travel laws.
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

		//Flag triggers to stop the flight if coordinates reached.
		if ((playerOne.position.x == xCoordChange) && (playerOne.position.y == yCoordChange)) {
			stillFlying = false;
		} 
		
		//Gives a random chance to battle an enemy in space.
		if (Random.Range(1, 100) < battleChance) {
			Say ("Sir, a Vogon ship appears to be chasing us!");

			AddOption ("Ready for battle!", ReadyBattle);
			AddOption ("Lets try to escape!", RunAway);

			Choose ("What will we do sir?");
		}

		//If no battle happens, the chance to battle again increases
		battleChance += 5;

		if (!stillFlying) {
			//Moves back to the Cockpit view and triggers the event script
			Say ("Now at destination. Have a safe, and productive, day.");
			EventFlag = true;
			MoveToRoom (this);
		}
		else {
			//Otherwise recursively calls this method again.
			InFlight ();
		}
	}

	void RunAway(){
		//Calculates your chance to run away from a random battle before it begins
		if (Random.Range(1, 100) < 25) {
			Say ("We appear to have lost them sir. Continuing on course.");
			battleChance += 5;
			InFlight ();
		} else {
			//If you fail, moves you to the battle screen, stops the flight and resets the random battle chance
			stillFlying = false;
			Say ("They're too fast! Prepare for battle!");
			battleChance = 5;

			xCoordChange = (int)playerOne.position.x;
			yCoordChange = (int)playerOne.position.y;

			BattleScreen.chooseEncounter(Random.Range(0, 2));
		}
	}

	//Readies you for battle against the random enemy
	void ReadyBattle(){
		stillFlying = false;
		Say ("Alright sir, lets show these Vogons the might of the Dolphins!");

		xCoordChange = (int)playerOne.position.x;
		yCoordChange = (int)playerOne.position.y;

		battleChance = 5;
		BattleScreen.chooseEncounter(Random.Range(0, 2));
	}
}
