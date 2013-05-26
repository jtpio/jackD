using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {
	
	public float BOOST = 800;
	public float BOOST_TIME = 2;
	
	public float SLOW = -800;
	public float SLOW_TIME = 2;
	
	protected MovePlayer movePlayer;
	
	protected float timeBoost = 0;
	protected float timeSlow = 0;
	protected bool boost = false;
	protected bool slow = false;
	
	// scoring
	protected int score = 0;
	protected float timer = 0;
	
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
			timeBoost += Time.deltaTime;
			if (timeBoost > BOOST_TIME) {
				timeBoost = 0;
				boost = false;
				movePlayer.speed = movePlayer.refSpeed;
			}
		} else if (slow) {
			timeSlow += Time.deltaTime;
			if (timeSlow > SLOW_TIME) {
				timeSlow = 0;
				slow = false;
				movePlayer.speed = movePlayer.refSpeed;
			}	
		}
		
		// update timer
		timer += Time.deltaTime;
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		
		string hitName = hit.gameObject.name;
		bool item = false;
		bool plant =  false;
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
		case "plantGrowth(Clone)":
			plant = true;
			break;
		}
		
		if (item) {
			Destroy(hit.gameObject);
			score++;
			animation.Play("feed");
			boost = true;
			movePlayer.speed = Mathf.Min (movePlayer.refSpeed + 1000, movePlayer.speed + BOOST);
			timeBoost = 0;
		} else if (plant) {
			Destroy(hit.gameObject);
			slow = true;
			movePlayer.speed = Mathf.Max (movePlayer.refSpeed - 800, movePlayer.speed - SLOW);
			timeSlow = 0;
		}
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (10,10,100,50), "Time: " + timeToString(timer))) {
			
		}
		
		if (GUI.Button (new Rect (10,70,100,50), "Score " + score)) {
			print ("Clicked!");
		}
	}
	
	string timeToString(float time) {
		int seconds = (int)Mathf.Round(time);
		int min = (int)Mathf.Floor(seconds/60);
		seconds = (int)Mathf.Round(seconds - min * 60);
		
		string res = seconds + "\"";
		if (seconds < 10) res = "0" + res;
		res = min + "'" + res;
		if (min < 10) res = "0" + res;
		return res;
	}
}
