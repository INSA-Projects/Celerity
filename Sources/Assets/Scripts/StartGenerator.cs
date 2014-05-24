using UnityEngine;
using System.Collections;

/// <summary>
/// Script pour la gestion du fonctionnement du generateur
/// </summary>
public class StartGenerator : MonoBehaviour {
	private WiiMote wii = null;
	public GameObject generator ;				// the generator to activate
	public AudioClip clickButton ;				// sound of the button when it's activated

	static public bool sandClockInTeleport = false;	// check if the sandclock is ready
	private bool pressEtoActivate = false;		// "press E to activate"
	private bool sandClockGUI = false;			// "the experimentation is not ready"
	
	public GameObject mainLightEffect;			// the main light effect of the teleportation
	public GameObject vortexLightEffect;		// the vortex effect
	public GameObject lightEffect1;				// the 4 teleportation devices light effects
	public GameObject lightEffect2;
	public GameObject lightEffect3;
	public GameObject lightEffect4;
	public GameObject audioLightEffect;			// sound of the teleportation
	public GameObject audioAlert;				// sound of the failure alert

	public GameObject player;					// the player
	public GameObject spawnPoint;				// where the player will be teleported

	public GUIText info;
	void Start (){
	}
	
	/**
	 * printing functions for the player
	 * */
	void OnGUI() {
		if (sandClockGUI){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nCe n'est pas encore le moment d'appuyer.");
		} else if (pressEtoActivate){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nAppuyez sur E pour lancer l'experience.");
		}
	}

	/**
	 * activate the right printings
	 * */
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			if (sandClockInTeleport) {
				pressEtoActivate = true;
			} else {
				sandClockGUI = true ;
			}
		}
	}

	/**
	 * launch the teleportation process
	 * */
	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player") {
			if (((Input.GetKeyDown ("e")) || (wii != null && wii.b_C)) && sandClockInTeleport) {
				// start the generator
				audio.PlayOneShot(clickButton);
				generator.animation.Play();
				generator.audio.Play();
				// disable the button
				Invoke("desactivate", clickButton.length);

				// launch the dialogue
				DialogueManager.changeDialogue(2);

				// start the teleportation
				vortexLightEffect.particleSystem.Play();
				lightEffect1.particleSystem.Play();
				lightEffect2.particleSystem.Play();
				lightEffect3.particleSystem.Play();
				lightEffect4.particleSystem.Play();
				audioLightEffect.audio.Play();
				// start the failure
				Invoke ("teleportationFailure",5);
			}
		}
	}

	/**
	 * launch the particle vortex
	 * */
	void teleportationFailure(){
		audioAlert.audio.Play();
		mainLightEffect.particleSystem.Play();
		// launch the player's teleportation
		Invoke ("chaoticTeleportation",10);
	}

	/**
	 * launch the player's erratic teleportation
	 * */
	void chaoticTeleportation(){
		player.transform.position = spawnPoint.transform.position;
		mainLightEffect.particleSystem.Stop();
		vortexLightEffect.particleSystem.Stop();
		lightEffect1.particleSystem.Stop();
		audioLightEffect.audio.Stop();
		audioAlert.audio.Stop();
		}

	/**
	 * desactivate all printings
	 * */
	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Player") {
			pressEtoActivate = false;
			sandClockGUI = false;
		}
	}

	/**
	 * destroy the button trigger
	 * */
	void desactivate () {
		gameObject.SetActive(false);
	}

}
