using UnityEngine;
using System.Collections;
 
public class timer: MonoBehaviour {
	public  static float time=300;
	int minutes ;
	int seconds ;
	public float speedLightDecreaser;
	public float speedLightStopper;

	void Update () {
		time -= Time.deltaTime;
		minutes = ((int) time) / 60;
		seconds = ((int) time) % 60;		
		if (time<=0){
			Application.LoadLevel("GameOver");
		}
		if (TRR.SPEEDOFLIGHT >= speedLightStopper){
			SpeedOfLightManager.decreaseSpeedOfLight(speedLightDecreaser);
		}
	}
	
	void OnGUI(){
		string coinText ;
		if(Mathf.Round(seconds) <= 9){
			coinText="Temps restant avant implosion : "+ minutes.ToString("f0") + ":0" + seconds.ToString("f0");
		} else {
			coinText="Temps restant avant implosion : "+ minutes.ToString("f0") + ":" + seconds.ToString("f0");
		}
		GUI.Box(new Rect(20, 60, 250, 25),coinText);
	}

}
