using UnityEngine;
using System.Collections;
using Fungus;

public class BattleScreen : Room {

	public Room Cockpit;


	void OnEnter(){
		Wait (3);
		Say ("This is fucked up");
		MoveToRoom (Cockpit);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
