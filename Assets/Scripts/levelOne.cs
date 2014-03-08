using UnityEngine;
using System.Collections;
using Fungus;

public class levelOne{

	public Cockpit Cockpit;

	public Events Events;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void CallEvent(){
		switch (Cockpit.playerOne.position.x) {
		case 1:
			XOneEvents();
			break;
		case 2:
			XTwoEvents();
			break;
		case 3:
			XThreeEvents();
			break;
		case 4:
			XFourEvents();
			break;
		case 5:
			XFiveEvents();
			break;
		case 6:
			XSixEvents();
			break;
		case 7:
			XSevenEvents();
			break;
		case 8:
			XEightEvents();
			break;
		}
	}
	
	
	void XOneEvents(){
		switch (Cockpit.playerOne.position.y) {
		case 1:
			Empty();
			break;
		case 2:
			Cockpit.Say("Welcome to Brequinda");
			Planet();
			break;
		case 3:
			Empty();
			break;
		case 4:
			Dolphin();
			break;
		case 5:
			Cockpit.Say("Welcome to Ciceronicus 12");
			Planet();
			break;
		case 6:
			Cockpit.Say("Welcome to Esflovian");
			Planet();
			break;
		case 7:
			Wreck();
			break;
		case 8:
			Cockpit.Say("Welcome to Golgafrincham");
			Planet();
			break;
		}
	}
	
	void XTwoEvents(){
		switch (Cockpit.playerOne.position.y) {
		case 1:
			Cockpit.Say("Welcome to Happi-Werld III");
			Planet();
			break;
		case 2:
			Empty();
			break;
		case 3:
			Dolphin();
			break;
		case 4:
			Empty();
			break;
		case 5:
			Empty();
			break;
		case 6:
			Cockpit.Say("Welcome to Jaglan Beta");
			Planet();
			break;
		case 7:
			RockCandy();
			break;
		case 8:
			Empty();
			break;
		}
	}
	
	void XThreeEvents(){
		switch (Cockpit.playerOne.position.y) {
		case 1:
			Wreck();
			break;
		case 2:
			RockCandy();
			break;
		case 3:
			Empty();
			break;
		case 4:
			Cockpit.Say("Welcome to Kakrafoon");
			Planet();
			break;
		case 5:
			Empty();
			break;
		case 6:
			Wreck();
			break;
		case 7:
			Empty();
			break;
		case 8:
			Cockpit.Say("Welcome to Lamuella");
			Planet();
			break;
		}
	}
	
	void XFourEvents(){
		switch (Cockpit.playerOne.position.y) {
		case 1:
			Cockpit.Say("Welcome to Santraginus V");
			Planet();
			break;
		case 2:
			Empty();
			break;
		case 3:
			Empty();
			break;
		case 4:
			Empty();
			break;
		case 5:
			Cockpit.Say("Welcome to Stegbartle Major");
			Planet();
			break;
		case 6:
			Empty();
			break;
		case 7:
			Dolphin();
			break;
		case 8:
			Wreck();
			break;
		}
	}
	
	void XFiveEvents(){
		switch (Cockpit.playerOne.position.y) {
		case 1:
			Empty();
			break;
		case 2:
			Wreck();
			break;
		case 3:
			Empty();
			break;
		case 4:
			Cockpit.Say("Welcome to Viltvodle VI");
			Planet();
			break;
		case 5:
			Empty();
			break;
		case 6:
			Empty();
			break;
		case 7:
			Wreck();
			break;
		case 8:
			Empty();
			break;
		}
	}
	
	void XSixEvents(){
		switch (Cockpit.playerOne.position.y) {
		case 1:
			Empty();
			break;
		case 2:
			Empty();
			break;
		case 3:
			Cockpit.Say("Welcome to Kria");
			Planet();
			break;
		case 4:
			Empty();
			break;
		case 5:
			RockCandy();
			break;
		case 6:
			Empty();
			break;
		case 7:
			Dolphin();
			break;
		case 8:
			Empty();
			break;
		}
	}
	
	void XSevenEvents(){
		switch (Cockpit.playerOne.position.y) {
		case 1:
			Wreck();
			break;
		case 2:
			Empty();
			break;
		case 3:
			Empty();
			break;
		case 4:
			Cockpit.Say("Welcome to Han Wavel");
			Planet();
			break;
		case 5:
			Dolphin();
			break;
		case 6:
			Empty();
			break;
		case 7:
			Empty();
			break;
		case 8:
			Empty();
			break;
		}
	}
	
	void XEightEvents(){
		switch (Cockpit.playerOne.position.y) {
		case 1:
			Empty();
			break;
		case 2:
			Cockpit.Say("Welcome to Damogran");
			Planet();
			break;
		case 3:
			Empty();
			break;
		case 4:
			Empty();
			break;
		case 5:
			RockCandy();
			break;
		case 6:
			Empty();
			break;
		case 7:
			Cockpit.Say("Welcome to Broop Kidron 13");
			Planet();
			break;
		case 8:
			Empty();
			break;
		}
	}
	
	//Create event methods
	//Derelict spaceship wreck
	public void Wreck () {
		Cockpit.Say ("It looks abandoned...");
		Events.DerelictWreck();
	}
	
	//Nothing/Dead Space
	public void Empty () {
		Cockpit.Say("You gaze ahead in abject horror as you realise that " +
		    "hovering menacingly in front of your ship is...");
		Cockpit.Wait(3);
		Cockpit.Say("Absolutely nothing.");
		Cockpit.MoveToRoom(Cockpit);
	}
	
	//Rock candy
	public void RockCandy () {
		Cockpit.Say("Cap'n, there's a huge chunk o' rock candy floating a'fore us!");
		Cockpit.Say("...");
		Cockpit.Say("Why are you talking like that?");
		
		//Enter mining screen
		Events.Rock();
	}
	
	//Run into a dolphin
	public void Dolphin () {
		Cockpit.Say("A wild dolphin appears!");
		Cockpit.Say("*Dolphin noises*");
		
		//Enter Fish tribute screen
		Events.FishTribute();
	}
	
	//Find a planet
	public void Planet () {
		Cockpit.Say("You've discovered a new planet! Sort of, anyway, it appears to be populated.");
		Cockpit.Say("But it was fun getting here and that's what matters.");
		Events.TradeMenu();
	}

}
