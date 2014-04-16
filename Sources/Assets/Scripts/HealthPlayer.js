#pragma strict
var compteur = 1;;
var currentHealth = 3;
var tagEnnemi = "Ennemi";
var coeur1 : Texture;
var coeur2 : Texture;
var coeur3 : Texture;
var fire : Transform;

function OnCollisionEnter(other : Collision){
	if((other.gameObject.tag == "Ennemi") && (compteur == 1)){
		currentHealth-=1;
		Instantiate(fire, transform.position, transform.rotation);
	}

}