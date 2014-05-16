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
			GUI.Box (new Rect(50, 20, 200, 25), "Vitesse de la lumiere : "+ TRR.SPEEDOFLIGHT);
		}
	}
	
}
