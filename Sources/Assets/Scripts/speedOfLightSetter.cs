using UnityEngine;
using System.Collections;

public class speedOfLightSetter : MonoBehaviour {
	public GameObject player;				// guess what it is...
	public float speedLightSet;				// new value of speed of light
	public float speedLightDecreaserSet;	// new value of the "decrease speed" of speed of light
	public float speedLightStopperSet;		// new value of the decrasing limit (to avoid speed of light = 1m/s)
	private bool triggered = false;
	private bool firstEnter = true;

	// Use this for initialization
	void Start () {
	}

	/**
	 * smoothly set the new value of speed of light (avoiding brutal setting)
	 * also set the new value of the decrease speed (avoiding a brutal value of speed of light)
	 * */
	void Update () {
		if (triggered){
			if (TRR.SPEEDOFLIGHT*0.8f > speedLightSet) {
				SpeedOfLightManager.decreaseSpeedOfLight(0.2f*TRR.SPEEDOFLIGHT);
			} else {
				TRR.SPEEDOFLIGHT = speedLightSet ;
				player.GetComponent<timer>().speedLightDecreaser = speedLightDecreaserSet;
				player.GetComponent<timer>().speedLightStopper = speedLightStopperSet;
				triggered = false;
			}
		}
	}

	/**
	 * launch the setting of the new values
	 * */
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player" && firstEnter) {
			firstEnter = false;
			triggered = true;
		}
	}

}
