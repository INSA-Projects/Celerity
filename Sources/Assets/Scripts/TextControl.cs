using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {
public bool isQuitButton = false;
public bool isPlayButton = false;
public bool isInstructionButton = false;

	void OnMouseEnter(){
		gameObject.renderer.material.color = Color.green;
	}

void OnMouseExit(){
		gameObject.renderer.material.color = Color.white;
}

void OnMouseUp(){
	if(isQuitButton){
		Application.Quit();
	}
	if(isPlayButton){
			timer.time = 300;
			Health_Player.vie_courant = 5;
			LanceurBatteReondissanteCSharp.nbMaxMunition = 10;
			Application.LoadLevel(0);
	}
	if(isInstructionButton){
			Application.LoadLevel(2);
	}
}
}

