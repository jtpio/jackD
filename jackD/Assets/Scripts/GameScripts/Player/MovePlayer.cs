using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	public float speed = 3.0f;
	public float rotateAngle = 1.0f;
	
	void Start () {
		transform.position.Set(125, 0, 125);
	}
	
	void Update () {
		// inputs
		
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)) {
			transform.Rotate(0,-rotateAngle,0);	
		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			transform.Rotate(0,rotateAngle,0);	
		}
		
		CharacterController controller = GetComponent<CharacterController>();
		controller.SimpleMove(transform.right * speed);
	}
}
