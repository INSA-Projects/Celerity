#pragma strict

var cible : Transform;
var balle : Transform;
var faireFeu;


function Update () {
	var rotate = Quaternion.LookRotation(cible.position - transform.position);
	transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime *1); // *1 => Temporation avant que l'arme ne nous detecte
	
	var temps : int = Time.time;
	var cadence = (temps %4);
	
	if (cadence) {
		tir(temps);
	}
	
}

function tir(temps) {
	if (temps != faireFeu) {
		var tirer = Instantiate(balle,transform.Find("depart").transform.position, Quaternion.identity); // Instancie une balle au point de départ dans armeAuto
		tirer.rigidbody.AddForce(transform.forward *3000); //  Vitesse de la balle
		faireFeu = temps;
	}
}