#pragma strict

var pathPoint : Transform[];
private var speed = 2;
private var currentPathPoint : int;
var target : Transform;
var yeux : Transform;
var pointDepartTir : String;
var balle : Transform;

var faireFeu;


var detecteJoueur = false;
var shootRange = 15.0;
var dontComeCloserRange = 5.0;
var rotationSpeed = 5.0;
var maxHealth = 5;
var curHealth = 5;
var healthBarLengh;
var adj =-1;
var explosion : Transform;
/*var Hbar = Transform;*/
var fire : Transform;

var tagArme = "Arme";

var prefab: Transform;

var message3 = false;
var message : GUIText;


function Awake() {
	pathPoint[0] = transform;
	healthBarLengh = Screen.width / 2;	
}


function Update() {
	Mouvement();
	
	if (CanSeeTarget()) {
		detecteJoueur = true;
	}
	
}


/*Action quand l'ennemi voit le joueur*/

function Mouvement() {
	if (detecteJoueur) {
		AttackPlayer();
	} else {
		if (currentPathPoint < pathPoint.Length) {
			var zone : Vector3 = pathPoint[currentPathPoint].position;
			var movingTo : Vector3 = zone - transform.position;
			var velocity = rigidbody.velocity;
			
			if (movingTo.magnitude < 1) {
				currentPathPoint++;
			} else {
				velocity = movingTo.normalized * speed;
			}
		} else {
			currentPathPoint = 0;
			// velocity = Vector3.zero 
		}
		
		rigidbody.velocity = velocity; 
		transform.LookAt(zone);
	}

}



function CanSeeTarget() :boolean
{

	if(Vector3.Distance(yeux.position, target.position) > 15)
	{
		return false;
	}
	
	var hit :RaycastHit;
	if(Physics.Linecast(yeux.position, target.position, hit))
	{
		return hit.transform == target;
	}
	else if(!Physics.Linecast(yeux.position, target.position))
	{

		return true;
	}
	
	return false;
}



function AttackPlayer()
{
	var lastVisiblePlayerPosition = target.position;

	if(target == null)
	{
		return;
	}
	
	var distance = Vector3.Distance(transform.position,target.position );
	if(distance > shootRange * 3)
	{
		MoveTowards(target.position);
	}
	
	lastVisiblePlayerPosition = target.position;
	
	if(distance > dontComeCloserRange)
	{
		MoveTowards(lastVisiblePlayerPosition);
	}
	
	if(distance <= dontComeCloserRange)
	{
		RotateTowards(lastVisiblePlayerPosition);
		
		if(CanSeeTarget()) // verif vie
		{
				var temps : int = Time.time;
				var cadence = (temps %4);
	
				if (cadence) {
					InstantiateBullet(temps);
				}
		}
		
		/*
		if(Health.alive == false)
		{
			animation.Play("idle");
		}*/
		
	}
	else
	{
		if(!CanSeeTarget())
		{
			detecteJoueur = false;
		}
	}
}



function MoveTowards(position :Vector3)
{
	var direction = position - transform.position;
	direction.y = 0;
	
	if(direction.magnitude < .5)
	{
		return;
	}
	
	transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
	transform.eulerAngles = Vector3(0, transform.eulerAngles.y, 0);
	
	var movingTo : Vector3 = target.position - transform.position;
	var velocity = rigidbody.velocity;
			
		
	rigidbody.velocity = movingTo.normalized * speed;
	transform.LookAt(target);
}

function RotateTowards(position :Vector3)
{
	var direction = position - transform.position;
	direction.y = 0;
	
	if(direction.magnitude < 0.1)
	{
		return;
	}
	
	transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
	
	transform.eulerAngles = Vector3(0, transform.eulerAngles.y, 0);
	
}	

function InstantiateBullet(temps)
{
	if (temps != faireFeu) {
		var tirer  = Instantiate(balle,transform.Find(pointDepartTir).transform.position, transform.rotation); // Instancie une balle au point de départ dans armeAuto
		Physics.IgnoreCollision( balle.collider, transform.root.collider );
		tirer.rigidbody.AddForce(transform.forward *1500); //  Vitesse de la balle
		faireFeu = temps;
	}
}

function OnCollisionEnter(other :Collision)
{


	if (other.gameObject.tag == tagArme) {
		/*KillPlayer();*/
		curHealth -= 1;
		
		
		if(curHealth < 0) {
			Instantiate(explosion, transform.position, transform.rotation);
			KillPlayer();
			for (var i : int = 0;i < 10; i++) {
				Instantiate (prefab, Vector3(i * 2.0, 0, 0), Quaternion.identity);
			}
		}
		if(curHealth > maxHealth){
			curHealth = maxHealth;
		}
		
		if(maxHealth < 1){
			maxHealth = 1;
		}
		
		healthBarLengh = ((Screen.width / 2) * (curHealth /maxHealth));
	 		 	
	}
	
}

function KillPlayer(){
	if(message3 == true){
		message.text = "Entrez dans la salle d'a cote, Touche e";
	}
	Destroy(transform.gameObject);
	CompteurDeKills.nbKills ++;
}



/*function OnGUI(){
	/*if(!Hbar){
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}else{
	GUI.DrawTexture(Rect(10,10,60,60), Hbar, ScaleMode.ScaleToFit, true, 10.0f);
	}*/
	 /*GUI.Box(new Rect(10, 40, healthBarLengh, 20), curHealth + "/" + maxHealth);*/
	 /*Graphics.DrawTexture(Rect(10, 10, 100, 100), HpBarTexture);*/
