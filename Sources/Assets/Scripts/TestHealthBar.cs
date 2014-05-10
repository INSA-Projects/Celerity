using UnityEngine;
using System.Collections;
 
public class TestHealthBar : MonoBehaviour {
	public int lg;
	public Texture2D H1;
	public Texture2D H2;
	public Texture2D H3;
	public Texture2D H4;
	public Texture2D H5;
	public Texture2D HpBarTexture;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		if (lg == 100) {
			HpBarTexture = H4;
		}
				
	}

	 void OnGUI(){
		GUI.DrawTexture( new Rect(100, 40, lg, 25), HpBarTexture);
	}
}
