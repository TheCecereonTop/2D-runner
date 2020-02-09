using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	public void FixedUpdate ()
	{
		Vector3 pos = target.position + offset;
		Vector2 Spos = Vector2.Lerp (transform.position, pos, smoothSpeed);
		transform.position = Spos;

		transform.LookAt (target);
	}

}
