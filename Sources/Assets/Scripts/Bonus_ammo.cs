using UnityEngine;
using System.Collections;

public class Bonus_ammo : MonoBehaviour {

	public static bool firstEnter = true;
	public AudioClip audio;
	public static bool ammo_detected = false;

	void OnTriggerEnter(Collider col)	{
		if (firstEnter && col.gameObject.tag == "Player") {
			firstEnter = false;
			AudioSource.PlayClipAtPoint(audio, transform.position);
			ammo_detected = true;
			Invoke("destroy",1);
			}
	}

	void destroy() {
		Destroy (this.gameObject);
	}
}
