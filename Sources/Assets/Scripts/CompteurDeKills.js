#pragma strict
 var stringToEdit : String = "PC atteints : 0";
 public static var nbKills : int;
 

function OnGUI () {
    // Make a text field that modifies stringToEdit.
   // stringToEdit = GUI.TextField (Rect (10, 10, 200, 20), stringToEdit, 25);
}

function Start () {
	
}

function Update () {

	stringToEdit = "PC atteints : " + nbKills;
	OnGUI();
}