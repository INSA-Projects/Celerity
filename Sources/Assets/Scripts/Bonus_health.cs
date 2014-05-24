using UnityEngine;
using System.Collections;

public class Bonus_health : MonoBehaviour {
	bool GUIEnabled = false;
	bool firstEnter = true;
	public AudioClip audio;

	void OnTriggerEnter(Collider other){
		if (firstEnter && other.gameObject.tag == "Player") {
			firstEnter = false;
			GUIEnabled =true;
			this.gameObject.renderer.enabled = false;
			AudioSource.PlayClipAtPoint(audio, transform.position);
			Health_Player.vie_courant+=1;
			Invoke("destroy",4);
		}
	}

	void destroy() {
		Destroy(this.gameObject);
	}

	void OnGUI () {
		if (GUIEnabled){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nVous avez récupéré un point de vie.");
		}
	}
	



}
