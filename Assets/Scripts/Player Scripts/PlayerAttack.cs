using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public GameObject bullet;

	Vector3 target;
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			//Get mouse position only on Mouse Target quad
			if (Physics.Raycast (ray, out hit, 100)) {
				target = new Vector3 (hit.point.x, 0, hit.point.z);
				Debug.Log (target);
			}

			// Inistiate the bullet prefab to shot variable
			GameObject playerBullet = Instantiate (bullet, Vector3.zero, Quaternion.identity) as GameObject;
			//Send a target to the newly created bullet
			playerBullet.SendMessage ("SetDirection", target);

		}
	}
}
