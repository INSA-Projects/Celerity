using UnityEngine;
using System.Collections;

/// <summary>
/// Script pour la teleportation
/// </summary>
public class erraticTeleportation : MonoBehaviour {
	public GameObject mediumTank; 		// tank that will appear
	public GameObject flashLight;		// light effects of the apparition
	public GameObject flareLight;
	
	// Use this for initialization
	void Start () {
		mediumTank.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	/**
	 * launch the apparition
	 * */
	void OnTriggerEnter () {
		gameObject.SetActive(false);
		Invoke("erraticApparition1",4);
	}

	/// <summary>
	/// A préciser
	/// </summary>
	void erraticApparition1(){
		flareLight.audio.Play();
		flareLight.particleSystem.Play();
		Invoke("erraticApparition2",2);
	}

	/// <summary>
	/// A preciser
	/// </summary>
	void erraticApparition2(){
		flareLight.particleSystem.Stop();
		flashLight.particleSystem.Play();
		flashLight.audio.Play();
		mediumTank.gameObject.SetActive(true);
		mediumTank.rigidbody.AddForce(10,10,10);
		Invoke("erraticApparition3",1);
	}

	/// <summary>
	/// a preciser
	/// </summary>
	void erraticApparition3(){
		flashLight.particleSystem.Stop();
	}
}
