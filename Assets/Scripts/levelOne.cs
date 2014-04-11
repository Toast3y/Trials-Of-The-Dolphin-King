using UnityEngine;
using System.Collections;
using Fungus;

public class levelOne{



	public Cockpit cockpit;

	public Events Events = new Events();

	// Use this for initialization
	public void Initialise (Cockpit cockpit) {
		this.cockpit = cockpit;
		Events.Start (cockpit);
	}


	void Start(){
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CallEvent(int XVal, int YVal){
		//int XVal = (int)Cockpit.playerOne.position.x;

		switch (XVal) {
		case 1:
			XOneEvents(YVal);
			break;
		case 2:
			XTwoEvents(YVal);
			break;
		case 3:
			XThreeEvents(YVal);
			break;
		case 4:
			XFourEvents(YVal);
			break;
		case 5:
			XFiveEvents(YVal);
			break;
		case 6:
			XSixEvents(YVal);
			break;
		case 7:
			XSevenEvents(YVal);
			break;
		case 8:
			XEightEvents(YVal);
			break;
		}
	}
	
	
	
	void XOneEvents(int YVal){
		//int YVal = (int)Cockpit.playerOne.position.y;
		switch (YVal) {
		case 1:
			Empty();
			break;
		case 2:
			cockpit.Say("Welcome to Brequinda");
			break;
		case 3:
			Empty();
			break;
		case 4:
			Dolphin();
			break;
		case 5:
			cockpit.Say("Welcome to Ciceronicus 12");
			Planet();
			break;
		case 6:
			cockpit.Say("Welcome to Esflovian");
			Planet();
			break;
		case 7:
			Wreck();
			break;
		case 8:
			cockpit.Say("Welcome to Golgafrincham");
			Planet();
			break;
		}
	}
	
	void XTwoEvents(int YVal){
		//int YVal = (int)Cockpit.playerOne.position.y;
		switch (YVal) {
		case 1:
			cockpit.Say("Welcome to Happi-Werld III");
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
			cockpit.Say("Welcome to Jaglan Beta");
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
	
	void XThreeEvents(int YVal){
		//int YVal = (int)Cockpit.playerOne.position.y;
		switch (YVal) {
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
			cockpit.Say("Welcome to Kakrafoon");
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
			cockpit.Say("Welcome to Lamuella");
			Planet();
			break;
		}
	}
	
	void XFourEvents(int YVal){
		//int YVal = (int)Cockpit.playerOne.position.y;
		switch (YVal) {
		case 1:
			cockpit.Say("Welcome to Santraginus V");
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
			cockpit.Say("Welcome to Stegbartle Major");
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
	
	void XFiveEvents(int YVal){
		//int YVal = (int)Cockpit.playerOne.position.y;
		switch (YVal) {
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
			cockpit.Say("Welcome to Viltvodle VI");
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
	
	void XSixEvents(int YVal){
		//int YVal = (int)Cockpit.playerOne.position.y;
		switch (YVal) {
		case 1:
			Empty();
			break;
		case 2:
			Empty();
			break;
		case 3:
			cockpit.Say("Welcome to Kria");
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
	
	void XSevenEvents(int YVal){
		//int YVal = (int)Cockpit.playerOne.position.y;
		switch (YVal) {
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
			cockpit.Say("Welcome to Han Wavel");
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
	
	void XEightEvents(int YVal){
		//int YVal = (int)Cockpit.playerOne.position.y;
		switch (YVal) {
		case 1:
			Empty();
			break;
		case 2:
			cockpit.Say("Welcome to Damogran");
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
			cockpit.Say("Welcome to Broop Kidron 13");
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
		cockpit.Say ("After warping in, you quickly spot a shipwreck on your sensors.");
		cockpit.Say ("It looks abandoned...");
		Events.DerelictWreck();
	}
	
	//Nothing/Dead Space
	public void Empty () {
		cockpit.Say("You gaze ahead in abject horror as you realise that hovering menacingly in front of your ship is..." + "Absolutely nothing.");
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


}
