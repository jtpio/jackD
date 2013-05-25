using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	public float speed = 3.0f;
	public float rotateAngle = 1.0f;
	
	void Start () {
		
	}
	
	void Update () {
		// inputs
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(0,-rotateAngle,0);	
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(0,rotateAngle,0);	
		}
		
		CharacterController controller = GetComponent<CharacterController>();
        controller.SimpleMove(transform.right * speed);
	}
}
