#pragma strict

var sound : AudioClip; //canon fire soundClip
 
var reloadSound: AudioClip; //reload soundClip
 
var coconutSpeed = 100; //force of coconuts being shot
 
var projectile : Rigidbody; //coconut prefab goes here
 
var coconuts = 30; //amount of coconuts per "clip"
 
var totalCoconuts = 60; //total amount of coconuts we have available
 
var reloadTime = 3; //time to reload
 
var reloadAmount = 10;
 
var ammo : GUIText; //GUI text for our coconut/ammo count
 
function Update () {
 
Fire ();
 
Reload ();
 
}
 
function Fire () {
 
if(coconuts > 0) { //if we have at least 1 coconut then we can fire
 
if (Input.GetButtonDown("Fire1")) {
 
var clone : Rigidbody;// Instantiate the projectile at the position and rotation of this transform
 
clone = Instantiate(projectile, transform.position, transform.rotation);
 
clone.velocity = transform.TransformDirection (Vector3.forward * coconutSpeed);// Give the cloned object an initial velocity along the current
 
AudioSource.PlayClipAtPoint(sound, transform.position, 1);                     // object's Z axis
 
coconuts -=1; //subtracts one coconut per fire sequence
 
}
 
}
 
}
 
function Reload () {
 
if(coconuts < 1) {    //if we have less than 1 coconut then we can reload
 
if(Input.GetKeyDown("r")) {
 
AudioSource.PlayClipAtPoint(reloadSound, transform.position, 1); //plays reload soundclip
 
yield WaitForSeconds(reloadTime); //waits for "reloadTime" before adding coconuts
 
coconuts += reloadAmount; //adds 3 coconuts to our "clip"
 
totalCoconuts -= reloadAmount; //subtracts 3 coconuts from our totalCoconuts amount
 
}
 
}
 
}
 
function OnGUI () {
 
ammo.text = "Coconuts: " + coconuts + "/" +  totalCoconuts.ToString();
 
}