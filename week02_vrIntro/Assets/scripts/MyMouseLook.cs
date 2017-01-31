using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to access Unity's VR functions, add the VR namespace
using UnityEngine.VR;

public class MyMouseLook : MonoBehaviour {

	void Start () {
		// are we using VR?
		if ( VRDevice.isPresent == true ) {
			// if so, print VR HMD model name to the console
			Debug.Log("VR is enabled! " + VRDevice.model);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// do backup emergency input code ONLY if VR isn't working
		if ( VRDevice.isPresent == false ) {
			// cache Main Camera in a variable to use for later
			var myCam = Camera.main.transform;

			// rotate camera based on mouse delta speed... X axis is vertical mouse, Y axis is horizontal mouse
			myCam.Rotate( -Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f );

			// unroll our camera's Z angle
			myCam.localEulerAngles = new Vector3( myCam.localEulerAngles.x, myCam.localEulerAngles.y, 0f );
		}
	}
}
