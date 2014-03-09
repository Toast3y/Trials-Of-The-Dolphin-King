using UnityEngine;
using System.Collections;
using Fungus;

public class Cockpit : Room {
	
	public Player playerOne = new Player();
	
	public MainMenuRoom MainMenuRoom;
	
	public BattleScreen BattleScreen;
	
	public FlightScreen FlightScreen;

	levelOne LevelOne = new levelOne();
	
	public int xCoordChange;
	public int yCoordChange;

	public int battleChance = 5;


	public bool startFlight;
	public bool stillFlying;
	public bool EventFlag;
	public bool gameOver;
	
	// Use this for initialization
	public void Start () {
		LevelOne.Start(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnEnter(){

		if (this.startFlight) {
			InFlight ();
		} else if (this.EventFlag) {
			if (playerOne.levelOne){
				EventFlag = false;
				LevelOne.CallEvent((int)playerOne.position.x, (int)playerOne.position.y);
				Say ("You are at level 1");
			}
			else if (playerOne.levelTwo){
				EventFlag = false;
				//LevelTwo.CallEvent();
				Say ("You are at level 2");
			}
			else if (playerOne.levelThree){
				EventFlag = false;
				//LevelThree.CallEvent();
				Say ("You are at level 3");
			}
		}



		//if (this.visitCount == 0) {
		//	BattleScreen.chooseEncounter (4);
		//}
		
		//Wait (1);
		
		AddOption ("Make a Flight", FlightPath);
		AddOption ("Event Interact", TriggerEvent);
		AddOption ("View Resources", ShowResources);
		
		Choose ("Currently at: ( " + playerOne.position.x + " , " + playerOne.position.y + " )");
	}
	
	public void death (){
		this.visitCount = 0;
		playerOne.initialize ();
		startFlight = false;
		stillFlying = false;
		EventFlag = false;

		
		MoveToRoom (MainMenuRoom);
	}
	
	void TriggerEvent(){
		EventFlag = true;
		MoveToRoom (this);
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
		EventFlag = true;
		//Say ("You are currently in flight. Currently at ( " + playerOne.position.x + " , " + playerOne.position.y + " )");

		Wait (1);

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
		if (Random.Range(1, 100) < battleChance) {
			Say ("Sir, a Vogon ship appears to be chasing us!");

			AddOption ("Ready for battle!", ReadyBattle);
			AddOption ("Lets try to escape!", RunAway);

			Choose ("What will we do sir?");
		}

		battleChance += 5;

		if (!stillFlying) {
			Say ("Now at destination. Have a safe, and productive, day.");
			EventFlag = true;
			MoveToRoom (this);
		}
		else {
			InFlight ();
		}
	}

	void RunAway(){

		if (Random.Range(1, 100) < 25) {
			Say ("We appear to have lost them sir. Continuing on course.");
			battleChance += 5;
			InFlight ();
		} else {
			stillFlying = false;
			Say ("They're too fast! Prepare for battle!");
			battleChance = 5;

			xCoordChange = (int)playerOne.position.x;
			yCoordChange = (int)playerOne.position.y;

			BattleScreen.chooseEncounter(Random.Range(0, 1));
		}
	}

	void ReadyBattle(){
		stillFlying = false;
		Say ("Alright sir, lets show these Vogons the might of the Dolphins!");

		xCoordChange = (int)playerOne.position.x;
		yCoordChange = (int)playerOne.position.y;

		battleChance = 5;
		BattleScreen.chooseEncounter(Random.Range(0, 1));
	}
}
