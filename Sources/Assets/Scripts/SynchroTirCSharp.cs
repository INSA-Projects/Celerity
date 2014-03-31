using UnityEngine;
using System.Collections;

public class SynchroTirCSharp : MonoBehaviour {


static float tempsLache;
static float delai = (float) 0.5;
static bool objetEnMain = false;

static public void attraper() {
	objetEnMain = true;
}

static public void lacher() {
	tempsLache = Time.time;
	objetEnMain = false;
}

static public bool tirPossible()  {
	float tempsCourant = Time.time;
	bool possible = !objetEnMain && (tempsCourant > (tempsLache + delai));
		
	return possible;
}
}
