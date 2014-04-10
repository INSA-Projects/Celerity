using UnityEngine;
using System.Collections;

public class StartGenerator : MonoBehaviour {
	public GameObject generator ;
	public AudioClip clickButton ;
	private WiiMote wii = null;
	
	void Start (){
	}
	
	void FixedUpdate (){
	}
	
	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player") {
			Debug.Log("Activer : E");
			if ((Input.GetKeyDown ("e")) || (wii != null && wii.b_C)) {
				audio.PlayOneShot(clickButton);
				generator.animation.Play();
				generator.audio.Play();
				Invoke("desactivate", clickButton.length);
			}
		}
	}

	void desactivate () {
		gameObject.SetActive(false);
	}

	void OnTriggerExit (Collider other){
	}
}
