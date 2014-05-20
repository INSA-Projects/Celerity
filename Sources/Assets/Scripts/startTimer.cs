using UnityEngine;
using System.Collections;

public class startTimer : MonoBehaviour {
	public GameObject player; 		// the player
	public AudioManager am;

	// Use this for initialization
	void Start () {
		player.GetComponent<timer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player"){
			am.changeMusic(1);
			player.GetComponent<timer>().enabled = true;
			gameObject.SetActive(false);
		}
	}
}
