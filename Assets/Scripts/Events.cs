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
	public int InValue;
	public int OutValue;
	public int Mult;
	public bool One, Five;

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

	public Cockpit Cockpit;

	public void Start(Cockpit cockpit)
	{
		this.Cockpit = cockpit;
	}

    public void TradeMenu()
    {
        Cockpit.AddOption("Buy Goods", Bartering1);
        Cockpit.AddOption("Leave", Leaving);
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
		//if statements
		//Fish = 1
		//Metal = 2
		//Rock = 3
		//Fuel = 4
		if (TradeTo == TradeFor) 
		{
			Cockpit.Say ("Those are the same thing. You.. you do know how this works, right?");
			TradeMenu ();
		} 

		else 
		{
			TradeUnitNum ();
		}
	}

	public bool DoTrade(int Amount)
	{
		bool OK = false;
		if (TradeTo == 1 && TradeFor == 2)
		{
			//Fish for metal
			if (Cockpit.playerOne.fish >= Amount)
			{
				OK = true;
				Cockpit.playerOne.fish = Cockpit.playerOne.fish - Amount;
				Cockpit.playerOne.metal = Cockpit.playerOne.metal + (Amount * FishToMetal);
			}
		}
		else if (TradeTo == 1 && TradeFor == 3)
		{
			//Fish for candy
			if (Cockpit.playerOne.fish >= Amount)
			{
				OK = true;
				Cockpit.playerOne.fish = Cockpit.playerOne.fish - Amount;
				Cockpit.playerOne.rock = Cockpit.playerOne.rock + (Amount * FishToRock);
			}
		}
		else if (TradeTo == 2 && TradeFor == 1)
		{
			//Metal for Fish
			if (Cockpit.playerOne.metal >= Amount)
			{
				OK = true;
				Cockpit.playerOne.metal = Cockpit.playerOne.metal - Amount;
				Cockpit.playerOne.fish = Cockpit.playerOne.fish + (Amount * MetalToFish);
			}
		}
		else if (TradeTo == 2 && TradeFor == 3)
		{
			//Metal for Candy
			if (Cockpit.playerOne.metal >= Amount)
			{
				OK = true;
				Cockpit.playerOne.metal = Cockpit.playerOne.metal - Amount;
				Cockpit.playerOne.rock = Cockpit.playerOne.rock + (Amount * MetalToRock);
			}
		} 
		else if (TradeTo == 3 && TradeFor == 1)
		{
			//Candy for Fish
			if (Cockpit.playerOne.rock >= Amount)
			{
				OK = true;
				Cockpit.playerOne.rock = Cockpit.playerOne.rock - Amount;
				Cockpit.playerOne.fish = Cockpit.playerOne.fish + (Amount * RockToFish);
			}
		} 
		else if (TradeTo == 3 && TradeFor == 2) 
		{
			//Candy for metal
			if (Cockpit.playerOne.rock >= Amount)
			{
				OK = true;
				Cockpit.playerOne.rock = Cockpit.playerOne.rock - Amount;
				Cockpit.playerOne.metal = Cockpit.playerOne.metal + (Amount * RockToMetal);
			}
		} 
		else if (TradeTo == 1 && TradeFor == 4) 
		{
			//Fish for Fuel
			if (Cockpit.playerOne.fish >= Amount)
			{
				OK = true;
				Cockpit.playerOne.fish = Cockpit.playerOne.fish - Amount;
				Cockpit.playerOne.fuel = Cockpit.playerOne.fuel + (Amount * FishToFuel);
			}
		}
		else if (TradeTo == 2 && TradeFor == 4) 
		{
			//Candy for Fuel
			if (Cockpit.playerOne.rock >= Amount)
			{
				OK = true;
				Cockpit.playerOne.rock = Cockpit.playerOne.rock - Amount;
				Cockpit.playerOne.fuel = Cockpit.playerOne.fuel + (Amount * RockToFuel);
			}
		}
		else if (TradeTo == 3 && TradeFor == 4) 
		{
			//Metal for Fuel
			if (Cockpit.playerOne.metal >= Amount)
			{
				OK = true;
				Cockpit.playerOne.metal = Cockpit.playerOne.metal - Amount;
				Cockpit.playerOne.fuel = Cockpit.playerOne.fuel + (Amount * MetalToFuel);
			}
		}

		return OK;
	}


    public void TradeUnitNum()
    {
        Cockpit.AddOption("Trade One Unit", OneUnit);
        Cockpit.AddOption("Trade Five Units", FiveUnit);
        Cockpit.Choose("How many do you want to trade?");
    }

    public void OneUnit()
    {
		if (DoTrade(1) == false)
		{
			Cockpit.Say("What is it you're meant to be trading, you're not holding anything.");
			Cockpit.Say("Come back when you actually have something to trade.");
		}

		TradeMenu ();
    }

    public void FiveUnit()
    {
		if (DoTrade(5) == false)
		{
			Cockpit.Say("What is it you're meant to be trading, you're not holding anything.");
			Cockpit.Say("Come back when you actually have something to trade.");
		}

		TradeMenu();
    }


	//-----------------------------------NONE TRADE EVENTS-----------------------------------

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
        int MinedCandy = Random.Range(1, 5);
        Cockpit.playerOne.rock = Cockpit.playerOne.rock + MinedCandy;
		Cockpit.Say ("After hours of back-breaking labour, your crew has managed to extract " + MinedCandy + " chunks of Rock Candy");
		Cockpit.MoveToRoom (Cockpit);
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
        int SalvagedMetal = Random.Range(2, 6);
        Cockpit.playerOne.metal = Cockpit.playerOne.metal + SalvagedMetal;
		Cockpit.Say ("You managed to find " + SalvagedMetal + " pieces of Scrap Metal");

        //Added a little extra just to be nice
        if (Random.Range(1, 10) == 1)
        {
            Cockpit.playerOne.fuel++;
			Cockpit.Say("You also salvaged one Galactic Standard Unit of generic Starship Fuel");
        }

		Cockpit.MoveToRoom (Cockpit);
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
			Cockpit.Say("You gave 1 fish");
            //Increase Good End chance
        }

        else
        {
			Cockpit.Say("Sir, we don't have any fish to trade!");
            Cockpit.Say("-qiqiqiqiqiqiqiqqiqiqiqi-\n\"You have raised my hopes and dashed them quite expertly, bravo Humans.\"");
        }

		Cockpit.MoveToRoom (Cockpit);
    }
    
    public void Leaving()
    {
		Cockpit.Say ("Let's go!");
        Cockpit.MoveToRoom(Cockpit);
    }
}
