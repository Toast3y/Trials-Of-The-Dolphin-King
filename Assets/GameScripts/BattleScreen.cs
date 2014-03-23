using UnityEngine;
using System.Collections;
using Fungus;

public class BattleScreen : Room 
{

	public Cockpit Cockpit;
	public MainMenuRoom MainMenuRoom;

    //determine enemy
    //public int encounter = 1;
    public Enemy fight = new Enemy();
    //public Player playerOne = new Player();

    //bools for the end
    public bool end = false;
    public bool win = false;
    public bool lose = false;
    public bool flee = false;

    public bool opt1 = false;
    public bool opt2 = false;
    public bool opt3 = false;
    public bool opt4 = false;

    //Required for calculating speed
    public int pspeed;
    public int espeed;
    public bool fast = false;
    //public int turn = 0;

    /*public int hp = playerOne.shields;
    public int ehp = fight.Health;*/


    //start of combat text and speed calculation
	void OnEnter()
    {
        
		Wait (1);
		//Say ("What?\nYou were ambushed!");
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

        AddOption("Start combat", decideAttack);
        Choose("");
	}


	// Use this for initialization
	void Start ()
    {
        
	}


    //loading in the type of enemy to be encountered
    public void chooseEncounter(int encounter)
    {
        switch (encounter)
        {
            case 0:
				fight.Name = "Mook Wing";
				fight.Health = 10;
				fight.Engine = 1;
                fight.Lazerdam = Random.Range(3, 6);
				fight.Acc = 75;
                fight.Metal = Random.Range(6, 8);
                fight.Fish = Random.Range(1, 2);
                break;
            case 1:
				fight.Name = "Vogon Cruiser";
				fight.Health = 15;
				fight.Engine = 2;
                fight.Lazerdam = Random.Range(4, 8);
				fight.Acc = 80;
                fight.Metal = Random.Range(8, 12);
                fight.Fish = Random.Range(2, 4);
                break;
            case 2:
				fight.Name = "Vogon Battleship";
				fight.Health = 20;
				fight.Engine = 2;
                fight.Lazerdam = Random.Range(5, 9);
				fight.Acc = 85;
                fight.Metal = Random.Range(12, 18);
                fight.Fish = Random.Range(4, 6);
                break;
            case 3:
                fight.Name = "Vogon Capital Ship";
				fight.Health = 25;
				fight.Engine = 3;
                fight.Lazerdam = Random.Range(6, 12);
				fight.Acc = 90;
                fight.Metal = Random.Range(15, 25);
                fight.Fish = Random.Range(5, 7);
                break;
            case 4:
                fight.Name = "Space Orca";
                fight.Health = 100;
                fight.Engine = 5;
                fight.Lazerdam = 10;
                fight.Acc = 60;
                fight.Metal = 0;
                fight.Fish = 90;
                break;
            
        }


        MoveToRoom(this);
    }

    //start of combat, pick an action
    void decideAttack()
    {
        opt1 = false;
        opt2 = false;
        opt3 = false;
        opt4 = false;
        //your turn options
        AddOption("Fire the lasers!", option1);
        AddOption("Launch a missile!", option2);
        AddOption("Dolphin cry!", option3);
        AddOption("Run away!", option4);
        Choose("");
    }

    void option1()
    {
        opt1 = true;
        opt2 = false;
        opt3 = false;
        opt4 = false;
        Turn();
    }

    void option2()
    {
        if (Cockpit.playerOne.missiles <= 0)
        {
            Say("Sorry sir, we're out of missiles");
            decideAttack();
        }
        opt1 = false;
        opt2 = true;
        opt3 = false;
        opt4 = false;
        Turn();
    }

    void option3()
    {
        opt1 = false;
        opt2 = false;
        opt3 = true;
        opt4 = false;
        Turn();
    }

    void option4()
    {
        opt1 = false;
        opt2 = false;
        opt3 = false;
        opt4 = true;
        Turn();
    }


	void Turn ()
    {
        end = false;
        flee = false;
        win = false;
        lose = false;

        if (fast)
        {
            if (opt1)
            {
                lazers();
            }
            if (opt2)
            {
                missles();
            }
            if (opt3)
            {
                dolphin();
            }
            if (opt4)
            {
                run();
            }
            //your turn options
        }
        //enemy turn but only if the game isn't over
        if (!end)
        {
            enemyturn();
        }
        if (!fast && !end)
        {
            if (opt1)
            {
                lazers();
            }
            if (opt2)
            {
                missles();
            }
            if (opt3)
            {
                dolphin();
            }
            if (opt4)
            {
                run();
            }
            //your turn options
        }

        if (end)
        {
            End();
        }
        else
        {
            decideAttack();
        }
	}






    void lazers()
    {
        int shoot = Random.Range(0, 100);
        Say("You fired the lasers!");
        if (shoot < 80)
        {
            Say("You hit!");
            //calculate damage
            fight.Health = fight.Health - 5;
            if (fight.Health <= 0)
            {
                end = true;
                win = true;
            }
            else
            {
                Say("Enemy is down to " + fight.Health + " shields");
            }
        }
        else
        {
            Say("You missed!");
        }
    }

    void missles()
    {
        Say("You fired a missile!");
        if (Cockpit.playerOne.missiles > 0)
        {
            Cockpit.playerOne.missiles = Cockpit.playerOne.missiles - 1;
        }
        //calculate damage
        fight.Health = fight.Health - 15;
        if (fight.Health <= 0)
        {
            end = true;
            win = true;
        }
        else
        {
            Say("Enemy is down to " + fight.Health + " shields");
        }
    }

    void dolphin()
    {
        Say("You used the dolphin cry!");
        //calculate accuracy damage
        fight.Acc = fight.Acc - 30;
        if (fight.Acc <= 0)
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
            Say("You defeated the " + fight.Name + "!\nRewards:\nMetal: " + fight.Metal + "\nFish: " + fight.Fish);
            Cockpit.playerOne.metal += fight.Metal;
            Cockpit.playerOne.fish += fight.Fish;

            MoveToRoom(Cockpit);
        }

        if (lose)
        {
            Say("Your ship was destroyed. \nWhat a shame.");
            Say("While we drift in space in the escape pod for the rest of your life, please enjoy this endless loop of Vogon Poetry.");
            //gameover
            Cockpit.death();
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
            Cockpit.playerOne.shields = Cockpit.playerOne.shields - fight.Lazerdam;

			if (Cockpit.playerOne.shields <= 0){
				lose = true;
				End ();
			}

            Say("You are down to " + Cockpit.playerOne.shields + " shields");
            //damage
        }
        else
        {
            Say("They missed!");
        }
    }
}
