using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	void Start () {
	}
	
	void Update () {
		transform.Translate(0.4f,0,0);
	}
}
