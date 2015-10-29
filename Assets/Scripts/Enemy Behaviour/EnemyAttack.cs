using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public int damage;
	public float speed;
	public float timeBetweenAttacks = 2f;
	public float attackRange = 3f;
	public GameObject bullet;
	public Transform spawnPoint;

	GameObject target;
	Vector3 toTarget;
	bool playerInRange;
	float timer;	

	void Awake () {
		//TODO: More complicated targetting
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter (Collider c) {
		//Determine if enemy is within range of player
		if (c.gameObject.tag == "Enemy Target") {
			playerInRange = true;
		}
	}
	
	void Update () {
		//Unleash a bullet frenzy when cooldown is over and within range of player
		timer += Time.deltaTime;

		toTarget = target.transform.position - transform.position;

		if (playerInRange) {
			if (timer >= timeBetweenAttacks && playerInRange) {
				timer = 0f;
				Attack ();
			}
			return;
		}

		Move ();

	}

	void Move() {
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		//LOL - models have Z axis pointing the wrong way - will fix later
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (toTarget), 0.05f);
	}

	void Attack () {
		//Spawn bullet and send self reference to bullet
		GameObject newBullet = Instantiate (bullet, spawnPoint.position, Quaternion.identity) as GameObject;
		newBullet.SendMessage ("Init", gameObject);
	}

	public int getDamage() {
		return damage;
	}
}
