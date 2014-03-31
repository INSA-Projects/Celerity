using UnityEngine;
using System.Collections;

/* This is used to prevent object from outreaching the speed of light */
public class SpeedLimiter : MonoBehaviour {
	
	private Rigidbody rb;
	
	void Awake() {
		rb = rigidbody;
	}
	
	void FixedUpdate() {
		float maxVelocity = TRR.SPEEDOFLIGHT;
		float sqrMaxVelocity = maxVelocity * maxVelocity;
		Vector3 v = rb.velocity;
		// Clamp the velocity, if necessary
		// Use sqrMagnitude instead of magnitude for performance reasons.
		if(v.sqrMagnitude > sqrMaxVelocity){ // Equivalent to: rigidbody.velocity.magnitude > maxVelocity, but faster.
			// Vector3.normalized returns this vector with a magnitude
			// of 1. This ensures that we're not messing with the
			// direction of the vector, only its magnitude.
			float x = v.normalized.x * maxVelocity;
			float y = v.normalized.y * maxVelocity;
			float z = v.normalized.z * maxVelocity;
			rb.velocity = new Vector3(x, y, z);
		}
	}
}
