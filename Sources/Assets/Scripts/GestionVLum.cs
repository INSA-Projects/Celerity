using UnityEngine;
using System.Collections;
 
public class GestionVLum : MonoBehaviour {
	private int encoreVivants;
	private GameObject[] tab;
	private int ancienneV;
	// Use this for initialization
	void Start () {
		
		tab =  GameObject.FindGameObjectsWithTag("Ennemi");
		ancienneV = tab.Length;
		
	}
	
	// Update is called once per frame
	void Update () {
		tab =  GameObject.FindGameObjectsWithTag("Ennemi");
		encoreVivants = tab.Length;
		if(ancienneV != encoreVivants){
			TRR.SPEEDOFLIGHT -= 60;
			ancienneV = encoreVivants;
		}
	}
}
