#pragma strict

var forceAppliquee = 2.0;

// Cette fonction est appelee lorsque le joueur entre en collision avec un objet
// On déplace alors l'objet
// http://docs.unity3d.com/Documentation/ScriptReference/CharacterController.OnControllerColliderHit.html?from=ControllerColliderHit
function OnControllerColliderHit (hit : ControllerColliderHit) {
	var body : Rigidbody = hit.collider.attachedRigidbody;

	
	// Pas de rigidbody
	if (body == null || body.isKinematic)
		return;
            
	// Il ne faut pas pousser les objets en dessous du joueur
	if (hit.moveDirection.y < -0.3)
		return;
		
	// Calcul de la direction vers laquelle déplacer l'objet, 
	// On ne pousse que sur les cotés, pas vers le haut / bas
	var pushDir : Vector3 = Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
    
	// Application du déplacement
	body.velocity = pushDir * forceAppliquee;
	
	
}