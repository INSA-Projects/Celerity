using UnityEngine;
using System.Collections;

public class Bonus_script : MonoBehaviour {
	bool firstEnter = true;

	void OnTriggerEnter(Collider col)	{
		if (firstEnter && col.gameObject.tag == "Player") {
			firstEnter = false;
			this.audio.Play();
			timer.time+=5;
			Invoke("destroy",1);
			}
	}

	void destroy() {
		Destroy (this.gameObject);
	}
}
