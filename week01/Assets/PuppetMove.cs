using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetMove : MonoBehaviour {

	float xDirection = 2f;
	
	// Update is called once per frame
	void Update () {

		// Time.deltaTime = the duration of the last frame in seconds
		// multiply by Time.deltaTime = makes a behavior framerate INDEPENDENT
		transform.position += new Vector3(xDirection, 0f, 0f) * Time.deltaTime;

		// turn around if you reach the edge of the cave
		if ( transform.position.x > 2f || transform.position.x < -2f ) {
			xDirection *= -1f; // multiply by -1f to flip the direction
		}
			
	}
}
