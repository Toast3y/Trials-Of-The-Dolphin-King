using UnityEngine;
using System.Collections;
using Fungus;

public class LevelRandom{

	public Cockpit cockpit;
	public Events Events = new Events();

	int[,] EventChart = new int[8,8];

	// Use this for initialization
	void Start () {
	
	}

	public void Initialise (Cockpit cockpit) {
		this.cockpit = cockpit;
		Events.Start (cockpit);

		InitRandomWorld (0, 0);
	}

	void InitRandomWorld(int x, int y){
		int random;

		random = Random.Range (1, 101);

		//Assigns a random event to a square
		if (random <= 15) {
			//Empty Space One
			EventChart [x,y] = 1;
		} else if ((random > 15) && (random <= 30)){
			//Empty Space Two
			EventChart[x,y] = 7;
		} else if ((random > 30) && (random <= 45)){
			//Empty Space Three
			EventChart[x,y] = 8;
		} else if ((random > 45) && (random <= 60)){
			//Empty Space Four
			EventChart[x,y] = 9;
		} else if ((random > 60) && (random <= 70)) {
			//Derelict Wreck
			EventChart [x,y] = 2;
		} else if ((random > 70) && (random <= 80)){
			//Dolphin
			EventChart [x,y] = 3;
		} else if ((random > 80) && (random <= 90)){
			//Rock Candy
			EventChart [x,y] = 4;
		} else if ((random > 90) && (random <= 100)){
			//Trading Planet
			EventChart [x,y] = 5;
		}

		if ((x == 7) && (y == 7)) {
			FinalizeWorld ();
		} else if ((x != 7) && (y == 7)) {
			InitRandomWorld (++x, 0);
		} else {
			InitRandomWorld (x, ++y);
		}
	}

	void FinalizeWorld (){
		int x, y;

		x = Random.Range (0, 8);
		y = Random.Range (0, 8);

		//Assign player start
		EventChart [x, y] = 1;
		cockpit.playerOne.position.x = x+1;
		cockpit.playerOne.position.y = y+1;


		x = Random.Range (0, 8);
		y = Random.Range (0, 8);

		if ((x == cockpit.playerOne.position.x) && (y == cockpit.playerOne.position.y)) {
			x = Random.Range (0, 8);
			y = Random.Range (0, 8);
		} else {
			EventChart[x,y] = 6;
		}

		Events.Leaving ();
	}

	public void checkEvent(int x, int y){
	
		switch(EventChart[x-1,y-1]){
			case 1:
				Empty ();
				break;
			case 2:
				Wreck ();
				break;
			case 3:
				Dolphin();
				break;
			case 4:
				RockCandy();
				break;
			case 5:
				Planet();
				break;
			case 6:
				Ending();
				break;
			case 7:
				EmptyTwo();
				break;
			case 8:
				EmptyThree();
				break;
			case 9:
				EmptyFour();
				break;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Create event methods
	//Derelict spaceship wreck
	public void Wreck () {
		cockpit.Say ("After warping in, you quickly spot a shipwreck on your sensors.");
		cockpit.Say ("It looks abandoned...");
		Events.DerelictWreck();
	}
	
	//Nothing/Dead Space
	public void Empty () {
		cockpit.Say("You gaze ahead in abject horror as you realise that hovering menacingly in front of your ship is... " + "Absolutely nothing.");
	}

	public void EmptyTwo(){
		cockpit.Say("As you warp in, you believe you see a blurry shape hurtling past the cockpit. It looked suspiciously like a flower pot.");
		cockpit.Say("Other then a rogue flower pot, this area of space is completely empty.");
	}

	public void EmptyThree(){
		cockpit.Say ("As you hit the warp button, your mind runs wild with the possibilities of what could be in this new location.");
		cockpit.Say ("Unfortunately, your hopes are dashed as it appears completely barren other than some traces of space dust.");
	}

	public void EmptyFour(){
		cockpit.Say ("As you warp in, your eyes are greeted by possibly the most horrific sight you've ever seen.");
		cockpit.Say ("You've found a local tourist site. Unfortunately, like most tourist sites, there's very little to do here. Best to keep moving!");
	}
	
	//Rock candy
	public void RockCandy () {
		cockpit.Say("Cap'n, there's a huge chunk o' rock candy floating a'fore us!");
		cockpit.Say("...");
		cockpit.Say("Why are you talking like that?");
		
		//Enter mining screen
		Events.Rock();
	}
	
	//Run into a dolphin
	public void Dolphin () {
		cockpit.Say("A wild dolphin appears!");
		cockpit.Say("*Dolphin noises*");
		
		//Enter Fish tribute screen
		Events.FishTribute();
	}
	
	//Find a planet
	public void Planet () {
		cockpit.Say("You've discovered a new planet! Sort of, anyway, it appears to be populated.");
		cockpit.Say("But it was fun getting here and that's what matters.");
		Events.TradeMenu();
	}

	public void Ending (){
		cockpit.Say("Congratulations! You found the end of the level!");
		cockpit.Say("Unfortunately, this is the end of the random demo.");

		cockpit.AddOption ("Keep playing", Events.Leaving);
		cockpit.AddOption ("End the game", cockpit.death);

		cockpit.Choose ("Thanks for playing!");
	}
}
