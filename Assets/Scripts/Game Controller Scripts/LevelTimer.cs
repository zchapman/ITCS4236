using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTimer : MonoBehaviour {

	public float timeRemaining = 60;
	public Text TimeUI;
	public int waves = 1;
	public GameObject[] enemies = new GameObject[6];
	public int noEnemies = 5;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("decreaseTimeRemaining",1,1);
		InvokeRepeating ("enemyWave", 5, 20);
	}
	
	// Update is called once per frame
	void Update () {
		if (timeRemaining < 0) {
			return;
		}

		displayTime ();

	}

	void enemyWave() {
		waves++;
		for (int i = 0; i < noEnemies; i++) {
			int rand = Random.Range (0, 5);
			Vector3 pos = new Vector3 (13, 0, Random.Range(-7f, 9f));
			GameObject Enemey = Instantiate (enemies[rand], pos, Quaternion.identity) as GameObject;
			pos.Set (pos.x * -1f, pos.y, Random.Range (-7f, 9f));
			GameObject Enemy = Instantiate (enemies[rand], pos, Quaternion.identity) as GameObject;	                               
		}
	}

	void decreaseTimeRemaining() {
		timeRemaining --;
	}

	void displayTime() {
		TimeUI.text = timeRemaining + "seconds";
	}

	void timeElapsed() {

	}
}
