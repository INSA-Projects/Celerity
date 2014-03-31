var tir : AudioClip;

var projectile : Rigidbody;
var speed = 40;
var dureeDeVie = 5;

function Update(){ 
		if( Input.GetButtonDown( "Fire1" ) && SynchroTir.tirPossible() ){
				audio.PlayOneShot(tir);
				var instantiatedProjectile : Rigidbody = Instantiate(projectile, transform.position, transform.rotation );
				instantiatedProjectile.velocity = transform.TransformDirection( Vector3( 0, 0, speed ) );
				instantiatedProjectile.AddForce (0, 10, 0);
				Physics.IgnoreCollision( instantiatedProjectile.collider, transform.root.collider );
				
		}
		
		
		//Fondu vers transparent à faire
	
		if(instantiatedProjectile){
			//Destruction de l'instance de la balle
			Destroy (instantiatedProjectile.gameObject, dureeDeVie);
		}
	
}