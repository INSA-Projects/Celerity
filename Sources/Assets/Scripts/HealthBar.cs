/*using UnityEngine;
using System.Collections;
/*
public class HealthBar : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	
	
	public float healthBarLengh;
	
	// Use this for initialization
	void Start () {
		healthBarLengh = Screen.width / 2;
		
	}
	
	// update is called once per frame
	private void update () {
		AddjustCurrentHealth(0);
		
	}
	
	private void OnGUI() {
		Vector2 targetPos;
		
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		GUI.Box(new Rect(targetPos.x, Screen.height, 60, 20), healthBarLengh + "/" + maxHealth);
		/*GUI.Box(new Rect(10, 40, healthBarLengh, 20), curHealth + "/" + maxHealth);*/
		
	/*}
	/*
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;
		
		if(curHealth < 0) {
			KillPlayer();
		}
		if (curHealth > maxHealth) {
						curHealth = maxHealth;
				}
		
		if (maxHealth < 1) {
						maxHealth = 1;
				}
		
		healthBarLengh = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
	
	public void KillPlayer() {
		/*Instantiate(PlayerPrefab, transform, rotation);*/
		/*Destroy(gameObject);
	} 
}
*/
/*
public class HealthBar : MonoBehaviour{
	/* this boolean value tells us if this is the ennemi1healthBar or the ennemi2healthBar*/
	/*private bool _isEnnemi1HealthBar;

	void Strat(){
		_isEnnemi1HealthBar = true;

		OnEnable ();
	}
	void Update(){
		}
	public void OnEnable(){
		if (_isEnnemi1HealthBar)
			BroadcastMessage("ennemi1 health update", OnChangeHealthBarSize);
		else
			BroadcastMessage("ennemi2 health update", OnChangeHealthBarSize);
	}

	public void OnDisable(){
		/*if (_isEnnemi1HealthBar)
			Messenger<int, int>.RemoveListener ("ennemi1 health update", OnChangeHealthBarSize);
		else
			Messenger<int, int>.RemoveListener ("ennemi2 health update", OnChangeHealthBarSize);*/

	/*}
	public void SetEnnemi1HealthBar(bool b){
		_isEnnemi1HealthBar = true;
	}

	public void OnChangeHealthBarSize(int curHealth, int maxHealth){
		Debug.Log ("We heard an event");

	}





}*/