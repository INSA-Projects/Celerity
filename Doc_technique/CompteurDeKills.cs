using UnityEngine;
using System.Collections;

/// <summary>
/// Compte le nombre d'ennemis tues 
/// </summary>
public class CompteurDeKills : MonoBehaviour {
	public string stringToEdit = "PC atteints : 0";
	public static int nbKills;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		stringToEdit = "PC atteints : " + nbKills;
		OnGUI();
	}


	
	
	void OnGUI () {
		// Make a text field that modifies stringToEdit.
		// stringToEdit = GUI.TextField (Rect (10, 10, 200, 20), stringToEdit, 25);
	}

}
