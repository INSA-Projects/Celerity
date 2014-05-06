

using UnityEngine;
using System.Collections;

public class AttraperCSharp : MonoBehaviour {

// Gestion de l'"attrapage" des objets
// Voir ici http://www.unity3d-france.com/unity/creation-dun-gravity-gun-a-la-half-life/

// Variable globale : Savoir si un objet est saisi ou non
	static public bool objetSaisi = false;

// La portée de saisie maximum
	public float portee = (float) 5.0;
// Pour les lancers de rayons
	public RaycastHit hit;
// Le rigidbody attrapé
	private Rigidbody rigidbodyAttrape;

	private float distance = 2;
	
	private WiiMote wii = null;
	

void FixedUpdate() {
		if(wii == null){
			wii = GameObject.Find("First Person Controller").GetComponent<WiiMote>();
		}
		// Si un objet est saisi
		if(objetSaisi){
			// Si on maintient Fire2, l'objet reste saisi
			if(Input.GetButton("Fire2") || (wii != null && wii.b_un)) {
				// Si on appuie sur "Fire1" l'objet est lancé
				if (Input.GetButton("Fire1") || (wii != null && wii.b_B)) {
					lancerObjet();
				}
				// Sinon il suit le joueur
				else {
					asservirObjet();
				}
			}
			// Sinon il est libéré
			else {
				libererObjet();
			}
		}
		// Si un objet n'est pas saisi, on essaie d'en saisir un quand il y a appui sur "Fire2"
		else {
			// Utilisation de tirPossible() pour éviter de pouvoir attraper de nouveau un objet venant d'etre lancé.
			if((Input.GetButton("Fire2") || (wii != null && wii.b_un)) && SynchroTirCSharp.tirPossible()) {
				saisirObjet();
			}
		}
	}

// Recherche un objet à saisir puis le saisit
void saisirObjet() {
	Vector3 direction;
	direction = transform.TransformDirection(Vector3.forward);
	// Lancement d'un rayon devant la caméra
	if(Physics.Raycast(transform.position, direction, out hit, portee)) {
		// Si on rencontre un rigidbody, il devient l'objet attrapé
		if(hit.rigidbody) {
			rigidbodyAttrape = hit.rigidbody;
			rigidbodyAttrape.useGravity = false;
			
			// Calcul de la distance à laquelle doit rester l'objet pour ne pas gener le joueur dans ses deplacements
			// On utilise une approximation de la taille de l'objet
			var vecteurTaille = rigidbodyAttrape.collider.bounds.size;
			// Selectionner le max des composantes de la taille avec un minimum de 2
			distance = System.Math.Max(System.Math.Max(vecteurTaille.x,vecteurTaille.y),System.Math.Max(2,vecteurTaille.z));
			distance *= (float) 0.80;
			objetSaisi = true;
			SynchroTirCSharp.attraper();
		}
	}
}

// Cette fonction oblige l'objet saisi à suivre la caméra
void asservirObjet() {
	Vector3 direction;
	
	// Tourne l'objet vers le joueur
	rigidbodyAttrape.transform.LookAt(transform);
	
	direction = transform.TransformDirection(Vector3.forward);
	
	// Lancement d'un rayon pour obtenir le point où doit se trouver l'objet
	Ray rayonTmp=new Ray(transform.position, direction);
	Vector3 pointCible = rayonTmp.GetPoint(distance);
	
	// Déplacement de l'objet vers ce point
	Vector3 vecteurMvt=(pointCible-rigidbodyAttrape.transform.position);
	rigidbodyAttrape.transform.Translate(vecteurMvt*Time.deltaTime*10,Space.World);
	//rigidbodyAttrape.transform = pointCible;
}

void libererObjet() {
	rigidbodyAttrape.useGravity = true;
	rigidbodyAttrape = null;
	objetSaisi = false;
	SynchroTirCSharp.lacher();
}

void lancerObjet() {
	// Une force est appliquée pour lancer l'objet avant de le libérer
	Vector3 forward = transform.TransformDirection(Vector3.forward);
	rigidbodyAttrape.AddForce(750*forward);
	libererObjet();
}

}