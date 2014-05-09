using UnityEngine;
using System.Collections;

public class getCanon : MonoBehaviour {
	public GameObject player; 			// the player
	public GameObject canon ;			// the canon
	public GameObject sparkles;			// light effect under the canon
	bool GUIEnabled = false;
	bool firstEnter = true;				// enter only once in the trigger

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	/**
	 * active the canon
	 * */
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player" && firstEnter){
			firstEnter = false;
			this.audio.Play();
			player.GetComponent<GestionArmesCSharp>().SelectWeapon(1);
			canon.gameObject.renderer.enabled = false;
			GUIEnabled = true;
			sparkles.particleEmitter.minEmission = 0;
			sparkles.particleEmitter.maxEmission = 0;
		}
	}

	/**
	 * stop the light effect
	 * */
	void OnTriggerExit (Collider col) {
			if (col.gameObject.tag == "Player"){
				Invoke("disabler",5);
			}
	}

	/**
	 * stop the GUI
	 * */
	void disabler(){
		GUIEnabled = false;
		gameObject.SetActive(false);
	}

	void OnGUI(){
		if (GUIEnabled){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nAppuyez sur Clic Gauche pour tirer.");
		}
	}
}
