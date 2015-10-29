using UnityEngine;
using System.Collections;

public class GenerateStars : MonoBehaviour {
	
	public GameObject star;
	
	void GenerateStar() {
		Vector3 position = new Vector3 (Random.Range (-25f, 25f), -10f, -20f);
		float scale = Random.Range (.25f,.5f);
		GameObject newStar = Instantiate (star, position, Quaternion.identity) as GameObject;
		newStar.transform.localScale = new Vector3 (scale, scale, scale);
	}
	
	void Start() {
		InvokeRepeating ("GenerateStar", 1, .75f);
	}
}
