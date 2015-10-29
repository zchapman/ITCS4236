using UnityEngine;
using System.Collections;

public class CarStats : MonoBehaviour {

	public int kills = 0;
	int numUpgrades;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int calcThreat() {
		return 0;
	}

	public int increaseKills() {
		kills = kills+1;
		return 0;
	}
}
