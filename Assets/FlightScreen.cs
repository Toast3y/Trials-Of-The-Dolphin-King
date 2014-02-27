using UnityEngine;
using System.Collections;
using Fungus;

public class FlightScreen : Room {

	public Room Cockpit;

	void OnEnter(){

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MoveToCoordinates(){
		MoveToRoom (Cockpit);
	}
}
