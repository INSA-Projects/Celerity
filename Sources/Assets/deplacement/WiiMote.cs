using UnityEngine;
using System.Collections;
using MiddleVR_Unity3D;
using System;

using System.Collections.Generic;

public class WiiMote : MonoBehaviour {
	public string NodeToMove = "CenterNode";
    public string DirectionReferenceNode = "HandNode";
    public string TurnAroundNode = "HeadNode";
	public float factor = 235.5f;
	
	private vrButtons boutons = null;
	private vrAxis axis = null;

	private vrAxis wiiMoteAxis;
	private vrButtons wiiMoteButtons;
	
	//index axis nunchunk
	private uint a_angle = 19; //angle de deplacement du joystick
	private uint a_ampl = 20; //amplitude du deplacement du joystick
	private uint a_vert_nunch = 18;//Axe vertical nunckuck
	private uint a_hori_nunch = 17;//Axe vertical nunckuck
	
	//index axis wiimote
	private uint a_hori = 1; //axe horizontal
	private uint a_vert = 2; //axe vertical
	
	//index boutons wiimote
	private uint b_a = 3; // bouton A
	private uint b_1 = 1; // bouton 1
	private uint b_2 = 2; // bouton 2
	private uint b_b = 4; // bouton B
	
	private uint b_left = 7; //bouton fleche gauche
	private uint b_right = 8; //bouton fleche droit
	private uint b_down = 9; //bouton fleche bas
	private uint b_up = 10; //bouton fleche haut
	
	private uint b_m = 5; // bouton moins
	private uint b_p = 6; // bouton plus
	private uint b_h = 0; // bouton home
	
	//index boutons nunchunk
	private uint b_c = 17; // bouton C
	private uint b_z = 16; // bouton Z
	
	GameObject directionRefNode = null;
    GameObject nodeToMove       = null;
    GameObject turnNode         = null;
	CharacterMotor motor;
    
	public bool b_moins = false;
	public bool b_plus = false;
	public bool b_B = false;
	public bool b_Z = false;
	public bool b_un = false;
	public bool b_C = false;
	public bool b_deux = false;
	public bool b_A = false;
	public float acc_nunchuck = 0.0f;
	private GameObject camera = null;
	private bool b_BRealease;
	private bool b_ZRealease;
	
	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor>();
		directionRefNode = GameObject.Find(DirectionReferenceNode);
        nodeToMove       = GameObject.Find(NodeToMove);
        turnNode         = GameObject.Find(TurnAroundNode);
		if(MiddleVR.VRDeviceMgr != null){
			boutons = MiddleVR.VRDeviceMgr.GetButtons("WiiMote0Button.Buttons");
			axis = MiddleVR.VRDeviceMgr.GetAxis("WiiMote0Axis.Axis");
		
		}
		camera = GameObject.Find("Camera1");
	
	} //fin start()
	
	// Update is called once per frame
	void Update () {
			
		if(boutons == null)
			Debug.Log("pas d'acces au bouton de la wiimote 1, avez-vous branché la wiimote?");
		
		if(boutons != null){
			
			bool bba = boutons.IsToggled(b_a);
			bool bb1 = boutons.IsToggled(b_1);
			bool bb2 = boutons.IsToggled(b_2);
			bool bbb = boutons.IsToggled(b_b);
			
			bool bbl = boutons.IsPressed(b_left);
			bool bbr = boutons.IsPressed(b_right);
			bool bbu = boutons.IsPressed(b_up);
			bool bbd = boutons.IsPressed(b_down);
			
			bool bbm = boutons.IsToggled(b_m);
			bool bbp = boutons.IsToggled(b_p);
			bool bbh = boutons.IsToggled(b_h);
			
			bool bbc = boutons.IsToggled(b_c);
			bool bbz = boutons.IsToggled(b_z);
			
			//Debug.Log("Bouton OK !");
			
			b_moins = bbm;
			b_plus = bbp;
			b_B = bbb;
			b_Z = bbz;
			b_un = bb1;
			b_deux = bb2;
			b_A = bba;
			b_C = bbc;
			
			float speed = factor * Time.deltaTime;
			
			Vector3 tVec = new Vector3(0, 0, 0);
			
			if(b_B && !bbb)
				b_BRealease = true;
			else
				b_BRealease = false;
			
			if(b_Z && !bbz)
				b_ZRealease = true;
			else
				b_ZRealease = false;
			
			if(bbl){
				//tVec += new Vector3(1, 0, 0);
				tVec += new Vector3(-1, 0, 0);
			}
			if(bbr){
				//tVec += new Vector3(-1, 0, 0);
				tVec += new Vector3(1, 0, 0);
			}
			if(bbd){
				//tVec += new Vector3(0, 0, 1);
				tVec += new Vector3(0, 0, -1);
			}
			if(bbu){
				//tVec += new Vector3(0, 0, -1);
				tVec += new Vector3(0, 0, 1);
			}
			Vector3 nVec = new Vector3(tVec.x * speed, tVec.y * speed, tVec.z * speed );
			//nVec = handleToFast(nVec);
			Vector3 mVec = directionRefNode.transform.TransformDirection(nVec);
						
			//nodeToMove.transform.Translate(mVec,Space.World);
           	//motor.inputMoveDirection = nVec;
			//motor.inputMoveDirection = Camera.main.transform.rotation * nVec;
			//Debug.Log(nVec);
			motor.inputMoveDirection = camera.transform.rotation * nVec;
			//Vector3 mVec = directionRefNode.transform.TransformDirection(nVec);
		//	print(nVec);
			/*
			////// deplacement personnage
			float factor = 2.5f;
			float speed = factor * Time.deltaTime;
			
			Vector3 tVec = new Vector3(0, 0, 0);
	        
			if(wiiMoteButtons.IsPressed(b_left)){
	            tVec += new Vector3(-1, 0, 0);
	
			}
			if(wiiMoteButtons.IsPressed(b_right)){
				tVec += new Vector3(1, 0, 0);
	
			}
			if(wiiMoteButtons.IsPressed(b_down)){
				tVec += new Vector3(0, 0, -1);
	
			}
			if(wiiMoteButtons.IsPressed(b_up)){
				tVec += new Vector3(0, 0, 1);
			}
			Vector3 nVec = new Vector3(tVec.x * speed, tVec.y * speed, tVec.z * speed );
			Vector3 mVec = refNode.transform.TransformDirection(nVec);
			node.transform.Translate(mVec,Space.World);
			
			////// fin deplacement personnage
			
			*/
			if(axis != null){
			////// deplacement camera
				float ampl = axis.GetValue(a_ampl);
				acc_nunchuck = axis.GetValue(a_hori_nunch);//print(acc_nunchuck);
/*				ampl = axis.GetValue(17);
				Debug.Log("ampl 3: " +ampl);
				ampl = axis.GetValue(18);
				Debug.Log("ampl 4: " +ampl);
				ampl = axis.GetValue(19);
				Debug.Log("ampl 5: " +ampl);
				*/
				//on ne deplace la camera que si l'amplitude du joystick est assez grande
				if(ampl > 0.3){
					float angle = axis.GetValue(a_angle);
		//			double angle_r = angle*Math.PI/180;
		//			float rotationX = (float)-Math.Cos(angle_r);
		//			float rotationY = (float)Math.Sin(angle_r);
					float rotationY = 0;
					float speedR = (40*ampl) * Time.deltaTime;
					float speedR1 = ampl * Time.deltaTime;
					Vector3 rVec = new Vector3(0, 0, 0);
					Vector3 r1Vec = new Vector3(0, 0, 0);
					
					if(angle < 45 || angle > 315){
						//rVec += new Vector3(1, 0, 0);
						rVec += new Vector3(-1, 0, 0);
					}
					else if(135 < angle && angle < 225){
						//rVec += new Vector3(-1, 0, 0);
						rVec += new Vector3(1, 0, 0);
					}
					
					if(45 < angle && angle < 135 ){
						r1Vec += new Vector3(0, 1, 0);
						//r1Vec += new Vector3(0, -1, 0);
					}
					else if(225 < angle && angle < 315){
						r1Vec += new Vector3(0, -1, 0);
						//r1Vec += new Vector3(0, 1, 0);
					}
					nodeToMove.transform.Rotate(rVec, speedR);
					nodeToMove.transform.RotateAround(r1Vec, speedR1);
					//node.transform.RotateAroundLocal(rVec, speedR);
							
				//node.transform.Rotate(new Vector3(-(float)Math.Cos(angle_r), (float)Math.Sin(angle_r), 0), speedR);
				}
				
			}
		////// fin deplacement camera
			
	/*
	 * Home ---------------------------------
	 * */
			
			if(bbh){	
				Debug.Log("Bouton Home");
				nodeToMove.transform.position = new Vector3(0,0,0);
				nodeToMove.transform.rotation = Quaternion.identity;
			}
			
	
		}
	}//fin update
		
	
	private float floatInFrontOfWall = 0.75f;	
	
	public bool boutonBRealease()
	{
		return b_BRealease;
	}
	
	public bool boutonZRealease()
	{
		return b_ZRealease;
	}
	
	/**
	 * \fn handleToFast
	 * \brief handle the operation to do if the object is faster than light!
	 * ex: slow the object and raise a warning
	 */ 
	private Vector3 handleToFast(Vector3 v)
	{
		float norme = v.magnitude;
		float maxs = TRR.SPEEDOFLIGHT - TRR.MAX_SPEED_UNDER_SOL;
		float vx = (v.x / norme) * maxs;
		float vy = (v.y / norme) * maxs;
		float vz = (v.z / norme) * maxs;
		
		return new Vector3(vx,vy,vz);
		Debug.LogError("Depassement de la vitesse de la lumiére, pour  creation d'un trou noir...");
	}
}