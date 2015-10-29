using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	
	public int damage = 1;
	public float bulletSpeed = 30f;
	
	Vector3 direction;

	//Set direction of the bullet, called from firing mechanism
	void SetDirection(Vector3 v) {
		direction = v.normalized*25;
	}

	void Update() {
		//TODO: Move bullet toward player
		if (transform.position == direction) {
			Destroy (gameObject);
		}
		//Vector3 toTarget = direction - transform.position;
		
		transform.position = Vector3.MoveTowards (transform.position, direction, bulletSpeed * Time.deltaTime);
		
		
	}
	void OnCollisionEnter(Collision c){
		// Destroy this object when it collides with anything
		if(c.gameObject.tag == "Enemy"){
			EnemyHealth enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
			if (enemyHealth.currentHealth>0) {
				enemyHealth.TakeDamage (damage);
			}
			Destroy (gameObject);
		}
	}
}
