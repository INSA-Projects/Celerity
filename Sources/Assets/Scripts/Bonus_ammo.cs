using UnityEngine;
using System.Collections;

public class Bonus_ammo : MonoBehaviour {

	public static bool firstEnter = true;
	public static bool ammo_detected = false;

	void OnTriggerEnter(Collider col)	{
		if (firstEnter && col.gameObject.tag == "Player" && !LanceurBatteReondissanteCSharp.loaded) {
			firstEnter = false;
			ammo_detected = true;
			Invoke("destroy",1);
			}
	}

	void destroy() {
		Destroy (this.gameObject);
	}
}
