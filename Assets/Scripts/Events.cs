/*
  ---TO DO---   
 * Error Checking to make sure player cannot trade more that they have      DONE
 * Modify resource values       DONE
 
 */

using UnityEngine;
using System.Collections;
using Fungus;

public class Events
{
	int TradeTo = 0;
	int TradeFor = 0;

	public Cockpit Cockpit;

    public void TradeMenu()
    {
        
        bool Barter = false;
        bool Leave = false;

        Cockpit.AddOption("Buy Goods", Bartering1);
        Cockpit.AddOption("Leave", Leave);
        Cockpit.Choose("Welcome! Here to trade?");
    }

    public void Bartering1()
    {
        Cockpit.AddOption("Fish", Opt1);
        Cockpit.AddOption("Metal", Opt2);
        Cockpit.AddOption("Rock Candy", Opt3);
        Cockpit.Choose("Whaddya wanna trade?");
    }

    void Opt1()
    {
        TradeTo = 1;
        Bartering2();
    }

    void Opt2()
    {
        TradeTo = 2;
        Bartering2();
    }

    void Opt3()
    {
        TradeTo = 3;
        Bartering2();
    }


    public void Bartering2()
    {
        Cockpit.AddOption("Fish", Option1);
        Cockpit.AddOption("Metal", Option2);
        Cockpit.AddOption("Rock Candy", Option3);
        Cockpit.AddOption("Fuel", Option4);
        Cockpit.Choose("Whaddya wanna trade for?");
    }

    void Option1()
    {
        TradeFor = 1;
        Bartering3();
    }

    void Option2()
    {
        TradeFor = 2;
        Bartering3();
    }

    void Option3()
    {
        TradeFor = 3;
        Bartering3();
    }

    void Option4()
    {
        TradeFor = 4;
        Bartering3();
    }

    void Bartering3()
    {
        //Ints used to determine exchange rates for each resource by multiplying proposed resource trade
	    //number by exchange ints
	    int FishToMetal = 1;
	    int FishToRock = 1;
	    int FishToFuel = 1;
	    int MetalToFish = 1;
	    int MetalToRock = 1;
	    int MetalToFuel = 1;
	    int RockToFish = 1;
	    int RockToMetal = 1;
	    int RockToFuel = 1;
        int Units = 0;
        //if statements
        //Fish = 1
        //Metal = 2
        //Rock = 3
        //Fuel = 4
        if (TradeTo == TradeFor)
        {
            Cockpit.Say("Those are the same thing. You.. you do know how this works, right?");
            TradeMenu();
        }

        else if (TradeTo == 1 && TradeFor == 2)
        {
            //Fish for metal
            Send(Cockpit.playerOne.fish, Cockpit.playerOne.metal, FishToMetal);
            Cockpit.playerOne.fish = Send.Item1;
            Cockpit.playerOne.metal = Send.Item2;
        }

        else if (TradeTo == 1 && TradeFor == 3)
        {
            //Fish for candy
            Send(Cockpit.playerOne.fish, Cockpit.playerOne.rock, FishToCandy);
            Cockpit.playerOne.fish = Send.Item1;
            Cockpit.playerOne.rock = Send.Item2;
        }

        else if (TradeTo == 2 && TradeFor == 1)
        {
            //Metal for Fish
            Send(Cockpit.playerOne.metal, Cockpit.playerOne.fish, MetalToFish);
            Cockpit.playerOne.metal = Send.Item1;
            Cockpit.playerOne.fish = Send.Item2;
        }

        else if (TradeTo == 2 && TradeFor == 3)
        {
            //Metal for Candy
            Send(Cockpit.playerOne.metal, Cockpit.playerOne.rock, MetalToCandy);
            Cockpit.playerOne.metal = Send.Item1;
            Cockpit.playerOne.rock = Send.Item2;
        }

        else if (TradeTo == 3 && TradeFor == 1)
        {
            //Candy for Fish
            Send(Cockpit.playerOne.rock, Cockpit.playerOne.fish, CandyToFish);
            Cockpit.playerOne.rock = Send.Item1;
            Cockpit.playerOne.fish = Send.Item2;
        }

        else if (TradeTo == 3 && TradeFor == 2)
        {
            //Candy for metal
            Send(Cockpit.playerOne.rock, Cockpit.playerOne.metal, CandyToMetal);
            Cockpit.playerOne.rock = Send.Item1;
            Cockpit.playerOne.metal = Send.Item2;
        }

        else if (TradeTo == 1 && TradeFor == 4)
        {
            //Fish for Fuel
            Send(Cockpit.playerOne.fish, Cockpit.playerOne.fuel, FishToFuel);
            Cockpit.playerOne.fish = Send.Item1;
            Cockpit.playerOne.fuel = Send.Item2;
        }

        else if (TradeTo == 2 && TradeFor == 4)
        {
            //Candy for Fuel
            Send(Cockpit.playerOne.rock, Cockpit.playerOne.fuel, CandyToFuel);
            Cockpit.playerOne.rock = Send.Item1;
            Cockpit.playerOne.fuel = Send.Item2;
        }

        else if (TradeTo == 3 && TradeFor == 4)
        {
            //Metal for Fuel
            Send(Cockpit.playerOne.metal, Cockpit.playerOne.fuel, MetalToFuel);
            Cockpit.playerOne.metal = Send.Item1;
            Cockpit.playerOne.fuel = Send.Item2;
        }
    }


    public Tuple<int, int> Send(int InValue, int OutValue, int Mult)
    {
        Cockpit.AddOption("Trade One Unit", OneUnit);
        Cockpit.AddOption("Trade Five Units", FiveUnit);
        Cockpit.Choose("How many do you want to trade?");

        if (One == true && Five == false)
        {
            if (InValue > 0)
            {
                InValue = InValue - 1;
                OutValue = OutValue + (1 * Mult);
                return Tuple.Create(InValue, OutValue);
            }

            else
            {
                Cockpit.Say("What is it you're meant to be trading, you're not holding anything.");
                Cockpit.Say("Come back when you actually have something to trade.");
                break;
            }
        }

        else if (One == false && Five == true)
        {
            if (InValue > 4)
            {
                InValue = InValue - 5;
                OutValue = OutValue + (5 * Mult);
                return Tuple.Create(InValue, OutValue);
            }

            else
            {
                Cockpit.Say("What is it you're meant to be trading, you're not holding anything.");
                Cockpit.Say("Come back when you actually have something to trade.");
                break;
            }
        }
    }

    public void OneUnit()
    {
        One = true;
        Five = false;
        break;
    }

    public void FiveUnit()
    {
        One = false;
        Five = true;
        break;
    }

    //      ---Mine Rock Candy Satelite---
    public void Rock()
    {
        //Options
        Cockpit.AddOption("Mine the Rock", MineRock);
        Cockpit.AddOption("Leave", Leaving);
        Cockpit.Choose("What will we do with this?");
    }

    public void MineRock()
    {
        //I assumed we wanted a random amount of mined candy, will correct if wrong
        Random RandomCandy = new Random();
        int MinedCandy = RandomCandy.next(1, 5);
        Cockpit.playerOne.rock = Cockpit.playerOne.rock + MinedCandy;
        Cockpit.MoveToRoom(Cockpit);
    }

    //      ---Explore wreck---
    public void DerelictWreck()
    {
        //Options
        Cockpit.AddOption("Explore the wreck", Salvage);
        Cockpit.AddOption("Leave", Leaving);
        Cockpit.Choose("What do you want us to do?");
    }

    public void Salvage()
    {
        //Wasn't sure what else to do with derelict ships so I assumed that it's the source of found metal
        Random RandomMetal = new Random();
        int SalvagedMetal = RandomMetal.next(2, 6);
        Cockpit.playerOne.metal = Cockpit.playerOne.metal + SalvagedMetal;

        //Added a little extra just to be nice
        if (Random.Range(1, 10) == 1)
        {
            Cockpit.playerOne.fuel++;
        }

        Cockpit.MoveToRoom(Cockpit);
    }

    //      ---Give Fish to Dolphin---
    public void FishTribute()
    {
        Cockpit.AddOption("Give some Fish to our Friend", Giving);
        Cockpit.AddOption("... nah, let's just leave.", Leaving);
        Cockpit.Choose("Captain, what are your orders?");
    }

    public void Giving()
    {
        if (Cockpit.playerOne.fish > 0)
        {
            Cockpit.playerOne.fish--;
            //Increase Good End chance
        }

        else
        {
            Cockpit.Say("qiqiqiqiqiqiqiqqiqiqiqi\n\"You have raised my hopes and dashed them quite expertly, bravo sirs.\"");
        }

        Cockpit.MoveToRoom(Cockpit);
    }
    
    public void Leaving()
    {
        Cockpit.MoveToRoom(Cockpit);
    }
    
}
