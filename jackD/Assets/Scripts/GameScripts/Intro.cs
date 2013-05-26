using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	public float speed = 1;
	
	void Start () {
	
	}
	
	void Update () {
		if (transform.position.x >= 53) {
			Application.LoadLevel(1);
			return;
		}
		transform.Translate(speed * Time.deltaTime, 0, 0);	
	}
}
