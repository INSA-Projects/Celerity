using UnityEngine;
using System.Collections;
 
public class timer: MonoBehaviour {
	public  static float time=20;
	public float minutes ;
	public float seconds ;
	public float fraction ;

	void Update () {
		time -= Time.deltaTime;
		 minutes = time / 60;
		seconds = time % 60;
		fraction = (time * 100) % 100;
		
		if (time<=0)
			Application.LoadLevel("GameOver");
	}
	
		void OnGUI(){
			string coinText ;
			if(Mathf.Round(seconds) <= 9)
		{
			 coinText="Timer : "+ minutes.ToString("f0") + ":0" + seconds.ToString("f0");
		}
		else
		{
			coinText="Timer : "+ minutes.ToString("f0") + ":" + seconds.ToString("f0");
		}
			GUI.Box(new Rect(20,50,150,20),coinText);
		 }
}
