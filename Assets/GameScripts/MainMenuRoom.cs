using UnityEngine;
using System.Collections;
using Fungus;

public class MainMenuRoom : Room {

	//Allows Fungus to transfer to this room representation in code.
	public Cockpit Cockpit;


	void OnEnter(){
		//Main menu screen
		Wait (1);
		//AddOption("New Game", MoveToNewGame);
		AddOption("Random Map Mode", MoveToRandomGame);
		AddOption("Exit", ExitGame);
		Choose ("Choose your destiny!");
	}
	
	void OnLeave(){
		

	}

	//Initializes the player and game stats and starts the game.
	void MoveToNewGame(){
		Cockpit.playerOne.initialize ();
		Cockpit.startFlight = false;
		Cockpit.stillFlying = false;
		Cockpit.Initialise();
		MoveToRoom(Cockpit);
	}

	void MoveToRandomGame(){
		Cockpit.randomLevels = true;
		Cockpit.playerOne.initialize ();
		Cockpit.startFlight = false;
		Cockpit.stillFlying = false;
		Cockpit.Initialise();
	}

	//Quits the game
	void ExitGame(){
		Application.Quit();
	}
}
