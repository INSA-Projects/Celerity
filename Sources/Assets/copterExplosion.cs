using UnityEngine;
using System.Collections;

public class copterExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		flammes.particleSystem.Stop();
		explosion.particleSystem.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(){
		this.audio.Play();
		this.GetComponent<copterExplosion>().enabled = false;
	}

}
