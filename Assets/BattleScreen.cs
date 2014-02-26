using UnityEngine;
using System.Collections;
using Fungus;

public class BattleScreen : Room 
{

	public Room Cockpit;
    public Enemy fight = new Weakling();


	void OnEnter()
    {
		Wait (3);
		Say ("This is fucked up");
        //public Enemy fight = new Weakling();
        Say("You encountered a " + fight.Name);
		MoveToRoom (Cockpit);
	}


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
