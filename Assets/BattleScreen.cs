using UnityEngine;
using System.Collections;
using Fungus;

public class BattleScreen : Room 
{

	public Room Cockpit;

    //determine enemy
    public int encounter = 1;
    public Enemy fight = new Stomper();
    public Player playerOne = new Player();
    //playerOne.initialize();

    /*public int hp = playerOne.shields;
    public int ehp = fight.Health;*/



	void OnEnter()
    {
        
		Wait (3);
		Say ("What?\nYou were ambushed!");
        //public Enemy fight = new Weakling();
        Say("You encountered a " + fight.Name + "\nShields: " + fight.Health + "\nFuel: " + fight.Engine + "\nMissles: " + fight.Missles );
        Say("Your stats:\nHP: "+ playerOne.shields + "\nMissiles: " + playerOne.missiles);
        AddOption("Start the fight!", Start);
        Choose("");
	}


	// Use this for initialization
	void Start ()
    {
        //placeholder
        Say("Successfully moved to start");
        AddOption("Fire the lazers!", lazers);
        AddOption("Launch a missle!", missles);
        AddOption("Dolphin cry!", dolphin);
        AddOption("Run away!", run);
        Choose("");
        MoveToRoom(Cockpit);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    //this is where turns will be carried out
	}

    void lazers()
    {
        Say("+No limited ammo\n-not 100% accurate\n-lower damage");
        MoveToRoom(Cockpit);
    }

    void missles()
    {
        Say("+100% accurate\n+more damaging than lazers ever will be\n-limited ammo");
        MoveToRoom(Cockpit);
    }

    void dolphin()
    {
        Say("+lowers enemy accuracy\n-non-damaging");
        MoveToRoom(Cockpit);
    }

    void run()
    {
        Say("+You run away\n-You run away");
        MoveToRoom(Cockpit);
    }
}
