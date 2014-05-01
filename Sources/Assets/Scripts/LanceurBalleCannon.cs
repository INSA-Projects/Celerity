using UnityEngine;
using System.Collections;

public class LanceurBalleCannon : MonoBehaviour {
	public AudioClip tir ;
	public Rigidbody projectile;
	
	public int speed = 20;
	public int dureeDeVie = 1;
	
	private Rigidbody instantiatedProjectile;

	public bool flag = false;
	public int time;
	public int timeMax = 20;
	
	void Start(){
	}

	void Update(){
		Attendre ();
		if (flag == true) {
			LanceurDeProjectile ();
		}
		Attendre ();
	}

	void LanceurDeProjectile(){

			instantiatedProjectile = (Rigidbody)Instantiate (projectile, transform.position + new Vector3 (0.0f, 1.42f, 1.253f), transform.rotation);
			instantiatedProjectile.velocity = transform.TransformDirection (0, speed, 0);
			instantiatedProjectile.AddForce (0, 10, 0);
			
			
			if (instantiatedProjectile) {
				flag = false;
				//Destruction de l'instance de la balle
				Destroy (instantiatedProjectile.gameObject, dureeDeVie);
			}
		

	}

	void Attendre(){
		flag = false;
		time = 0;
		while (time<timeMax) {
			time+=1;
		}
		flag = true;

	}

	
}