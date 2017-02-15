using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR; // lets us use SteamVR functions easily

public class BasicPickup : MonoBehaviour {

	public SteamVR_ControllerManager cm; // assign in Inspector, another way of accessing controllers
	Rigidbody currentHeld;

	// this is a "property", like a variable that can call code when you use it
	SteamVR_Controller.Device myDevice {
		get { return SteamVR_Controller.Input( (int)GetComponent<SteamVR_TrackedObject>().index ); } 
	}
		
	// 1. DETECT IF A PHYSICS RIGIDBODY PICKUP THING IS WITHIN OUR TRIGGER
	void OnTriggerStay (Collider other) {
		// 2. DETECT IF WE ARE HOLDING DOWN THE CONTROLLER TRIGGER
		if ( myDevice.GetHairTrigger() ) {

			// 3. turn off physics simulation for the thing we're picking up
			currentHeld = other.GetComponent<Rigidbody>();
			currentHeld.isKinematic = true; // turns off physics simulation for this thing

			// 4. parent the object to the controller
			currentHeld.transform.SetParent( this.transform );
		}
	}
		
	void Update () {
		// 5. DROP A CURRENTLY HELD OBJECT IF WE RELEASE THE TRIGGER
		if ( currentHeld != null && myDevice.GetHairTrigger() == false ) {
			currentHeld.isKinematic = false; // turn on physics simulation again
			currentHeld.transform.parent = null; // unparent the object
			currentHeld = null; // forget about this object
		}

		// EXTRA: getting other buttons
		myDevice.GetPress( EVRButtonId.k_EButton_Grip ); // grip button
	}
}
