using UnityEngine;
using System.Collections;

/// <summary>
/// Script pour l'affichage des informations pour le joueur
/// </summary>
public class InfoScript : MonoBehaviour {
	public GUIText Ennemi;
	public GUIText Vitesse;

    //Gamestate reference for quick access
    GameState state;
	// Use this for initialization
	void Start () {
	
        state = GetComponent<GameState>();
	}
	
	//just print out a bunch of information onto the screen.
	void OnGUI(){
		//double vitesse = Mathf.Max(Mathf.Abs(state.rigid.vitesse.z),Mathf.Max(Mathf.Abs(state.rigid.vitesse.x),Mathf.Abs(state.rigid.vitesse.y)));
		//double vitesseAffichage = (vitesse * 100.0) / TRR.SPEEDOFLIGHT;
			
		//What's our speed of light?
		int ennemisRestants = GameObject.FindGameObjectsWithTag("Ennemi").Length;
		if ( ennemisRestants == 0) {
			Ennemi.text = "Il n'y a plus d'ennemis";
			Vitesse.text = "Vitesse de la lumiere : "+ TRR.SPEEDOFLIGHT;
			/*GUI.Box (new Rect (0,0,200,50), "Vitesse de la lumiere : " +   TRR.SPEEDOFLIGHT);*/
			/*GUI.Label(new Rect(20,25,200,50), "Augmenter/reduire avec +/-");*/
		} else {
			/*GUI.Box (new Rect (0,0,200,50), "Nombre ennemis restants : "+ ennemisRestants);*/
			Ennemi.text = "Nombre d'ennemis restants : "+ennemisRestants;
			/*GUI.Label(new Rect(20,25,200,50), "Vitesse de la lumiere : " + TRR.SPEEDOFLIGHT);*/
			Vitesse.text = "Vitesse de la lumiere : "+ TRR.SPEEDOFLIGHT;
		}
		//What's our velocity?
		//GUI.Box (new Rect (0,100,200,100), "Current Speed: " + state.rigid.vitesse);
		//GUI.Label(new Rect(20,150,200,50), "Move with with WASD");
		
		
		
	}
	
}
