using UnityEngine;
using System.Collections;

public class Turret_script : MonoBehaviour {
	public Transform LookAtTarget;
	public float damp = 6.0f;
	public Transform bullitPrefab;
	public int savedTime = 0;

	public int dureeDeVie = 2;

	public bool ok = false;

	
	// Update is called once per frame
	void Update () {
		Quaternion rotate;
		int seconds;
		int oddeven;
		if (LookAtTarget) {
			rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position)*Quaternion.Euler(0,180,0);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotate,(float) Time.time*damp);
			seconds = (int) Time.time;
			oddeven = (seconds%10);

			if(oddeven == 0){
				Shoot(seconds);
			}

		
		}
	
	}


	void Shoot(int seconds){
		if(seconds != savedTime && ok == true){
			/*Transform bullit;
			bullit = (Transform) Instantiate (bullitPrefab, transform.Find ("spawnPoint").transform.position, Quaternion.identity);
			bullit.rigidbody.AddForce (transform.forward * 1000);*/

			Rigidbody ball = (Rigidbody) Instantiate(bullitPrefab, transform.position, transform.rotation);
			ball.rigidbody.AddForce(transform.forward*1500);
			if (ball){
				//Destruction de l'instance de la balle
				Destroy (ball.gameObject, dureeDeVie);
				ok = true;
			}

			savedTime = seconds;
		}
	}
}
