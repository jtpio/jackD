using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	public float posX = 125;
	public float posY = 125;
	public float speed = 900f;
	public float rotateAngle = 50f;
	
	void Start () {
		transform.position.Set(posX, 0, posY);
		animation.Play("slide");
	}
	
	void Update () {
		// inputs
		CharacterController controller = GetComponent<CharacterController>();
		
		float angle = rotateAngle;		
		if (Application.platform == RuntimePlatform.Android) {
			angle = Input.acceleration.x*100;
			transform.Rotate(0,angle * Time.deltaTime, 0);
		} else {
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)) {
				transform.Rotate(0,-angle * Time.deltaTime, 0);
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
				transform.Rotate(0,angle * Time.deltaTime, 0);
			}
		}
		controller.SimpleMove(transform.forward * speed * Time.deltaTime);
	}
}
