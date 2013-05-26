using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	public GUIStyle style = new GUIStyle();
	public float speed = 1;
	
	protected float timer = 0;
	protected bool showText = false;
		
	void Start () {
		audio.Play();
	}
	
	void Update () {
		if (Application.platform == RuntimePlatform.Android && Input.touchCount >= 1) {
			Application.LoadLevel(1);
		} else if (Input.GetKey(KeyCode.S) ) {
			// press escape to skip
			Application.LoadLevel(1);
		}
		
		if (showText) {
			timer += Time.deltaTime;
			audio.volume = audio.volume - 0.004f;
			if (audio.volume <= 0) audio.volume = 0;
			if (timer >= 5) {
				audio.Stop ();
				Application.LoadLevel(1);
			}
		} else if (transform.position.x >= 53) {
			showText = true;
			timer = 0;
		} else {
			transform.Translate(speed * Time.deltaTime, 0, 0);	
		}
	}
	
	void OnGUI() {
		
		if (showText) {
			GUI.Box(new Rect(Screen.width/2-200, Screen.height/2, 400f,40f), 
			"Collect as much as possible before the time runs out", style
			);
		}
	}
}
