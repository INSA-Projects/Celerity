private var xDeg = 0.0; 
var target:Transform; 
private var targetHeight = 1;
private var desiredDistance; 
var distance = 3;

private var maxDistance = 12; 						// Maximum zoom Distance
private var minDistance = 2;
private var zoomRate = 40; 


function Start () {


var angles:Vector3 = transform.eulerAngles; 
xDeg = angles.x; 
currentDistance = distance; 
	desiredDistance = distance; 
	correctedDistance = distance; 

}

function Update () {


 xDeg += 0.2;  
 
 
 var rotation:Quaternion = Quaternion.Euler (0, xDeg, 0); 
 
 vTargetOffset = Vector3 (0, -targetHeight, 0);

 
 desiredDistance -= Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs (desiredDistance); 
	desiredDistance = Mathf.Clamp (desiredDistance, minDistance, maxDistance); 
	correctedDistance = desiredDistance; 
	
	var position:Vector3 = target.position - (rotation * Vector3.forward * desiredDistance + vTargetOffset); 
 
 transform.rotation = rotation; 
 transform.position = position; 

}