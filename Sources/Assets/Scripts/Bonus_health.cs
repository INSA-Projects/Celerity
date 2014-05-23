using UnityEngine;
using System.Collections;

public class Bonus_health : MonoBehaviour {

	public bool firstEnter = true;
	public AudioClip audio;

	void OnTriggerEnter(Collider other){

		if (firstEnter && other.gameObject.tag == "Player") {
			if(Health_Player.vie_courant>0){
				firstEnter = false;
				AudioSource.PlayClipAtPoint(audio, transform.position);
				Health_Player.vie_courant+=1;
				Destroy(this.gameObject);
			}
		}
		
	}
}
