using UnityEngine;
using System.Collections;
 
public class teleportation : MonoBehaviour {
	public GameObject absorber;  	// center of the telporter
	GameObject levitatingObject ; 	// object in levitation in the teleporter

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "sand_clock") {
			StartGenerator.sandClockInTeleport = true;
		}
	}

	void OnTriggerStay (Collider col) {
		// if the player releases the sandclock in the teleporter 
		if ((col.gameObject.tag == "sand_clock") && !(AttraperCSharp.objetSaisi)){
			levitatingObject = col.gameObject ;

			// move the sandclock to the teleporter center
			Vector3 teleportCenter = absorber.transform.position;
			Vector3 vecteurMvt=(teleportCenter-levitatingObject.transform.position);
			levitatingObject.rigidbody.useGravity = false;
			levitatingObject.transform.Translate(vecteurMvt*Time.deltaTime*2,Space.World);
		}
	}

	void OnTriggerExit (Collider col) {
		// if the player releases the sandclock in the teleporter 
		if (col.gameObject.tag == "sand_clock"){
			StartGenerator.sandClockInTeleport = false;
		}
	}



}
