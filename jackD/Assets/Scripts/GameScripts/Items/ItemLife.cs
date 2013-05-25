using UnityEngine;
using System.Collections;

public class ItemLife : MonoBehaviour {
	
	public int LIFE_TIME = 10; // seconds
	protected float time;
	
	void Start () {
		time = 0;
	}
	
	void Update () {
		time += Time.deltaTime;
		if (time > LIFE_TIME) {
			Destroy(gameObject);
		}
	}
}
