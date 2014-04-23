#pragma strict

var currentHealth = 3;
var fire : Transform;

function OnCollisionEnter(other : Collision){
	if(other.gameObject.tag == "Ennemi"){
		if(currentHealth>1){
			currentHealth-=1;
			Instantiate(fire, transform.position, transform.rotation);
		}else{
			Application.LoadLevel(2);
		}
	}

}