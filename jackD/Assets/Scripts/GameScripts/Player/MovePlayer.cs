using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {
	
	public float posX = 125;
	public float posY = 125;
	public float speed = 900f;
	public float refSpeed;
	public float rotateAngle = 50f;
	public float tiltAngle = 1f;
	
	void Start () {
		refSpeed = speed;
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
				transform.Rotate(transform.forward, Mathf.Min (angle/10, 40) * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
				transform.Rotate(0,angle * Time.deltaTime, 0);
				transform.Rotate(transform.forward, - Mathf.Min (angle/10, 40)*Time.deltaTime);
			}
		}
		controller.SimpleMove(transform.forward * speed * Time.deltaTime);
	}
}
