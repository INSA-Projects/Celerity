﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Script de fermeture automatique de la porte apres ouverture
/// </summary>
public class ClosedDoor : MonoBehaviour {
	private bool GUIEnabled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUIEnabled){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nCe n'est pas le moment de partir.");
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			GUIEnabled = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Player") {
			GUIEnabled = false;
		}
	}
}
