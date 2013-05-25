using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	protected float speed = 3.0f;
	
	void Start () {
	}
	
	void Update () {
		//transform.Translate(0.4f,0,0);
		CharacterController controller = GetComponent<CharacterController>();
        controller.SimpleMove(transform.right * speed);
	}
}
