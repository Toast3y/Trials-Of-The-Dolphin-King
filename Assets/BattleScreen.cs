using UnityEngine;
using System.Collections;
using Fungus;

public class BattleScreen : Room 
{

	public Cockpit Cockpit;

    //determine enemy
    //public int encounter = 1;
    public Enemy fight = new Stomper();
    //public Player playerOne = new Player();

    //bools for the end
    public bool end = false;
    public bool win = false;
    public bool lose = false;
    public bool flee = false;

    //Required for calculating speed
    public int pspeed;
    public int espeed;
    public bool fast = false;
    //public int turn = 0;

    /*public int hp = playerOne.shields;
    public int ehp = fight.Health;*/



	void OnEnter()
    {
        
		Wait (3);
		Say ("What?\nYou were ambushed!");
        //determine enemy type
        //determine(encounter, fight);
        //fight intro
        Say("You encountered a " + fight.Name + "\nShields: " + fight.Health + "\nEngine: " + fight.Engine);
        Say("Your stats:\nShields: " + Cockpit.playerOne.shields + "\nMissiles: " + Cockpit.playerOne.missiles + "\nEngine: " + Cockpit.playerOne.engine);

        //calculate turn order
        pspeed = (Cockpit.playerOne.engine * 20) + Random.Range(0, 100);
        espeed = (fight.Engine * 20) + Random.Range(0, 100);

        if (pspeed > espeed)
        {
            fast = true;
        }


        //state turn order
        if (fast)
        {
            Say("You outsped them!");
        }
        else
        {
            Say("They outsped you!");
        }
        //AddOption("Start the fight!", Start);
        //Choose("");

        AddOption("Start combat", Update);
        Choose("");
	}


	// Use this for initialization
	void Start ()
    {
        
	}



    public void chooseEncounter(int encounter)
    {
        switch (encounter)
        {
            case 0:
                {
                    Enemy fight = new Weakling();
                    break;
                }
            case 1:
                {
                    Enemy fight = new Stomper();
                    break;
                }
            case 2:
                {
                    Enemy fight = new SpaceOrca();
                    break;
                }
            case 3:
                {
                    break;
                }
            case 4:
                {
                    break;
                }
        }


        MoveToScreen(this);
    }

	


	// Update is called once per frame
	void Update ()
    {
        end = false;
        if (fast)
        {
            //your turn options
            AddOption("Fire the lazers!", lazers);
            AddOption("Launch a missle!", missles);
            AddOption("Dolphin cry!", dolphin);
            AddOption("Run away!", run);
            Choose("");
        }
        //enemy turn but only if the game isn't over
        if (!end)
        {
            enemyturn();
        }
        if (!fast && !end)
        {
            //your turn options
            AddOption("Fire the lazers!", lazers);
            AddOption("Launch a missle!", missles);
            AddOption("Dolphin cry!", dolphin);
            AddOption("Run away!", run);
            Choose("");
        }
        if (end)
        {
            AddOption("The fight is over", End);
            Choose("");
        }
        
        //MoveToRoom(Cockpit);
	    //this is where turns will be carried out
	}






    void lazers()
    {
        int shoot = Random.Range(0, 100);
        Say("You fired the lasers!");
        if (shoot < 80)
        {
            Say("You hit them with your lasers!");
            //calculate damage
            fight.Health = fight.Health - 5;
            if (fight.Health == 0)
            {
                end = true;
                win = true;
            }
            else
            {
                Say("Enemy is at " + fight.Health + "hp!");
            }
        }
        else
        {
            Say("You missed!");
        }
    }

    void missles()
    {
        Say("You fired the missles!");
        //calculate damage
        fight.Health = fight.Health - 25;
        if (fight.Health == 0)
        {
            end = true;
            win = true;
        }
        else
        {
            Say("Enemy is at " + fight.Health + "hp!");
        }
    }

    void dolphin()
    {
        Say("You used the dolphin cry!");
        //calculate accuracy damage
        fight.Acc = fight.Acc - 30;
        if (fight.Acc == 0)
        {
            fight.Acc = 1;
        }
    }

    void run()
    {
        Say("You attempt to run away!");
        //test to runaway
        int prun = (Cockpit.playerOne.engine * 20) + Random.Range(0, 100);
        int erun = (fight.Engine * 20) + Random.Range(0, 100);
        if (prun > erun)
        {
            Say("You escaped the combat!");
            end = true;
            flee = true;
        }
        else
        {
            Say("You couldn't escape!");
        }
    }




    void End()
    {
        if (win)
        {
            Say("You defeated the " + fight.Name);
            //reward
            MoveToRoom(Cockpit);
        }

        if (lose)
        {
            Say("Your ship was destroyed!");
            //gameover
            MoveToRoom(Cockpit);
        }

        if (flee)
        {
            Say("You escape the " + fight.Name);
            MoveToRoom(Cockpit);
        }
    }




    void enemyturn()
    {
        int shoot = Random.Range(0, 100);
        Say("They attack!");
        if (shoot < fight.Acc)
        {
            Say("They hit!");
            //Cockpit.playerOne.shields = Cockpit.playerOne.shields - fight.Lazerdam;
            //Say("You are down to " + Cockpit.playerOne.shields + " shields");
            //damage
        }
        else
        {
            Say("they missed!");
        }
    }
}
