using UnityEngine;
using System.Collections;

public class StarMovement : MonoBehaviour {

	public Transform startMarker;
	public Vector3 endMarker;
	public float speed = 1.0f;
	private float startTime;
	private float journeyLength;
	
	void Start () {
		endMarker = new Vector3 (startMarker.position.x, startMarker.position.y, -1 * startMarker.position.z);
		startTime = Time.time;
		journeyLength = Vector3.Distance (startMarker.position, endMarker);
	}

	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (startMarker.position, endMarker, fracJourney);

		if (transform.position == endMarker) {
			Destroy (this.gameObject);
		}
	}
}
