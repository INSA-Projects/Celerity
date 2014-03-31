using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {
	private WiiMote wii = null;
	public bool plusTRR = false;
	public bool moinsTRR = false;
	public bool effetDoopler = false;
	
	public Texture icone_pause;
	// Use this for initialization
	void Start () {
		if(wii == null)
			wii = gameObject.GetComponent<WiiMote>();
	}
	
	// Update is called once per frame
	void Update () {
		if(wii == null)
			wii = gameObject.GetComponent<WiiMote>();
		moinsTRR = wii.b_moins;
		plusTRR = wii.b_plus;
		effetDoopler = wii.b_Z;

		
		
		if(moinsTRR)
			diminueTRR();
		if(plusTRR)
			augmenteTRR();

	}
	
	void diminueTRR ()
	{
		if (TRR.SPEEDOFLIGHT - 1 > 10) { 
			TRR.SPEEDOFLIGHT = TRR.SPEEDOFLIGHT-1;
		}
	}
	
	void augmenteTRR ()
	{
		TRR.SPEEDOFLIGHT = TRR.SPEEDOFLIGHT+1;
	}

}
