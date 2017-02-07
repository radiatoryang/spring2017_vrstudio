using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// rotate cam based on mouse
		Camera.main.transform.Rotate( -Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f );
		// un-roll the camera
		Camera.main.transform.eulerAngles = new Vector3( Camera.main.transform.eulerAngles.x,
														 Camera.main.transform.eulerAngles.y,
														 0f
													   );
	}
}
