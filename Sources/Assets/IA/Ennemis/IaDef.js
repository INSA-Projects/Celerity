/*private var attack2Length;
var player :Transform;
var hand :Transform;
var speed:int = 3;
var fireBall:GameObject;
var rotationSpeed = 5.0;
var shootRange = 15.0;
var shootAngle = 4.0;
var dontComeCloserRange = 5.0;
var delayShootTime = 0.35;
var pickNextWaypointDistance = 2.0;
var target :Transform;
var attackEvent = new AnimationEvent();
var tempAttackTime;
private var nextFire = 0;

function Awake ()
{
	//animation.AddClip(animation["run"].clip, "run2");
	tempAttackTime = 5;
	
}

function Start()
{
	Patrol();
	/*animation["idle"].layer = 1;
	animation["run"].layer = 2;
	animation["attack"].layer = 1;
	animation["run2"].layer = 2;
	
	attackEvent.functionName = "InstantiateBullet";
}

function Patrol()
{
	var curWayPoint = AutoWayPoint.FindClosest(transform.position);
	while(true)
	{
		var waypointPosition = curWayPoint.transform.position;
		if(Vector3.Distance(waypointPosition, transform.position) < pickNextWaypointDistance)
		{
			curWayPoint = PickNextWayPoint(curWayPoint);
		}
		
		if(CanSeeTarget())
		{
			yield StartCoroutine("AttackPlayer");
		}
		
		MoveTowards(waypointPosition);
		yield;
	}
}

function InstantiateBullet()
{
	if(Time.time > nextFire)
	{
		nextFire = Time.time + 1.4;
	attackEvent.time = tempAttackTime;
	//animation["attack"].weight = .5;
	clone = Instantiate(fireBall, hand.position, hand.rotation);
	Physics.IgnoreCollision(clone.collider, collider);
	clone.rigidbody.velocity = transform.TransformDirection(Vector3.forward * 20);
	var bulletScript = clone.gameObject.AddComponent("BulletScript");
	bulletScript.playerShooting = this.gameObject;
	}
	
}

function CanSeeTarget() :boolean
{
	if(Vector3.Distance(transform.position, target.position) > 15)
	{
		return false;
	}
	
	var hit :RaycastHit;
	if(Physics.Linecast(transform.position, target.position, hit))
	{
		return hit.transform == target;
	}
	
	else if(!Physics.Linecast(transform.position, target.position))
	{
		return true;
	}
	
	return false;
	
}

function AttackPlayer()
{
	var lastVisiblePlayerPosition = target.position;
	while(true)
	{
		if(target == null)
		{
			return;
		}
		
		var distance = Vector3.Distance(transform.position, target.position);
		if(distance > shootRange * 3)
		{
			return;
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
				animation["run"].enabled = false;
				animation.CrossFadeQueued("attack");
				InstantiateBullet();
			}
			
			if(Health.alive == false)
			{
				animation.Play("idle");
			}
			
		}
		
		else
		{
			yield StartCoroutine("SearchPlayer", lastVisiblePlayerPosition);
			if(!CanSeeTarget())
			{
				return;
			}
		}
		
		yield;
		
	}
}

function SearchPlayer(position :Vector3)
{
	var timeOut = 3.0;
	while(timeOut > 0.0)
	{
		MoveTowards(position);
		if(CanSeeTarget())
		{
			return;
		}
		
		timeOut -= Time.deltaTime;
		yield;
	}
	
	
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
	
	var forward = transform.TransformDirection(Vector3.forward);
	var speedModifier = Vector3.Dot(forward, direction.normalized);
	speedModifier = Mathf.Clamp01(speedModifier);
	
	direction = forward * speed * speedModifier;
	
	GetComponent(CharacterController).SimpleMove(direction);
}

function PickNextWayPoint(currentWaypoint :AutoWayPoint)
{
	var forward = transform.TransformDirection(Vector3.forward);
	var best = currentWaypoint;
	var bestDot = -10.0;
	
	for(var cur:AutoWayPoint in currentWaypoint.connected)
	{
		var direction = Vector3.Normalize(cur.transform.position - transform.position);
		var dot = Vector3.Dot(direction, forward);
		if(dot > bestDot && cur != currentWaypoint)
		{
			bestDot = dot;
			best = cur;
		}
	}
	return best;
}*/