using UnityEngine;
using System.Collections;

public class LanceurBatteReondissanteCSharp : MonoBehaviour {
	public AudioClip tir ;
	public Rigidbody projectile;

	public int speed = 40;
	public int dureeDeVie = 5;
	
	private Rigidbody instantiatedProjectile;
	private WiiMote wii = null;

	/*nombre max de munition*/
	public int nbMaxMunition = 60;
	/*nombre de munition à rajouter*/
	public int nbMunitionRecharge = 5;
	/*nombre courant de munition*/
	public static int nbCourantMunition=10;

	public int  reloadTime = 3; //time to reload
	
	public int  reloadAmount = 10;
	
	public GUIText ammo; //GUI text for our ammo count
	
	public AudioClip reloadSound; //reload soundClip

	
	void Start() {
		if(wii == null)
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
			
	}
	
	
void Update(){ 
		if(wii == null) {
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
		}

		if (nbCourantMunition >= 1) {
						if (nbCourantMunition <= nbMaxMunition) {
								if ((Input.GetButtonDown ("Fire1") || (wii != null && wii.b_B)) && SynchroTirCSharp.tirPossible ()) {
										audio.PlayOneShot (tir);
										instantiatedProjectile = (Rigidbody)Instantiate (projectile, transform.position, transform.rotation);
										instantiatedProjectile.velocity = Camera.main.transform.TransformDirection (0, 0, speed);
										instantiatedProjectile.AddForce (0, 10, 0);
										Physics.IgnoreCollision (instantiatedProjectile.collider, transform.root.collider);
										/*diminution du nbMunitionCourant*/
										nbCourantMunition -= 1;
								}
							
								if (instantiatedProjectile) {
										//Destruction de l'instance de la balle
										Destroy (instantiatedProjectile.gameObject, dureeDeVie);
								}
						}
		} else {

						if (Input.GetKeyDown ("r")) {
				
								AudioSource.PlayClipAtPoint (reloadSound, transform.position, 1); //plays reload soundclips
				
								nbCourantMunition += reloadAmount; 
				
								nbMaxMunition -= reloadAmount; 
				
						}

			}
		
}
	

void OnGUI () {
	if(nbCourantMunition>0){
		ammo.text = "Munitions: "+ nbCourantMunition + "/" + nbMaxMunition;
		/*GUI.Box (new Rect (40, 40, 40, 40), nbCourantMunition + "/" + nbMaxMunition);	*/
	}else{
		ammo.text = "Touche R pour recharger";
	}
}



}