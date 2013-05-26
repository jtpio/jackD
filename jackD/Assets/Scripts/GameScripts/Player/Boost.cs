using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {
		
	protected int score = 0;
	protected MovePlayer movePlayer;
	
	void Start () {
		score = 0;
		movePlayer = gameObject.GetComponent<MovePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!animation.isPlaying) {
			animation.Play("slide");	
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		
		string hitName = hit.gameObject.name;
		bool item = false;
		switch(hitName) {
		case "Cube(Clone)": 
			score++;
			item = true;
			break;
		case "Bull(Clone)":
			
			item = true;
			break;
		case "Tablet(Clone)":
			
			item = true;
			break;
		}
		
		if (item) {
			Destroy(hit.gameObject);
			animation.Play("feed");
		}
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (10,10,100,50), "Score " + score)) {
			print ("Clicked!");
		}
	}
}
