using UnityEngine;
using System.Collections;

public class SpeedSynchro : MonoBehaviour {
	
	private VelocityFPC vfpc;
	private RelativisticObject obj;
	
	// Use this for initialization
	void Start () {
		vfpc = this.GetComponent<VelocityFPC>();
		obj = this.GetComponent<RelativisticObject>();
	}
	
	// Update is called once per frame
	void Update () {
		obj.viw = vfpc.vitesse;
	}
}
