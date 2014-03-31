using UnityEngine;
using System.Collections;

public class SpeedOfLightManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TRR.SPEEDOFLIGHT = 200f;
	}
	
	// Update is called once per frame
	void Update () {
		// Allow changing the speed of light
		if(Input.GetKeyDown("m"))
		{
			TRR.SPEEDOFLIGHT -= 2f;
		}
		else if(Input.GetKeyDown("n"))
		{
			TRR.SPEEDOFLIGHT += 2f;
		}
	}
}
