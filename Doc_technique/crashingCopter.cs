using UnityEngine;
using System.Collections;

/// <summary>
/// Script pour l'explosion de l'hélicoptère (A preciser !!!)
/// </summary>
public class crashingCopter : MonoBehaviour {
	public GameObject copter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player"){
			copter.rigidbody.useGravity = true;
		}
	}
}
