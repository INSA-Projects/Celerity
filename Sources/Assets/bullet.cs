using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	/* manage the bullet when it touch something */
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			Health_Player.vie_courant--;
			this.gameObject.SetActive(false);
		}
		Invoke("destroy",2);
	}

	void destroy() {
		this.gameObject.SetActive(false);
	}
}
