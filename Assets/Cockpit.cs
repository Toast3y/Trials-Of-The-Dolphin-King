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
		
		Wait (1);
		
		AddOption ("Make a Flight", FlightPath);
		AddOption ("Event Interact", MoveToBattleRoom);
		AddOption ("View Resources", ShowResources);
		
		Choose ("Currently at: ( " + playerOne.position.x + " , " + playerOne.position.y + " )");
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
		MoveToRoom (FlightScreen);
	}

	void InFlight(){
		startFlight = false;
		Say ("You are now in flight");
		MoveToRoom (this);
	}
}
