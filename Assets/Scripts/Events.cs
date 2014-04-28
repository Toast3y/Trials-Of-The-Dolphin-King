/*
 Eoin Meyler
 */

using UnityEngine;
using System.Collections;
using Fungus;

public class Events
{
	//Using ints 1 - 3 determines which resources are being traded
	int TradeTo = 0;
	int TradeFor = 0;
	public int InValue;
	public int OutValue;
	public int Mult;
	public bool One, Five;

	//Ints used to determine exchange rates for each resource by multiplying proposed resource trade
	//number by exchange ints
	public int FishToMetal = 1;
	public int FishToRock = 1;
	public int FishToFuel = 1;
	public int MetalToFish = 1;
	public int MetalToRock = 1;
	public int MetalToFuel = 1;
	public int RockToFish = 1;
	public int RockToMetal = 1;
	public int RockToFuel = 1;

	public Cockpit Cockpit;

	public void Start(Cockpit cockpit)
	{
		this.Cockpit = cockpit;
	}

    public void TradeMenu()
    {
		//Choose what to do
        Cockpit.AddOption("Buy Goods", Bartering1);	//Calls first section of barter system
													//Fungus doesn't allow for variables to be passed into called functions
													//so an unfortunately verbose workaround was used
        Cockpit.AddOption("Leave", Leaving);	//Ends events
        Cockpit.Choose("Welcome! Here to trade?");
    }

    public void Bartering1()
    {
		//Choose what to sell for supplies
        Cockpit.AddOption("Fish", Opt1);
        Cockpit.AddOption("Metal", Opt2);
        Cockpit.AddOption("Rock Candy", Opt3);
        Cockpit.Choose("What'll you give me?" + "\nFish: " + Cockpit.playerOne.fish + "\nMetal: " + Cockpit.playerOne.metal + "\nRock Candy: " + Cockpit.playerOne.rock);
    }

	//Sets variables to determine what is being traded then moves to next stage
    void Opt1()
    {
		//Sets resource to trade with to Fish
        TradeTo = 1;
        Bartering2();
    }

    void Opt2()
    {
		//Sets resource to trade with to Metal
        TradeTo = 2;
        Bartering2();
    }

    void Opt3()
    {
		//Sets resource to trade with to Rock
        TradeTo = 3;
        Bartering2();
    }


    public void Bartering2()
    {
		//Choose what to buy

		if (TradeTo != 1) {
			Cockpit.AddOption ("Fish", Option1);
		}

		if (TradeTo != 2){
        	Cockpit.AddOption("Metal", Option2);
		}

		if (TradeTo != 3) {
			Cockpit.AddOption ("Rock Candy", Option3);
		}

        Cockpit.AddOption("Fuel", Option4);
        Cockpit.Choose("Whaddya wanna buy with them?");
    }

	//Sets variables to determine what is being traded for
    void Option1()
    {
		//Sets resource to buy to Fish
        TradeFor = 1;
        Bartering3();
    }

    void Option2()
    {
		//Sets resource to buy to Metal
        TradeFor = 2;
        Bartering3();
    }

    void Option3()
    {
		//Sets resource to buy to Rock Candy
        TradeFor = 3;
        Bartering3();
    }

    void Option4()
    {
		//Sets resource to buy to Fuel
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

		//Compares values to make sure you are trading different resources
		if (TradeTo == TradeFor) 
		{
			Cockpit.Say ("Those are the same thing. You.. you do know how this works, right?");
			TradeMenu ();
		} 

		//If they're different, do stuff
		else 
		{
			//Determine number of things to trade
			TradeUnitNum ();
		}
	}

	//Do the actual editing of values
	//Now with 20% more feedback!
	public bool DoTrade(int Amount)
	{
		//Take in value and edit it based on user input and options
		bool OK = false;
		if (TradeTo == 1 && TradeFor == 2)
		{
			//Fish for metal
			if (Cockpit.playerOne.fish >= Amount)
			{
				OK = true;
				Cockpit.playerOne.fish = Cockpit.playerOne.fish - Amount;
				Cockpit.playerOne.metal = Cockpit.playerOne.metal + (Amount * FishToMetal);
				Cockpit.Say("Traded " + Amount + " fish for " + (Amount * FishToMetal) + " metal.");
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
				Cockpit.Say("Traded " + Amount + " fish for " + (Amount * FishToRock) + " rock candy.");
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
				Cockpit.Say("Traded " + Amount + " metal for " + (Amount * MetalToFish) + " fish.");
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
				Cockpit.Say("Traded " + Amount + " metal for " + (Amount * MetalToRock) + " rock candy.");
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
				Cockpit.Say("Traded " + Amount + " rock candy for " + (Amount * RockToFish) + " fish.");
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
				Cockpit.Say("Traded " + Amount + " rock candy for " + (Amount * RockToMetal) + " metal.");
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
				Cockpit.Say("Traded " + Amount + " fish for " + (Amount * FishToFuel) + " fuel.");
			}
		}
		else if (TradeTo == 3 && TradeFor == 4) 
		{
			//Candy for Fuel
			if (Cockpit.playerOne.rock >= Amount)
			{
				OK = true;
				Cockpit.playerOne.rock = Cockpit.playerOne.rock - Amount;
				Cockpit.playerOne.fuel = Cockpit.playerOne.fuel + (Amount * RockToFuel);
				Cockpit.Say("Traded " + Amount + " rock candy for " + (Amount * RockToFuel) + " fuel.");
			}
		}
		else if (TradeTo == 2 && TradeFor == 4) 
		{
			//Metal for Fuel
			if (Cockpit.playerOne.metal >= Amount)
			{
				OK = true;
				Cockpit.playerOne.metal = Cockpit.playerOne.metal - Amount;
				Cockpit.playerOne.fuel = Cockpit.playerOne.fuel + (Amount * MetalToFuel);
				Cockpit.Say("Traded " + Amount + " metal for " + (Amount * MetalToFuel) + " fuel.");
			}
		}

		return OK;
	}


    public void TradeUnitNum()
    {
		//Determine how much of a unit to trade, 1 or 5
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
        //Mine the rock, get some candy
        int MinedCandy = Random.Range(1, 6);
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
        //Search ship, get metal and maybe some fuel
        Random RandomMetal = new Random();
        int SalvagedMetal = Random.Range(2, 7);
        Cockpit.playerOne.metal = Cockpit.playerOne.metal + SalvagedMetal;
		Cockpit.Say ("You managed to find " + SalvagedMetal + " pieces of Scrap Metal");

        //Added a little extra just to be nice
        if (Random.Range(1, 11) >= 6)
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
        Cockpit.MoveToRoom(Cockpit);
    }
}
