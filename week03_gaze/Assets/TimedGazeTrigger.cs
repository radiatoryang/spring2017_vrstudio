using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI; // you need this to talk to UI elements, like Images

public class TimedGazeTrigger : MonoBehaviour {

	// "SerializeField" exposes private vars to the inspector
	[SerializeField] float timeLookedAt = 0f; // time, in seconds, we've spent looking at this thing
	public Image progressImage; // don't forget: assign this in Unity Inspector

	public UnityEvent OnGazeComplete = new UnityEvent();

	void Update () {
		// get direction the user is looking
		Vector3 camLookDir = Camera.main.transform.forward;

		// direction from player to the target object (A to B = B-A)
		Vector3 vectorFromCamToTarget = transform.position - Camera.main.transform.position;

		// get the angle between our lookDir vs. the object's direction
		float angle = Vector3.Angle( camLookDir, vectorFromCamToTarget );

		// do stuff based on that angle
		if ( angle < 15f )  {
			timeLookedAt = Mathf.Clamp01( timeLookedAt + Time.deltaTime ); // after 1 second, this variable will be 1f
			// did we reach 100%? if so, fire the event and reset
			if ( timeLookedAt == 1f ) {
				timeLookedAt = 0f;
				OnGazeComplete.Invoke(); // fire any events associated with this event
			}
		} else {
			// "decay" progress if we're not looking at it
			timeLookedAt = Mathf.Clamp01( timeLookedAt - Time.deltaTime );
		}

		// update our UI image
		progressImage.fillAmount = timeLookedAt; // fillAmount is a float from 0-1
	}
}
