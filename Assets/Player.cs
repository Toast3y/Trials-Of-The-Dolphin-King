using UnityEngine;
using System.Collections;
using Fungus;

public class Player{

	//resource handling variables
	public int fuel;
	public int metal;
	public int rock;
	public int fish;
	public int shields;
	public int missiles;
    public int engine;
	public Vector2 position;

	//bool upgrade flags go here
	public bool MissileUpgradeOne;


	// Use this for initialization
	void Start () {
		//Initialize player class variables
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initialize(){
		fuel = 10;
		metal = 0;
		rock = 0;
		fish = 0;
		shields = 50;
		missiles = 5;
        engine = 1;
		
		position.x = 1;
		position.y = 1;
		
		//Upgrade flags
		MissileUpgradeOne = false;
	}



	//Checks to see if you have too many missiles.
	//Returns true if you can buy it, false if you can't.
	public bool UpdateMissiles(int MissilesDifference){
		missiles += MissilesDifference;

		if (MissileUpgradeOne) {
			if (missiles > 10){
				missiles = 10;
				return false;
			}
			else{
				return true;
			}
		}
		else if (!MissileUpgradeOne){
			if (missiles > 5){
				missiles = 5;
				return false;
			}
			else{
				return true;
			}
		}

		return false;
	}
}
