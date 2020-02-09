using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy {

	public Rigidbody2D bulletPrefab;
	public float shootingForce = 5;

	public void Bullet ()
	{

		Rigidbody2D tempBullet = Instantiate (bulletPrefab, transform.position, transform.rotation) as Rigidbody2D;
		tempBullet.AddForce(Vector2.left * shootingForce, ForceMode2D.Impulse);
	}
}