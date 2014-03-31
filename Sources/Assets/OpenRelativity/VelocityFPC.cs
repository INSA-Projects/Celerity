using UnityEngine;
using System.Collections;

public class VelocityFPC : MonoBehaviour {
	
	private Vector3 lastPosition;
	
	private float velocitymagn;
	
	public Vector3 vitesse;
	
	//low value increase smoothness while higher will follow the actual velocity
	private float coef = 0.8f;
	
	private float vx;
	private float vy;
	private float vz;
	
	
	// Use this for initialization
	void Start () {
		lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 deplacement = transform.position - lastPosition;
		//Debug.Log (transform.position+" "+deplacement +" "+  Time.deltaTime);
		lastPosition = transform.position;
		//velocitymagn = deplacement.magnitude/ Time.deltaTime;
		//smooth des valeurs de la vélocité;
		velocitymagn = Mathf.Lerp(velocitymagn,deplacement.magnitude,10f*Time.deltaTime);
		velocity = new Vector3(velocitymagn,0,0);
		
		*/
		
		Vector3 displacement = transform.position - lastPosition;
		vx = displacement.x;
		vy = displacement.y;
		vz = displacement.z;
		lastPosition = transform.position;
		//velocity = displacement / Time.deltaTime;
		
		vitesse.x = Mathf.Lerp(vitesse.x, vx/Time.deltaTime, coef*Time.deltaTime);
		vitesse.y = Mathf.Lerp(vitesse.y, vy/Time.deltaTime, coef*Time.deltaTime);
		vitesse.z = Mathf.Lerp(vitesse.z, vz/Time.deltaTime, coef*Time.deltaTime);
		
		if(vitesse.magnitude > TRR.SPEEDOFLIGHT) {
			float norme = vitesse.magnitude;
			float maxs = TRR.SPEEDOFLIGHT - TRR.MAX_SPEED_UNDER_SOL;
			float vxx = (vitesse.x / norme) * maxs;
			float vyy = (vitesse.y / norme) * maxs;
			float vzz = (vitesse.z / norme) * maxs;
			
			vitesse = new Vector3(vxx,vyy,vzz);	

		}
		
	}
}
