﻿using UnityEngine;
using System.Collections;

public class MunitionControl : MonoBehaviour {
	// Use this for initialization
	void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag == "Munitions")	{
			LanceurBatteReondissanteCSharp.nbCourantMunition+=2;
			Destroy(other.gameObject);
		}
	
	}

}
