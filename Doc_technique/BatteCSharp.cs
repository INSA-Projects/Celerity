using UnityEngine;
using System.Collections;

/// <summary>
/// Gestion de la batte (dans le projet a été supprimée pour le projet Celerity 2.0
/// </summary>
public class BatteCSharp : MonoBehaviour {
	private WiiMote wii = null;
	
	// Use this for initialization
	void Start () {
		if(wii == null)
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
	}
	
	
	// Update is called once per frame
	void Update () {
		if(wii == null)
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
			
		
		
		if((Input.GetButtonDown( "Fire1" ) || (wii != null && wii.b_B)) && SynchroTirCSharp.tirPossible() )
		{
			// Joue l'animation AnimBatte ie un coup de batte
			animation.Play("AnimBatte", PlayMode.StopAll);
		}
	}
}
