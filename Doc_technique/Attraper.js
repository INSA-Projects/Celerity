#pragma strict
/*Auteurs: groupe 3info (2013-2014)
Script pour attraper les objets
Voir ici http://www.unity3d-france.com/unity/creation-dun-gravity-gun-a-la-half-life/
*/

// Variable globale : Savoir si un objet est saisi ou non
static var objetSaisi:boolean = false;

// La portée de saisie maximum
var portee:float=3;
// Pour les lancers de rayons
private var hit:RaycastHit;
// Le rigidbody attrapé
private var rigidbodyAttrape:Rigidbody;

private var distance:float = 2;

function FixedUpdate() {
	// Si un objet est saisi
	if(objetSaisi)
	{
		// Si on maintient Fire2, l'objet reste saisi
		if(Input.GetButton("Fire2")) {
			// Si on appuie sur "Fire1" l'objet est lancé
			if (Input.GetButton("Fire1")) {
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
	else
	{
		// Utilisation de tirPossible() pour éviter de pouvoir attraper de nouveau un objet venant d'etre lancé.
		if(Input.GetButton("Fire2") && SynchroTir.tirPossible()) {
			saisirObjet();
		}
	}
}

// Recherche un objet à saisir puis le saisit
function saisirObjet() {
	var direction:Vector3;
	direction = transform.TransformDirection(Vector3.forward);
	// Lancement d'un rayon devant la caméra
	if(Physics.Raycast(transform.position, direction, hit, portee)) {
		// Si on rencontre un rigidbody, il devient l'objet attrapé
		if(hit.rigidbody) {
			rigidbodyAttrape = hit.rigidbody;
			rigidbodyAttrape.useGravity = false;
			
			// Calcul de la distance à laquelle doit rester l'objet pour ne pas gener le joueur dans ses deplacements
			// On utilise une approximation de la taille de l'objet
			var vecteurTaille = rigidbodyAttrape.collider.bounds.size;
			// Selectionner le max des composantes de la taille avec un minimum de 2
			distance = System.Math.Max(System.Math.Max(vecteurTaille.x,vecteurTaille.y),System.Math.Max(2,vecteurTaille.z));
			distance *= 0.80;
			objetSaisi = true;
			SynchroTir.attraper();
		}
	}
}

// Cette fonction oblige l'objet saisi à suivre la caméra
function asservirObjet() {
	var direction:Vector3;
	
	// Tourne l'objet vers le joueur
	rigidbodyAttrape.transform.LookAt(transform);
	
	direction = transform.TransformDirection(Vector3.forward);
	
	// Lancement d'un rayon pour obtenir le point où doit se trouver l'objet
	var rayonTmp:Ray=new Ray(transform.position, direction);
	var pointCible:Vector3 = rayonTmp.GetPoint(distance);
	
	// Déplacement de l'objet vers ce point
	var vecteurMvt:Vector3=(pointCible-rigidbodyAttrape.transform.position);
	rigidbodyAttrape.transform.Translate(vecteurMvt*Time.deltaTime*10,Space.World);
	//rigidbodyAttrape.transform = pointCible;
}

function libererObjet() {
	rigidbodyAttrape.useGravity = true;
	rigidbodyAttrape = null;
	objetSaisi = false;
	SynchroTir.lacher();
}

function lancerObjet() {
	// Une force est appliquée pour lancer l'objet avant de le libérer
	var forward:Vector3 = transform.TransformDirection(Vector3.forward);
	rigidbodyAttrape.AddForce(750*forward);
	libererObjet();
}
