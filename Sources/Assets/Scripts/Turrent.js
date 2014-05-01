#pragma strict
//var LookAtTarget : Transform;
//var damp = 6.0;
var bullitPrefab : Rigidbody;
var savedTime = 0;
var dureeDeVie=5;
var speed = 1;

function Start () {

}

function Update () {
	//if(LookAtTarget){
		//var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
		//transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime*damp);
		
		
		var seconds : int = Time.time;
		var oddeven = (seconds % 2);
		
		if(oddeven){
			Shoot(seconds);
		}
		
		
	//}
}

function Shoot(seconds){
	if(seconds!=savedTime){
	var bullit : Rigidbody = Instantiate(bullitPrefab, transform.position + new Vector3 (0.0f, 1.42f, -2.3f), Quaternion.identity);
	//bullit.velocity = transform.TransformDirection(Vector3( 0, 0, speed ));
	bullit.rigidbody.AddForce(transform.forward*1500);
	
	if (bullit) {
		Destroy (bullit.gameObject, dureeDeVie);
	}
	
	savedTime=seconds;
	}
}