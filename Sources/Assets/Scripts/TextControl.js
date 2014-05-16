#pragma strict
var isQuitButton = false;
var isPlayButton = false;
var isInstructionButton = false;

function OnMouseEnter(){
	renderer.material.color = Color.green;
}

function OnMouseExit(){
	renderer.material.color = Color.white;
}

function OnMouseUp(){
	if(isQuitButton){
		Application.Quit();
	}
	if(isPlayButton){
		Application.LoadLevel(0);
	}
	if(isInstructionButton){
		Application.LoadLevel(2);
	}
}

