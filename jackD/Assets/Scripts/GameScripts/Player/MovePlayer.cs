using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	public float speed = 300f;
	public float rotateAngle = 50f;
	
	void Start () {
		transform.position.Set(125, 0, 125);
	}
	
	void Update () {
		// inputs
		
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)) {
			transform.Rotate(0,-rotateAngle * Time.deltaTime, 0);	
		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			transform.Rotate(0,rotateAngle * Time.deltaTime, 0);
		}
		
		CharacterController controller = GetComponent<CharacterController>();
		controller.SimpleMove(transform.right * speed * Time.deltaTime);
	
	}
}
