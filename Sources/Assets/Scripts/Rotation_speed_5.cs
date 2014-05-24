using UnityEngine;
using System.Collections;

public class Rotation_speed_5: MonoBehaviour {
	public float speed = 1;
	float speed_augmentation = 40;

	public Vector3 direction = new Vector3(0,1,0);
	void Update () {
		transform.Rotate( direction * speed * Time.deltaTime*speed_augmentation);
	}
}
