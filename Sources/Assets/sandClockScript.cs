using UnityEngine;
using System.Collections;

public class sandClockScript : MonoBehaviour {
	private bool GUIEnabled = false;
	public GameObject particule ; // the particule system to activate to indicate the place to put the sand clock.


	// Use this for initialization
	void Start () {
		particule.GetComponent<ParticleSystem>().Stop() ;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		if (GUIEnabled){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nMaintenez Clic Droit pour prendre le sablier.");
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			GUIEnabled = true;
		}
	}

	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetButton ("Fire2")) {
				GUIEnabled = false;
				if (particule.GetComponent<ParticleSystem>().isStopped)
					particule.GetComponent<ParticleSystem>().Play();
			}

		}
	}
	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
				particule.GetComponent<ParticleSystem>().Stop() ;
				GUIEnabled = false;
		}
	}

}
