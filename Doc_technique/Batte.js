#pragma strict

function Start () {

}

function Update () {
	if(Input.GetButtonDown("Fire1") && SynchroTir.tirPossible() )
	{
		// Joue l'animation AnimBatte ie un coup de batte
		animation.Play("AnimBatte", PlayMode.StopAll);
	}
}