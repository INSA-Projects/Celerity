#pragma strict
var LookAtTarget : Transform;
var damp = 6.0;
var bullitPrefab : Transform;
var savedTime = 0;


function Update () {

		if (LookAtTarget) {
			var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position)*Quaternion.Euler(0,180,0);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotate,Time.deltaTime*damp);
			var seconds : int = Time.time;
			var oddeven = (seconds%2);

			if(oddeven){
				Shoot(seconds);
			}
		}
}

function Shoot(seconds){
	if(seconds != savedTime){
		var bullit = Instantiate (bullitPrefab, transform.Find ("spawnPoint").transform.position, Quaternion.identity);
		bullit.rigidbody.AddForce (transform.forward * 1000);
		
		savedTime = seconds;
	}
}