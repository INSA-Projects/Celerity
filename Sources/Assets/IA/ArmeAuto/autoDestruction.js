#pragma strict

var dureeDeVie : float = 5;

function Awake () {
	Destroy(gameObject,dureeDeVie);
}