using UnityEngine;
using System.Collections;

public class Bonus_script : MonoBehaviour {
	bool firstEnter = true;
	public AudioClip audio;

	void OnTriggerEnter(Collider col)	{
		if (firstEnter && col.gameObject.tag == "Player") {
			firstEnter = false;
			timer.time+=10;
			AudioSource.PlayClipAtPoint(audio, transform.position, 1);
			Invoke("destroy",1);
			}
	}

	void destroy() {
		Destroy (this.gameObject);
	}
}
