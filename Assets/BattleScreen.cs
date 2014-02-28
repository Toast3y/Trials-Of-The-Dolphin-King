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
    public bool end = false;

    //Required for calculating speed
    public int pspeed;
    public int espeed;
    public bool fast = false;

    /*public int hp = playerOne.shields;
    public int ehp = fight.Health;*/



	void OnEnter()
    {
        
		Wait (3);
		Say ("What?\nYou were ambushed!");
        Say("You encountered a " + fight.Name + "\nShields: " + fight.Health + "\nFuel: " + fight.Engine + "\nMissles: " + fight.Missles );
        Say("Your stats:\nHP: " + playerOne.shields + "\nMissiles: " + playerOne.missiles + "\nEngine: " + playerOne.engine);

        //calculate turn order
        pspeed = (playerOne.engine * 20) + Random.Range(0, 100);
        espeed = (fight.Engine * 20) + Random.Range(0, 100);

        if (pspeed > espeed)
        {
            fast = true;
        }
        AddOption("Start the fight!", Start);
        Choose("");
	}


	// Use this for initialization
	void Start ()
    {
        //placeholder
        Say("Successfully moved to start");

        //state turn order
        if(fast)
        {
            Say("You outsped them!");
        }
        else
        {
            Say("They outsped you!");
        }

        if (fast)
        {
            //your turn options
            AddOption("Fire the lazers!", lazers);
            AddOption("Launch a missle!", missles);
            AddOption("Dolphin cry!", dolphin);
            AddOption("Run away!", run);
            Choose("");
        }
        //enemy turn
        if (!fast)
        {
            //your turn options
            AddOption("Fire the lazers!", lazers);
            AddOption("Launch a missle!", missles);
            AddOption("Dolphin cry!", dolphin);
            AddOption("Run away!", run);
            Choose("");
        }
        MoveToRoom(Cockpit);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    //this is where turns will be carried out
	}

    void lazers()
    {
        int roll = Random.Range(0, 100);
        Say("You fired the lasers!");
        if (roll > 80)
        {
            Say("You hit them with your lasers!");
            //calculate damage
        }
        else
        {
            Say("You missed!");
        }
        //return
        MoveToRoom(Cockpit);
    }

    void missles()
    {
        Say("You fired the missles!");
        //calculate damage
        MoveToRoom(Cockpit);
    }

    void dolphin()
    {
        Say("You used the dolphin cry!");
        //calculate accuracy damage
        MoveToRoom(Cockpit);
    }

    void run()
    {
        Say("You attempt to run away!");
        //test to runaway
        MoveToRoom(Cockpit);
    }

    void End()
    {
        //if win

        //if loss

        //if run
    }
}
