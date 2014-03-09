using UnityEngine;
using System.Collections;
using Fungus;

public class MainMenuRoom : Room {
	
	public Cockpit Cockpit;
	
	void OnEnter(){
		Wait (1);
		AddOption("New Game", MoveToNewGame);
		AddOption("Exit", ExitGame);
		Choose ("Choose your destiny!");
	}
	
	void OnLeave(){
		

	}
	
	void MoveToNewGame(){
		Cockpit.playerOne.initialize ();
		Cockpit.startFlight = false;
		Cockpit.stillFlying = false;
		Cockpit.Start();
		MoveToRoom(Cockpit);
	}
	
	void ExitGame(){
		Application.Quit();
	}
}
