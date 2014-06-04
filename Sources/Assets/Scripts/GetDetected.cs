using UnityEngine;
using System.Collections;

public class GetDetected : MonoBehaviour {
	public GameObject turretHead;		// head of the turret

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			turretHead.GetComponent<Turret_script>().player_detected = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			turretHead.GetComponent<Turret_script>().player_detected = false;
		}
	}

}
