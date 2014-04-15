#pragma strict

var tagArme = "Arme";

function OnCollisionEnter(other : Collision) {
		if (other.gameObject.tag == tagArme) {
			KillMun();
		/*faire l'affichage score*/
		
		/*augmentation du nombre de munition*/
	}

}

function KillMun(){
	Destroy(transform.gameObject);
}

