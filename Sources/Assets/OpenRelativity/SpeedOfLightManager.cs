using UnityEngine;
using System.Collections;

public class SpeedOfLightManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*au depart les effets ne seront pas très visibles --> vitesse de la lumiere 800 par exemple*/
		TRR.SPEEDOFLIGHT = 800f;
	}
	
	// Update is called once per frame
	void Update () {
		// Allow changing the speed of light
		/*if(Input.GetKeyDown("m"))
		{
			TRR.SPEEDOFLIGHT -= 2f;
		}
		else if(Input.GetKeyDown("n"))
		{
			TRR.SPEEDOFLIGHT += 2f;
		}*/

		//Si le joueur a recuperé l'arme le speedoflight descend brusquement + explosion
		//TRR.SPEEDOFLIGHT = 20f;

		//Le joueur doit avancé jusqu'a la boule de sphere --> collision -->
		//TRR.SPEEDOFLIGHT = 200f;


	}
}
