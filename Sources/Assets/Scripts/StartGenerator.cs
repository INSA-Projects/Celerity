using UnityEngine;
using System.Collections;

public class StartGenerator : MonoBehaviour {
	public GameObject generator ;
	public AudioClip clickButton ;
	private WiiMote wii = null;
	private bool pressEtoActivate = false;


	
	void Start (){
	}
	
	void FixedUpdate (){
	}

	void OnGUI() {
		if (pressEtoActivate){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nAppuyez sur E pour activer l'interrupteur.");
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			pressEtoActivate = true;
		}
	}

	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player") {
			if ((Input.GetKeyDown ("e")) || (wii != null && wii.b_C)) {

				audio.PlayOneShot(clickButton);
				generator.animation.Play();
				generator.audio.Play();
				Invoke("desactivate", clickButton.length);
			}
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			pressEtoActivate = false;
		}
	}

	void desactivate () {
		gameObject.SetActive(false);
	}

}
