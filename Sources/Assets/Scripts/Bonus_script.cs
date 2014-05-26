using UnityEngine;
using System.Collections;

public class Bonus_script : MonoBehaviour {
	bool firstEnter = true;
	public AudioClip audio;
	public float timeBonus;
	bool GUIEnabled = false;
	public GameObject clockComonent1;
	public GameObject clockComonent2;
	public GameObject clockComonent3;

	void OnTriggerEnter(Collider col)	{
		if (firstEnter && col.gameObject.tag == "Player") {
			firstEnter = false;
			timer.time+= timeBonus;
			AudioSource.PlayClipAtPoint(audio, transform.position, 1);
			this.gameObject.renderer.enabled = false;
			clockComonent1.renderer.enabled = false;
			clockComonent2.renderer.enabled = false;
			clockComonent3.renderer.enabled = false;
			GUIEnabled = true;
			Invoke("destroy",4);
			}
	}

	void destroy() {
		Destroy(this.gameObject);
	}
	
	void OnGUI () {
		if (GUIEnabled){
			GUI.backgroundColor = Color.blue;
			GUI.Box (new Rect ((Screen.width)/3,Screen.height - 200,(Screen.width)/3,60), "\nVous avez gagné "+ ((int) timeBonus)+" secondes.");
		}
	}
}
