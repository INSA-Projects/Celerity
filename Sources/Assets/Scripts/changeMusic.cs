using UnityEngine;
using System.Collections;
 
public class changeMusic : MonoBehaviour {
	public AudioManager am;
	public int musicNumber;
	
	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player"){
			am.changeMusic(1);
		}
	}

}

