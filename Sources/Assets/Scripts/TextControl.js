#pragma strict
var isQuitButton=false;
var isStartButton=false;
var isStoryButton=false;
var isSTRbutton=false;
var isPlayButton=false;

function OnMouseEnter(){
	renderer.material.color = Color.red;
}

function OnMouseExit(){
	renderer.material.color = Color.white;
}

function OnMouseUp(){
	if(isQuitButton){
		Application.Quit();
	}
	if(isStartButton){
		Application.LoadLevel(0);
	}
	if(isPlayButton){
		Application.LoadLevel(2);
	}
}
