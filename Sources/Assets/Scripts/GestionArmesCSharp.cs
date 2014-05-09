using UnityEngine;
using System.Collections;

public class GestionArmesCSharp : MonoBehaviour{
	private WiiMote wii = null;
	private int currentArme = -1; 
        
void Awake(){
	SelectWeapon(currentArme); // desactivate all the weapons
}

void Start () {
	if(wii == null)
		wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
}

// presse 'v' in the game if you need the canon
void Update(){
  if(wii == null)
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
/*
  if (Input.GetKeyDown("1")||Input.GetKeyDown("c")){
    SelectWeapon(0);
	currentArme=0;
  }       
  else */if (Input.GetKeyDown("2")||Input.GetKeyDown("v"))
 {
    SelectWeapon(1);
	currentArme =1;
 } else if (wii != null) {
			
		if (wii.b_A) {
			if (currentArme == 1) {
				currentArme = 0;	
			} else {
				currentArme = 1;
			}
	
		SelectWeapon(currentArme);
	}
 }	
}
	
public void SelectWeapon(int index) {
	for (var i=0;i<transform.childCount;i++) {
    	if (i == index) {
			// Activate the selected weapon
      		transform.GetChild(i).gameObject.SetActive(true);
      	} 
		else {
    		// Deactivate all other weapons
      		transform.GetChild(i).gameObject.SetActive(false);
      	}
 	}
}

}

