using UnityEngine;
using System.Collections;

public class GestionArmesCSharp : MonoBehaviour
{
	private WiiMote wii = null;
	private int currentArme = 0;
        
void Awake() {
	SelectWeapon(currentArme);
}

void Start () {
	if(wii == null)
		wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
}

void Update()
{
	if(wii == null)
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
		

  if (Input.GetKeyDown("1")||Input.GetKeyDown("c"))
 {
    SelectWeapon(0);
	currentArme=0;
  }       
  else if (Input.GetKeyDown("2")||Input.GetKeyDown("v"))
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


void SelectWeapon(int index) 
{
  for (var i=0;i<transform.childCount;i++)
 {
    // Activate the selected weapon
    if (i == index) {
      transform.GetChild(i).gameObject.SetActive(true);
      }
    // Deactivate all other weapons
    else {
      transform.GetChild(i).gameObject.SetActive(false);
      }
 }
}
}

