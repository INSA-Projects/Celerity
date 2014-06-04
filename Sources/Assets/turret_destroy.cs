using UnityEngine;
using System.Collections;

public class turret_destroy : MonoBehaviour {

	public GameObject turretHead;
	public GameObject explosion1;
	public GameObject explosion2;
	bool firstEnter = true;


	/* Destroy the turret when you hit it.
	 * Ok that's a ininteresting script.
	 * You have to add a test on the collider which enters the trigger, to check if it's a bullet from the cannon.
	 * But fuck it, you're not suppose to touch the turret with something else that a bullet, bitch.
	 * ... nevertheless, I hope you enjoy this game. 
	 * It was coded with the knees but I tried my best to make it fun.
	 * Kisses.
	 * */

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Arme" && firstEnter) {
			firstEnter = false;
			explosion1.particleSystem.Play();
			explosion2.particleSystem.Play();
			this.audio.Play();
			this.renderer.enabled = false;
			turretHead.gameObject.SetActive(false);
			Invoke("killObject",3);
		}
	}

	void killObject(){
		this.gameObject.SetActive(false);
	}


}
