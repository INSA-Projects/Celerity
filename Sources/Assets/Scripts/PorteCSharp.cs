using UnityEngine;
using System.Collections;

public class PorteCSharp : MonoBehaviour
{

	public float amplitude = 90;
	private float openAngle;
	private float closedAngle;
	private bool open = false;
	private bool trigger = false;
	private float targetValue = 0;
	private float currentValue = 0;
	private float easing = (float)0.15;
	public GameObject porte ;
	public AudioClip sonOuverture ;
	public AudioClip sonFermeture;
	private Vector3 defaultRot;
	private Vector3 openRot;
	private WiiMote wii = null;

	void Start ()
	{
		/* Initialisation des valeurs pour que la porte conserve sa position initiale au lancement */
		
		currentValue = porte.transform.eulerAngles.y;
		targetValue = currentValue;
	
		/* Calcul des valeurs de l'angle pour une porte ouverte et fermé */
		closedAngle = porte.transform.eulerAngles.y;
		openAngle = closedAngle + amplitude;
		
		if (wii == null)
			wii = GameObject.Find ("First Person Controller").GetComponent<WiiMote> ();
			
	}
	
	void FixedUpdate ()
	{
		/* Mise à jour de la rotation de la porte */
		currentValue = currentValue + (targetValue - currentValue) * easing;
		porte.transform.eulerAngles = new Vector3 (porte.transform.eulerAngles.x, currentValue, porte.transform.eulerAngles.z);
	}

	void Update ()
	{	
		if (wii == null)
			wii = GameObject.Find ("First Person Controller").GetComponent<WiiMote> ();
		
		if ((trigger && Input.GetKeyDown ("f")) || (trigger && (wii != null && wii.b_C))) {
			if (open) {
				fermerPorte ();
			} else {
				ouvrirPorte ();
			}
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
			
		if (other.tag == "Player") {
			trigger = true;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		trigger = false;
	}
	
	void fermerPorte ()
	{
		currentValue = openAngle;
		targetValue = closedAngle;
		audio.PlayOneShot (sonFermeture);
		open = false;
	}
	
	void ouvrirPorte ()
	{
		currentValue = closedAngle;
		targetValue = openAngle;
		audio.PlayOneShot (sonOuverture);
		open = true;
	}
}
