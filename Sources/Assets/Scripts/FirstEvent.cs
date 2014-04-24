using UnityEngine;
using System.Collections;

public class FirstEvent : MonoBehaviour {
	public GUIText message;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("p")){
			EventOne();
		}
	
	}

	void EventOne(){
			TRR.SPEEDOFLIGHT = 30f;
			message.text = " Doppler effect ! Avancez tout droit \n Ouvrez la porte à gauche, touche E";
	}
}
