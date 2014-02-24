using UnityEngine;
using System.Collections;
using Fungus;

public class Player : MonoBehaviour {

	//resource handling variables
	public int fuel;
	public int metal;
	public int rock;
	public int fish;
	public int shields;
	public int missiles;
	public Vector2 position;

	//bool upgrade flags go here
	public bool MissileUpgradeOne;


	// Use this for initialization
	void Start () {
		//Initialize player class variables
		fuel = 10;
		metal = 0;
		rock = 0;
		fish = 0;
		shields = 50;
		missiles = 5;

		position.x = 1;
		position.y = 1;

		//Upgrade flags
		MissileUpgradeOne = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*public bool UpdateMissiles(int MissilesDifference){
		missiles += MissilesDifference;

	}*/
}
