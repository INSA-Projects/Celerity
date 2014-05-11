using UnityEngine;
using System.Collections;
 
public class openTheDoor : MonoBehaviour {
	private bool GUIEnabled = false;
	public GameObject porte ;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(){
		GUIEnabled = true;
	}
	void OnTriggerExit() {
		GUIEnabled = false;
	}

	void OnGUI() {
		if (GUIEnabled){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "Appuie sur E pour déverrouiller la porte.\nA n'utiliser que pour les tests.\nDevra etre supprimé.");
		}
	}

	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown ("e")) {
				porte.GetComponent<ClosedDoor>().enabled = false;
				porte.GetComponent<PorteCSharp>().enabled = true;
				Destroy(this);
			}


		}

	}



}
