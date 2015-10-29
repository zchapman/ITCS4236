using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	
	public float bulletSpeed = 30f;

	int damage;
	GameObject player;
	PlayerHealth playerHealth;

	GameObject parent;


	//Set bullet properties based on the enemy that fired
	void Init(GameObject p) {
		parent = p;
		damage = p.GetComponent<EnemyAttack> ().getDamage ();
	}

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void Update() {
		//TODO: Move bullet toward direction clicked
		Vector3 toTarget = player.transform.position - transform.position;

		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, bulletSpeed * Time.deltaTime);

	}
	void OnCollisionEnter(Collision c){
		// Destroy this object when it collides with an enemy
		if(c.gameObject.tag == "Enemy Target"){
			if (playerHealth.currentHealth>0) {
				playerHealth.TakeDamage (damage);
			}
			Destroy (gameObject);
		}
	}

}
