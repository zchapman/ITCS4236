using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 1;
	public int currentHealth;
	bool isDead;

	void Start () {
		currentHealth = startingHealth;
	}
	

	void Update () {
	
	}

	//This will be called when the enemy takes damage
	public void TakeDamage (int amount) {
		
		//Reduce the current health by the damage amount
		currentHealth -= amount;
		
		//If all health is gone
		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	//Enemy is destroyed
	void Death () {
		isDead = true;
		Destroy (gameObject);
	}
}
