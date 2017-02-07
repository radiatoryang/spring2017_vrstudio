using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTrigger : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		// is the camera looking / pointing at something?
	
		// get direction the user is looking
		Vector3 camLookDir = Camera.main.transform.forward;

		// direction from player to the target object (A to B = B-A)
		Vector3 vectorFromCamToTarget = transform.position - Camera.main.transform.position;

		// get the angle between our lookDir vs. the object's direction
		float angle = Vector3.Angle( camLookDir, vectorFromCamToTarget );

		// do stuff based on that angle
		if ( angle < 15f )  {
			transform.localScale *= 1.01f; // if we are looking within 15 degree FoV, grow object
		}
	}
}
