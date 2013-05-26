using UnityEngine;
using System.Collections;

public class Results : MonoBehaviour {
	
	public GUIStyle style = new GUIStyle();
	public GUIStyle buttonStyle = new GUIStyle();
	protected int score = 0;
	
	float timer;
	
	void Start () {
		 score = PlayerPrefs.GetInt("score");
		timer = 0;
	}
	
	void Update () {
		timer += Time.deltaTime;		
	}
	
	void OnGUI() {
		
		GUI.Box(new Rect(200f, 200f, 400f,40f), 
			"Well played!\n Your score: " + score, style
		);
		
		if (GUI.Button(new Rect(200f, 300f, 400f,40f),"Restart?", buttonStyle)) {
			Application.LoadLevel(0);
		}
	}
}
