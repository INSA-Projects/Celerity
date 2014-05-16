using UnityEngine;
using System.Collections;

public class Bonus_Count : MonoBehaviour {
	public static int coincount=0;

	void OnGUI()
	{	string coinText="number"+coincount;
		GUI.Box(new Rect(Screen.width-150,20,130,20),coinText);
	
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
