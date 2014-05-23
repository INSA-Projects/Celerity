using UnityEngine;
using System.Collections;

public class Bonus_ammo : MonoBehaviour {

	public static bool firstEnter = true;

	void OnTriggerEnter(Collider col)	{
		if (firstEnter && col.gameObject.tag == "Player") {
			firstEnter = false;
			this.audio.Play();
			LanceurBatteReondissanteCSharp.nbCourantMunition+=10;
			Invoke("destroy",1);
			}
	}

	void destroy() {
		Destroy (this.gameObject);
	}
}
