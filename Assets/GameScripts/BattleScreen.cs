﻿using UnityEngine;
using System.Collections;
using Fungus;

public class BattleScreen : Room
{

    public Cockpit Cockpit;
    public MainMenuRoom MainMenuRoom;

    //determine enemy
    public Enemy fight = new Enemy();

    //bools for the end
    public bool end = false;
    public bool win = false;
    public bool lose = false;
    public bool flee = false;
    public bool cry = false;

    public bool opt1 = false;
    public bool opt2 = false;
    public bool opt3 = false;
    public bool opt4 = false;

    //Required for calculating speed
    public int pspeed;
    public int espeed;
    public bool fast = false;
    


    //start of combat text and speed calculation
    void OnEnter()
    {

        Wait(1);
        //determine enemy type
        //fight intro
        Say("You encountered a " + fight.Name + "\nShields: " + fight.Health + "\nEngine: " + fight.Engine);
        Say("Your stats:\nShields: " + Cockpit.playerOne.shields + "\nMissiles: " + Cockpit.playerOne.missiles + "\nEngine: " + Cockpit.playerOne.engine);

        //calculate turn order
        pspeed = (Cockpit.playerOne.engine * 20) + Random.Range(0, 101);
        espeed = (fight.Engine * 20) + Random.Range(0, 101);

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

        AddOption("Start combat", decideAttack);
        Choose("");
    }


    // Use this for initialization
    void Start()
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
                fight.Metal = Random.Range(6, 9);
                fight.Fish = Random.Range(1, 3);
                fight.Attack = 0;
                break;
            case 1:
                fight.Name = "Vogon Cruiser";
                fight.Health = 15;
                fight.Engine = 2;
                fight.Metal = Random.Range(8, 13);
                fight.Fish = Random.Range(2, 5);
                fight.Attack = 1;
                break;
            case 2:
                fight.Name = "Vogon Battleship";
                fight.Health = 20;
                fight.Engine = 2;
                fight.Metal = Random.Range(12, 19);
                fight.Fish = Random.Range(4, 7);
                fight.Attack = 2;
                break;
            case 3:
                fight.Name = "Vogon Capital Ship";
                fight.Health = 25;
                fight.Engine = 3;
                fight.Metal = Random.Range(15, 26);
                fight.Fish = Random.Range(5, 8);
                fight.Attack = 3;
                break;
            case 4:
                fight.Name = "Space Orca";
                fight.Health = 100;
                fight.Engine = 5;
                fight.Metal = 0;
                fight.Fish = 90;
                fight.Attack = 4;
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

    //lasers selected
    void option1()
    {
        opt1 = true;
        opt2 = false;
        opt3 = false;
        opt4 = false;
        Turn();
    }

    //missles selected
    void option2()
    {
        //check if any missles remain
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

    //dolphin cry selected
    void option3()
    {
        // check if player already dolphin cried
        if (cry)
        {
            Say("we already did that. We already scrambled their systems, remember? It was like a few seconds ago.");
            decideAttack();
        }
        opt1 = false;
        opt2 = false;
        opt3 = true;
        opt4 = false;
        Turn();
    }

    //option to flee
    void option4()
    {
        opt1 = false;
        opt2 = false;
        opt3 = false;
        opt4 = true;
        Turn();
    }

    //check to see who acts during this turn
    //check bool flags to see which action has been selected
    //go to method of selected action
    //go to enemy method
    void Turn()
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





    //method to calculate firing lasers
    //roll to hit with lasers
    //either miss or resolve damage
    //determine if enemy is dead or not
    void lazers()
    {
        int shoot = Random.Range(0, 101);
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

    //method for calculating missle damage
    //resolve damage then check if enemy is dead or not
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

    //method for resolving dolphin cry
    //check bool flag cry to reduce enemy accuracy til the end of the battle
    void dolphin()
    {
        Say("You used the dolphin cry!");
        cry = true;
        Say("Their systems have been scrambled!");
        
    }

    //method for resolving attempting to run away
    //roll to run
    //either end or continue battle
    void run()
    {
        Say("You attempt to run away!");
        //test to runaway
        int prun = (Cockpit.playerOne.engine * 20) + Random.Range(0, 101);
        int erun = (fight.Engine * 20) + Random.Range(0, 101);
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



    //method for the end of a battle
    //resolve whether the player won, lost or flee
    //if win, reward player and return
    //if lost, bring to game over scree
    //if flee, return to the cockpit screen
    void End()
    {
        cry = false;
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


    //--------------------------------------------------Below this point is all enemy actions. You have been warned ----------------------------------------------//
    //reads in the type of enemy and goes to a method containing each of their actions
    void enemyturn()
    {
        if (fight.Attack == 0)
        {
            Attack0();
        }
        if (fight.Attack == 1)
        {
            Attack1();
        }
        if (fight.Attack == 2)
        {
            Attack2();
        }
        if (fight.Attack == 3)
        {
            Attack3();
        }
        if (fight.Attack == 4)
        {
            Attack4();
        }
    }

    //below are all the different types of enemies and the randomised actions they can take each turn.
    //at the start of their turn, a number between 1 and 100 is generated to determine which atcion they take.

    //Mook Wing
    //attack A: Hail of lazers
    void Attack0()
    {
        int Acc = 75;
        if (cry)
        {
            Acc = Acc - 30;
        }
        int shoot = Random.Range(0, 101);
        int damage = Random.Range(3, 7);
        Say("They fire a hail of lazers!");
        if (shoot < Acc)
        {
            Say("They hit!");
            Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

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

    //Cruiser
    //attack A: Focused fire
    //attack B: Barrage fire
    void Attack1()
    {
        int choose = Random.Range(0, 101);

        //possible Attack A
        if (choose > 70)
        {
            int Acc = 90;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(6, 10);
            Say("They focus their fire!");
            if (shoot < Acc)
            {
                Say("They hit!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
                }

                Say("You are down to " + Cockpit.playerOne.shields + " shields");
                //damage
            }
            else
            {
                Say("They missed!");
            }
        }
        //Possible Attack B
        if(choose <= 70)
        {
            int Acc = 80;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(4, 9);
            Say("They fire a barrage of lazers!");
            if (shoot < Acc)
            {
                Say("They hit!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
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

    //Battleship
    //Attack A: launch missle
    //attack B: autocannons
    //attack C: lasers
    void Attack2()
    {
        int choose = Random.Range(0, 101);
        //possible attack A
        if (choose > 95)
        {
            
            int damage = 15;
            Say("They launched a missile at us!");
            Say("They hit!");
            Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

            if (Cockpit.playerOne.shields <= 0)
            {
                lose = true;
                End();
            }

            Say("You are down to " + Cockpit.playerOne.shields + " shields");
            //damage
        }
        //possible attack B
        if (choose < 95 && choose > 60)
        {
            int Acc = 80;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(6, 11);
            Say("They fire their main autocannons!");
            if (shoot < Acc)
            {
                Say("They hit!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
                }

                Say("You are down to " + Cockpit.playerOne.shields + " shields");
                //damage
            }
            else
            {
                Say("They missed!");
            }
        }
        //possible attack C
        if (choose <= 60)
        {
            int Acc = 85;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(5, 10);
            Say("They fire a storm of lazers at us!");
            if (shoot < Acc)
            {
                Say("They hit!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
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

    //Vogon Capital
    //attack A: missle
    //attack B: torpedoes
    //attack C: lasers
    //attack D: tractor beam
    //attack E: self-repair
    void Attack3()
    {
        int choose = Random.Range(0, 101);
        //possible Attack A
        if (choose > 90)
        {
            int damage = 15;
            Say("They launched a missile at us!");
            Say("They hit!");
            Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

            if (Cockpit.playerOne.shields <= 0)
            {
                lose = true;
                End();
            }

            Say("You are down to " + Cockpit.playerOne.shields + " shields");
            //damage
        }

        //possible Attack B
        if (choose < 90 && choose > 75)
        {
            int Acc = 80;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(8, 13);
            Say("They fired a barrage of torpedos at us!");
            if (shoot < Acc)
            {
                Say("They hit!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
                }

                Say("You are down to " + Cockpit.playerOne.shields + " shields");
                //damage
            }
        }

        //possible Attack C
        if (choose < 75 && choose > 45)
        {
            int Acc = 90;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(6, 11);
            Say("They fired all of their lazers at us!");
            if (shoot < Acc)
            {
                Say("They hit!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
                }

                Say("You are down to " + Cockpit.playerOne.shields + " shields");
                //damage
            }
            else
            {
                Say("They missed!");
            }
        }

        //possible Attack D
        if (choose < 45 && choose > 35)
        {
            int Acc = 85;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            Say("The fired their tractor beam at us!");
            if (shoot < Acc)
            {
                Say("They caught us in the tractor beam! Escape is impossible now!");
                fight.Engine = fight.Engine * 10;
            }
            else
            {
                Say("They missed!");
            }
        }

        //possible Attack E
        if (choose <= 35)
        {
            int repair = Random.Range(5, 11);
            Say("They dispatched repair teams!");
            fight.Health = fight.Health + repair;
            Say("They repaired themselves back up to " + fight.Health + " Shields!");
        }

    }

    //spaceOrca
    //attack A: attempt bite
    //attack B: Orca roar
    //attack C: laser
    //attack D: swing tail
    void Attack4()
    {
        int choose = Random.Range(0, 101);
        //possible attack A
        if (choose > 95)
        {
            int damage = 9999;
            int bite = Random.Range(0, 101);
            int escape = (Random.Range(0, 101) + (Cockpit.playerOne.engine * 20));
            Say("The Orca is attempting to bite the ship!");
            if (bite > escape)
            {
                Say("The Orca's mouth closes around the hull of the ship, causing collosal damage!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
                }
            }
            else
            {
                Say("We jumped out of it's way at the last second, saving ourselves from certain death!");
            }
        }
        //possoble attack B
        if (choose < 95 && choose > 50)
        {
            int Acc = 70;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(6, 11);
            Say("The lets out a mighty roar!");
            if (shoot < Acc)
            {
                Say("It hit! Not only that, but the roar has messed with our ships engine!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;
                Cockpit.playerOne.engine = Cockpit.playerOne.engine - 1;

                if (Cockpit.playerOne.engine <= 0)
                {
                    Cockpit.playerOne.engine = 0;
                }

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
                }

                Say("You are down to " + Cockpit.playerOne.shields + " shields, and our engine is down to level " + Cockpit.playerOne.engine + "!");
                //damage
            }
            else
            {
                Say("It missed!");
            }
        }
        //possible attack C
        if (choose < 50 && choose > 20)
        {
            int Acc = 95;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(10, 17);
            Say("The Orca fires a lazer from it's mouth!");
            if (shoot < Acc)
            {
                Say("It hit!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
                }

                Say("You are down to " + Cockpit.playerOne.shields + " shields");
                //damage
            }
            else
            {
                Say("It missed!");
            }
        }
        //possible attack D
        if (choose <= 20)
        {
            int Acc = 50;
            if (cry)
            {
                Acc = Acc - 30;
            }
            int shoot = Random.Range(0, 101);
            int damage = Random.Range(12, 19);
            Say("The Orca swings it's tail at the ship!");
            if (shoot < Acc)
            {
                Say("It hit!");
                Cockpit.playerOne.shields = Cockpit.playerOne.shields - damage;

                if (Cockpit.playerOne.shields <= 0)
                {
                    lose = true;
                    End();
                }

                Say("You are down to " + Cockpit.playerOne.shields + " shields");
                //damage
            }
            else
            {
                Say("It missed!");
            }
        }
    }
}
