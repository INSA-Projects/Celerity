using UnityEngine;
using System.Collections;

public class SpeedOfLightManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TRR.SPEEDOFLIGHT = 20;
	}

	public static void increaseSpeedOfLight (float n) {
		float temp = TRR.SPEEDOFLIGHT + n ;
		if (temp < TRR.c){
			TRR.SPEEDOFLIGHT = temp;
		} else {
			TRR.SPEEDOFLIGHT = TRR.c ;
		}
	}

	public static void decreaseSpeedOfLight (float n) {
		float temp = TRR.SPEEDOFLIGHT - n ;
		if (temp > 0){
			TRR.SPEEDOFLIGHT = temp;
		} else {
			TRR.SPEEDOFLIGHT = 1;
		}
	}

	// Update is called once per frame
	void Update () {
		// Allow changing the speed of light
		if(Input.GetKeyDown("m"))	{
			decreaseSpeedOfLight(2000000f);
		}
		else if(Input.GetKeyDown("n"))	{
			increaseSpeedOfLight(200000f);
		}
	}


}
