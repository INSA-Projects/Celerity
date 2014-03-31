using UnityEngine;
using System.Collections;

public class LanceurBatteReondissanteCSharp : MonoBehaviour {
	public AudioClip tir ;
	public Rigidbody projectile;

	public int speed = 40;
	public int dureeDeVie = 5;
	
	private Rigidbody instantiatedProjectile;
	private WiiMote wii = null;
	
	
	void Start() {
		if(wii == null)
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
			
	}
	
	
void Update(){ 
		
		
		if(wii == null) {
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
		}
		
		if( (Input.GetButtonDown( "Fire1" ) || (wii != null && wii.b_B))&& SynchroTirCSharp.tirPossible() ){
				audio.PlayOneShot(tir);
				instantiatedProjectile = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
				instantiatedProjectile.velocity = Camera.main.transform.TransformDirection(0, 0, speed);
				instantiatedProjectile.AddForce (0, 10, 0);
				Physics.IgnoreCollision( instantiatedProjectile.collider, transform.root.collider );
		}
		
	
	
		if(instantiatedProjectile){
			//Destruction de l'instance de la balle
			Destroy (instantiatedProjectile.gameObject, dureeDeVie);
		}
	}
}
