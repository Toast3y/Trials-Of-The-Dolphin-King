using UnityEngine;
using System.Collections;
using Fungus;

public class MainMenuRoom : Room {

	public Room Cockpit;

	void OnEnter(){
		Wait (1);
		AddOption("New Game", MoveToNewGame);
		AddOption("Exit", ExitGame);
		Choose ("Choose your destiny!");
	}
	
	void OnLeave(){


	}

	void MoveToNewGame(){

		MoveToRoom(Cockpit);
	}

	void ExitGame(){
		Application.Quit();
	}
}
