/**
 * \file TRR.cs
 * \brief The main TRR file with constente and the main function
 */ 
using UnityEngine;
using System.Collections;
using System;

public class TRR 
{
	public static float SPEEDOFLIGHT = 6;
	public static float MAX_SPEED_UNDER_SOL = 0.001f;
	
	/**
	 * \fn lorentzTransform
	 * \brief transform mesh thanks to the lorentz transform
	 * \param[in] Vector3[] coordonne point
	 * \param[in] Vector3 vitesse
	 * \param[in] int time
	 * \return Vector4[]
	 */ 
	public static Vector4[] lorentzTransform(Vector3 [] verts, Vector3 vit, float time)
	{
		Vector4 [] v4d = new  Vector4[verts.Length];
		for (int i=0;i<verts.Length;++i)
		{
			//v4d vecteur base
			Vector3 v3d =  verts[i];
			v4d[i] = (lorentzTransformOnePoint(v3d, vit, time));
		}
		return v4d;
	}
	
	/**
	 * \fn beta
	 * \brief calcul the beta factor
	 * \param[in] Vector3
	 * \return double
	 */
	public static double beta(Vector3 vit)
	{
		return ((double)getRootVitSquare(vit)/SPEEDOFLIGHT);
	}
	
	/**
	 * \fn gamma
	 * \brief calcul the gamma factor
	 * \param[in] double 
	 * \return double
	 */ 
	public static double gamma(double beta)
	{
		return 1/Math.Sqrt(1-Math.Pow(beta,2));
	}
	
	/**
	 * \fn gamma
	 * \brief calcul the gamma factor
	 * \param[in] Vector3
	 * \return double
	 */ 
	public static double gamma(Vector3 vit)
	{
		double b = beta(vit);
		return gamma(b);
	}
	
	/**
	 * \fn getRootVitSquare
	 * \brief calcul the quadratic speed
	 * \param[in] vector3
	 * \return float
	 */ 
	public static float getRootVitSquare(Vector3 vit){
		return Math.Min((float)Math.Sqrt(Math.Pow(vit.x,2)+Math.Pow(vit.y,2)+Math.Pow(vit.z,2)), SPEEDOFLIGHT );
	}
	
	public static float prodVect(Vector3 a, Vector3 b)
	{
		Vector3 w;
		w.x = (a.y*b.z) - (a.z*b.y);
		w.y = (a.z*b.x) - (a.x*b.z);
		w.z = (a.x*b.y) - (a.y*b.x);
		return w.magnitude;
	}
	
	public static float prodScalaire(Vector3 a, Vector3 b)
	{
		return (a.x*b.x) + (a.y*b.y) + (a.z*b.z);
	}
	
	/**
	 * \fn lorentzTransformOnePoint
	 * \brief transform a point thanks to the lorentz transform
	 * \param[in] Vector3 coordonne point
	 * \param[in] Vector3 vitesse
	 * \param[in] int time
	 * \return Vector4
	 */ 
	public static Vector4 lorentzTransformOnePoint(Vector3 v3d, Vector3 vit, float time)
	{
		Vector4 v4d = v3d;
		v4d.w = time;
		//calcul of constant
		double b = beta(vit);
		double gam = gamma(b);
		double betax = vit.x/SPEEDOFLIGHT;
		double betay = vit.y/SPEEDOFLIGHT;
		double betaz = vit.z/SPEEDOFLIGHT;
		//v' calcul Lorentz Transformation
		Vector4 vprime;
		vprime.w =  (float)(v4d.w * gam * (1 -  betax - betay - betaz));
		vprime.x =  (float)(v4d.x * ( - gam * betax + ( 1 + (gam -1) * Math.Pow(betax,2) / Math.Pow(b,2) ) - (gam -1) * betax * betay / Math.Pow(b,2) - (gam -1) * betax * betaz / Math.Pow(b,2) ));
		vprime.y =  (float)(v4d.y * ( - gam * betay - (gam -1) * betax * betay / Math.Pow(b,2) + ( 1 + (gam -1) * Math.Pow(betay,2) / Math.Pow(b,2) ) - (gam -1) * betay * betaz / Math.Pow(b,2) ));
		vprime.z =  (float)(v4d.z * ( - gam * betaz - (gam -1) * betaz * betax / Math.Pow(b,2) - (gam -1) * betay * betaz / Math.Pow(b,2) + ( 1 + (gam -1) * Math.Pow(betaz,2) / Math.Pow(b,2) ) ));

		return vprime;
	}
}
