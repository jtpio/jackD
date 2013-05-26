using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {
	
	public float BOOST = 800;
	public float BOOST_TIME = 2;
	
	protected int score = 0;
	protected MovePlayer movePlayer;
	
	protected float time = 0;
	protected bool boost = false;
	
	void Start () {
		score = 0;
		movePlayer = gameObject.GetComponent<MovePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!animation.isPlaying) {
			animation.Play("slide");	
		}
		
		if (boost) {
			time += Time.deltaTime;
			if (time > BOOST_TIME) {
				time = 0;
				boost = false;
				movePlayer.speed = movePlayer.refSpeed;
			}
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		
		string hitName = hit.gameObject.name;
		bool item = false;
		switch(hitName) {
		case "Cube(Clone)": 
			item = true;
			break;
		case "Bull(Clone)":
			item = true;
			break;
		case "Tablet(Clone)":
			item = true;
			break;
		case "Cylinder(Clone)":
			item = true;
			break;
		}
		
		if (item) {
			Destroy(hit.gameObject);
			score++;
			animation.Play("feed");
			boost = true;
			movePlayer.speed = movePlayer.refSpeed + BOOST;
			time = 0;
		}
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (10,10,100,50), "Score " + score)) {
			print ("Clicked!");
		}
	}
}
