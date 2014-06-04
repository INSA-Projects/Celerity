using UnityEngine;
using System.Collections;

public class Bonus_ammo : MonoBehaviour {
	bool firstEnter = true;
	/*nombre de munition à rajouter lorsque vous ramassez des munitions*/
	public int nbMunitionRecharge;
	// mesh renderer to desactivate when you get the ammo
	public GameObject bulletShape1;
	public GameObject bulletShape2;
	// GUI enabler
	bool GUIEnabled = false;

	void OnTriggerEnter(Collider col)	{
		if (firstEnter && col.gameObject.tag == "Player") {
			firstEnter = false;
			this.gameObject.audio.Play();
			LanceurBatteReondissanteCSharp.nbMaxMunition += nbMunitionRecharge;
			GUIEnabled = true;
			bulletShape1.renderer.enabled = false;
			bulletShape2.renderer.enabled = false;
			Invoke("destroy",5);
		}
	}

	void destroy() {
		this.gameObject.audio.Stop();
		GUIEnabled = false;
		Destroy (this.gameObject);
	}

	void OnGUI () {
		if (GUIEnabled){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nVous avez récupéré "+nbMunitionRecharge+" munitions.");
		}
	}
}
