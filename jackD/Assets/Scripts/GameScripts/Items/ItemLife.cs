using UnityEngine;
using System.Collections;

public class ItemLife : MonoBehaviour {
	
	public int LIFE_TIME = 30; // seconds
	protected float time;
	
	protected bool grounded = false;
	
	void Start () {
		time = 0;
	}
	
	void Update () {
		time += Time.deltaTime;
		if (time > LIFE_TIME) {
			Destroy(gameObject);
		}
		
		if (!grounded) {
			Vector3 direction = -Vector3.up;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, direction, out hit, 1000f)) {
				Vector3 newPos = new Vector3(hit.point.x, hit.point.y + 1, hit.point.z);
				transform.position = newPos;
				grounded = true;
			}
		}
	}
}
