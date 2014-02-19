using UnityEngine;
using System.Collections;
using Fungus;

public class MainMenuRoom : Room {



	void OnEnter(){
		Wait (1);
		AddOption("New Game", MoveToNewGame);
		AddOption("Exit", ExitGame);
		Choose ("Choose your destiny!");
	}
	
	void Onleave(){


	}

	void MoveToNewGame(){


	}

	void ExitGame(){
		Application.Quit();
	}
}
