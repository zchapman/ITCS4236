using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;

	public Slider healthSlider;
	public Image damageImage;
	//public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);

	public int currentHealth;

	bool isDead;
	bool damaged;

	void Awake () {
		//Set initial health
		currentHealth = startingHealth;
	}

	void Update () {
		//If the player has just been damaged
		if (damaged) {
			// set the color of the damageImage to the flash color
			damageImage.color = flashColour;
		} else {
			// transition the color back to clear
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		//Reset damaged flag
		damaged = false;
	}

	//This will be called when enemies damage the train
	public void TakeDamage (int amount) {
		//Set the damaged flag so the screen flashes
		damaged = true;

		//Reduce the current health by the damage amount
		currentHealth -= amount;

		//Set the health bar's value to the current health
		healthSlider.value = currentHealth;

		//If all health is gone
		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	//Train is destroyed
	void Death () {
		isDead = true;
	}
}
