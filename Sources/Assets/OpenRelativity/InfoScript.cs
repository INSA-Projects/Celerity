using UnityEngine;
using System.Collections;

/// <summary>
/// Script pour l'affichage des informations pour le joueur
/// </summary>
public class InfoScript : MonoBehaviour {
	public bool GUISpeedOfLight = true;	// enable speed of light printing

	// print out the current speed of light
	void OnGUI(){
		if (GUISpeedOfLight) {
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect(20, 20, 250, 25), "Vitesse de la lumiere : "+ printSpeedOfLight());
		}
	}

	public string printSpeedOfLight() {
		if (TRR.SPEEDOFLIGHT == TRR.c){
			return "~ 300 000 km/s";
		} else {
			return ""+ ((int) TRR.SPEEDOFLIGHT) +" m/s";
		}
	}
	
}
