using UnityEngine;
using System.Collections;

public class Health_Player : MonoBehaviour {
	
	public static int vie_courant = 5;

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Ennemi" && vie_courant <= 0) {
						vie_courant -= 1;
			} else {
				Application.LoadLevel("GameOver");
		}
		
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width-250, 50, 200, 20), "Nombre de vies :"+vie_courant);
	}
}
