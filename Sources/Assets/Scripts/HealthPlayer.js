#pragma strict

var currentHealth = 5;
var fire : Transform;
var Health : GUIText;

function OnCollisionEnter(other : Collision){
	if(other.gameObject.tag == "Ennemi"){
		if(currentHealth>1){
			currentHealth-=1;
		}else{
			Application.LoadLevel(2);
		}
	}

}

function OnGUI(){
	if (currentHealth>1){
		Health.text = "Nombre de vies restants : "+currentHealth;
	}else{
		if (currentHealth==1){
			Health.text = "Attention, une seule vie restante !";
		}	
	}
	
}