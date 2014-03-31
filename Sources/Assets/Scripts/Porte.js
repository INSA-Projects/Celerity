#pragma strict
var amplitude : float = 90;
private var openAngle: float;
private var closedAngle : float;

private var open : boolean = false;
private var trigger : boolean = false;

private var targetValue : float = 0;
private var currentValue : float = 0;
private var easing : float = 0.038;

var porte : GameObject;
var sonOuverture : AudioClip;
var sonFermeture : AudioClip;

private var defaultRot : Vector3;
private var openRot : Vector3;

function Start(){
	/* Initialisation des valeurs pour que la porte conserve sa position initiale au lancement */
	currentValue = porte.transform.eulerAngles.y;
	targetValue = currentValue;
	
	/* Calcul des valeurs de l'angle pour une porte ouverte et fermé */
	closedAngle = porte.transform.eulerAngles.y;
	openAngle = closedAngle + amplitude;
}

function Update () {
	currentValue = currentValue + (targetValue - currentValue) * easing;
	
	porte.transform.eulerAngles.y = currentValue;
	
	if(trigger && Input.GetKeyDown("f"))
	{
		if(open)
		{
			fermerPorte();
		}
		else
		{
			ouvrirPorte();
		}
	}
}

function OnTriggerEnter(other : Collider) {
	if(other.tag == "Player")
	{
		trigger = true;
	}
}

function OnTriggerExit(other : Collider) {
	trigger = false;
}

function fermerPorte() {
	currentValue = openAngle;
	targetValue = closedAngle;
	audio.PlayOneShot(sonFermeture);
	open = false;
}

function ouvrirPorte() {
	currentValue = closedAngle;
	targetValue = openAngle;
	audio.PlayOneShot(sonOuverture);
	open = true;
}