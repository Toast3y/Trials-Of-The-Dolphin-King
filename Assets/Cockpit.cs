using UnityEngine;
using System.Collections;
using Fungus;

public class Cockpit : Room {

	public Room MainMenuRoom;

	public bool GameOver;

	// Use this for initialization
	void Start () {
		if (this.visitCount == 0) {
			GameOver = false;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnEnter(){
		Wait (1);



			AddOption ("Make a Flight", DoNothing);
			AddOption ("Event Interact", DoNothing);
			AddOption ("Do things!", DoNothing);

			Choose ("");


	}

	void DoNothing(){
		MoveToRoom (MainMenuRoom);

	}
}
