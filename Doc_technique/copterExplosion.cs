using UnityEngine;
using System.Collections;

/// <summary>
/// Script pour l'explosion de l'hélicoptère 
/// </summary>
public class copterExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(){
		this.audio.Play();
		this.GetComponent<copterExplosion>().enabled = false;
	}

}
