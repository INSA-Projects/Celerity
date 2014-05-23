using UnityEngine;
using System.Collections;

/// <summary>
/// Script pour la gestion du canon
/// </summary>
public class LanceurBatteReondissanteCSharp : MonoBehaviour {
	public AudioClip tir ;
	public Rigidbody projectile;

	public int speed = 40;		
	public int dureeDeVie = 5;	//duree de vie d'une balle
	
	private Rigidbody instantiatedProjectile;
	private WiiMote wii = null;

	/*nombre max de munition*/
	public int nbMaxMunition = 50;
	/*nombre de munition à rajouter lorsque vous ramassez des munitions*/
	public int nbMunitionRecharge = 10;
	/*nombre courant de munition*/
	public static int nbCourantMunition= 10; 
	// true if the gun is loaded, false if you're reloading
	bool loaded = true;
	// true if the gun is out of ammo
	bool emptyMagazine = false;
	// true if you're totally out of ammo
	bool outOfAmmo = false;
	// number of ammo reloaded when you reload
	public int  reloadAmount = 10;
	public AudioClip reloadSound; //reload soundClip	
	public bool GUIAmmo = true;

	void Start() {
		if(wii == null)
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
	}

	void Update(){
		if(wii == null) {
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
		}
		if (nbCourantMunition >= 1) {
			if ((Input.GetButtonDown ("Fire1") || (wii != null && wii.b_B)) && SynchroTirCSharp.tirPossible () && loaded) {
				audio.PlayOneShot (tir);
				instantiatedProjectile = (Rigidbody)Instantiate (projectile, transform.position, transform.rotation);
				instantiatedProjectile.velocity = Camera.main.transform.TransformDirection (0, 0, speed);
				instantiatedProjectile.AddForce (0, 10, 0);
				Physics.IgnoreCollision (instantiatedProjectile.collider, transform.root.collider);
				nbCourantMunition -= 1;
				if (nbCourantMunition <= 0) {
					emptyMagazine = true;
				}
			}
			if (instantiatedProjectile) {
				//Destruction de l'instance de la balle
				Destroy (instantiatedProjectile.gameObject, dureeDeVie);
			}
		} else {
			loaded = false;
			if (Bonus_ammo.firstEnter)reload();
		}
	}

	void reload() {
		if (emptyMagazine && !outOfAmmo) {
			emptyMagazine = false;
			AudioSource.PlayClipAtPoint (reloadSound, transform.position, 1); //plays reload soundclips
			Invoke("reloading", 1.5f);
			emptyMagazine = false;
		}
	}
	
	void reloading(){
		nbCourantMunition += reloadAmount;
		nbMaxMunition -= reloadAmount;
		loaded = true;
		if (nbMaxMunition==0) {
			outOfAmmo = true;
			Bonus_ammo.firstEnter = true;
		}
	}

	void OnGUI () {
		if (GUIAmmo){
			GUI.backgroundColor = Color.blue;
			if(nbCourantMunition>0){
				GUI.Box (new Rect (Screen.width-250, 20, 200, 25), "Munitions : "+ nbCourantMunition+"/"+nbMaxMunition);
			} else if (outOfAmmo) {
				GUI.Box (new Rect (Screen.width-250, 20, 200, 25), "Plus de munitions.");
			} else {
				GUI.Box (new Rect (Screen.width-250, 20, 200, 25), "Rechargement en cours...");
			}
		}
	}
}