using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTrigger : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// 1. declare your raycast
		Ray ray = new Ray( Camera.main.transform.position, Camera.main.transform.forward );

		// 2. setup our RaycastHit info variable too
		RaycastHit rayHit = new RaycastHit();

		// 3. we're ready to shoot our raycast...
		if ( Physics.Raycast( ray, out rayHit, 10f ) ) {
			if ( rayHit.transform == this.transform ) { // are we actually looking at this thing?
				transform.localScale *= 1.01f; // grow 1% per frame if we're looking at this
			}
		}

	}
}
