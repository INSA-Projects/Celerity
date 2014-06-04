using UnityEngine;
using System.Collections;

public class Health_Player : MonoBehaviour {
	public static int vie_courant = 5;
	// GUI enabler
	bool GUIEnabled = false;

	void Update () {
		if (vie_courant <=0 ){
			Application.LoadLevel("GameOver");
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (3*Screen.width/7, 20, 150, 25), "Points de vie : "+vie_courant);
	}
}
