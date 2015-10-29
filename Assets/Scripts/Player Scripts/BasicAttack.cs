using UnityEngine;
using System.Collections;

public class BasicAttack : MonoBehaviour {

	public float timeBetweenAttacks = 1f;
	public GameObject bullet;
	public Transform spawnPoint;
	float timer;
	bool locked;
	GameObject target;
	Collider other; //For trigger end on object destruction
	// Use this for initialization
	void Start () {
		locked = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (locked && !other) {
			locked = false;
		}
		if (timer >= timeBetweenAttacks && locked) {
			timer = 0f;
			target=this.other.gameObject;
			// Insantiate the bullet prefab to shot variable
			GameObject playerBullet = Instantiate (bullet, spawnPoint.position, Quaternion.identity) as GameObject;
			//Send a target to the newly created bullet
			playerBullet.SendMessage ("SetDirection", target.transform.position);
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Enemy") {
			if (!locked) {
				Debug.Log ("Triggered! by " + other);
				locked = true;
				this.other = other;
			}
		}
	}
	
}
