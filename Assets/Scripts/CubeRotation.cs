using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour {

	public float speed, tiltSpeed;
	private const float MAX_UP = 2f;
	private const float MAX_DOWN = 0.95f;
	private Vector3 target = new Vector3(0, MAX_UP, 0);
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * speed);

		if (transform.position == target && target.y != MAX_DOWN)
			target.y = MAX_DOWN;
		else if(transform.position == target && target.y == MAX_DOWN)
			target.y = MAX_UP;

		transform.Rotate (Vector3.up * tiltSpeed);
		transform.Rotate (Vector3.left * tiltSpeed);
		transform.Rotate (Vector3.forward * tiltSpeed);
	}
}
