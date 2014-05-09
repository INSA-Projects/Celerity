using UnityEngine;

using System.Collections;



public class EnemyHealth : MonoBehaviour {
	
	public int maxHealth = 5;
	public int curHealth = 5;

	public float healthBarLength;
	public Texture2D HpTextureBar;

	public string tagArme = "Arme";
	
	
	
	// Use this for initialization
	
	void Start () {
		healthBarLength = Screen.width / 6;
	}
	
	
	
	// Update is called once per frame
	
	void Update () {
		AddjustCurrentHealth(0);    
	}
	
	
	
	/*void OnGUI() {
		
		GUI.DrawTexture(new Rect((Screen.width/2) - 100, 10, healthBarLength, 10), HpBarTexture);
	}*/
	
	
	
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;
		
		if (curHealth < 0)
			curHealth = 0;
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;

		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 6) * (curHealth /(float)maxHealth);
		
	}

	void OnCollisionEnter(Collision collision)
	{

		foreach (ContactPoint contact in collision.contacts) {
			KillPlayer ();
			/*Debug.DrawRay(contact.point, contact.normal, Color.white);*/
	
		}
		/*if (other.gameObject.tag == tagArme) {
			/*KillPlayer();*/
			/*curHealth -= 1;
			
			if(curHealth < 0) {
				Destroy(transform.gameObject);
			}
			if(curHealth > maxHealth){
				curHealth = maxHealth;
			}
			
			if(maxHealth < 1){
				maxHealth = 1;
			}
			
			healthBarLength = ((Screen.width / 2) * (curHealth /maxHealth));
			
		}*/
		
	}
	
	public void KillPlayer(){
		Destroy(gameObject);
		CompteurDeKills.nbKills ++;
	}
	
	public void OnGUI(){
		/*GUI.DrawTexture(Rect(10,10,60,60), HpBarTexture, ScaleMode.ScaleToFit, true, 10.0f);*/
		/*GUI.Box(new Rect(10, 40, healthBarLengh, 20), curHealth + "/" + maxHealth);*/
		/*Graphics.DrawTexture(Rect(10, 10, 100, 100), HpBarTexture);*/
		GUI.DrawTexture( new Rect(100, 40, 100 /*lg*/, 25), HpTextureBar);
	}
	
}
