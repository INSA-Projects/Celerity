using UnityEngine;
using System.Collections;

public class StartGenerator : MonoBehaviour {
	public GameObject generator ;
	public AudioClip clickButton ;
	private WiiMote wii = null;
	private bool pressEtoActivate = false;		// "press E to activate"
	private bool sandClockGUI = false;			// "the experimentation is not ready"
	static public bool sandClockInTeleport = false;	// check if the sandclock is ready

	
	void Start (){
	}
	
	void FixedUpdate (){
	}

	void OnGUI() {
		if (sandClockGUI){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nCe n'est pas encore le moment d'appuyer.");
		} else if (pressEtoActivate){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nAppuyez sur E pour lancer l'experience.");
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			if (sandClockInTeleport) {
				pressEtoActivate = true;
			} else {
				sandClockGUI = true ;
				Debug.Log("lol");
			}
		}
	}

	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player") {
			if (((Input.GetKeyDown ("e")) || (wii != null && wii.b_C)) && sandClockInTeleport) {
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
			sandClockGUI = false;
		}
	}

	void desactivate () {
		gameObject.SetActive(false);
	}

}
