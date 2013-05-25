using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	protected int score = 0;
	
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log ("collision character");
		if (hit.gameObject.name == "Cube(Clone)") {
			Debug.Log ("collision with item");	
			Destroy(hit.gameObject);
			score++;
		}
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (10,10,100,50), "Score " + score)) {
			print ("Clicked!");
		}
	}
}
