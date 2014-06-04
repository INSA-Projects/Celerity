using UnityEngine;
using System.Collections;

public class Turret_script : MonoBehaviour {
	public Transform LookAtTarget;

	/* used to slow the turrets head rotation */
	public float damp = 6.0f;

	/* bullet to instanciate */
	public GameObject bullet;

	/* mouth of the canon, where the bullet has to be shot */
	public GameObject spawnPoint;

	/* true if the player is detected */
	public bool player_detected;

	/* true if the turret can shoot */
	bool shootAllowed = true;

	/* shooting sound */
	public AudioClip audio;

	
	// Update is called once per frame
	void Update () {
		Quaternion rotate;

		/* if the player is detected, the turret looks at him */
		if (player_detected) {
			rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position)*Quaternion.Euler(0,270,330);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotate,(float) Time.deltaTime*damp);

			/* if the turret can shoot, it shoots */
			if(shootAllowed){
				Shoot();
			}
		}
	}

	/* function's name is explicit */
	void Shoot(){
		GameObject oneBullet;
		Vector3 target;
		target = (spawnPoint.transform.position - LookAtTarget.position) ;
		oneBullet = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
		oneBullet.rigidbody.AddForce(target * -80) ;
		AudioSource.PlayClipAtPoint(audio, transform.position);
		shootAllowed = false;
		Invoke("reloadAndAllowShoot",1);
	}

	/* the turret can fire again after reloading */
	void reloadAndAllowShoot(){
		shootAllowed = true;
	}
}