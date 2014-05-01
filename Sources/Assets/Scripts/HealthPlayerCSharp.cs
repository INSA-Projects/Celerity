using UnityEngine;
using System.Collections;

public class HealthPlayerCSharp : MonoBehaviour {
	public static int currentHealth = 3;
	public GameObject other;

	void OnCollisionEnter(){
		if((other.gameObject.tag == "Ennemi") || (other.gameObject.tag == "projectile")) {
			if(currentHealth>=1){
				currentHealth-=1;
			}else{
				Application.LoadLevel(2);
			}
		}
	}
}
