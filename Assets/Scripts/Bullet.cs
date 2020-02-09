using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float DestroyTimer = 3;


	// Use this for initialization
	void Start () {
		Destroy (gameObject, DestroyTimer);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			//if(other.GetComponentInParent<PlayerControl>().shield.activeInHierarchy)
			//{
			//	other.GetComponentInParent<PlayerMovement> ().shield.SetActive (false);
			//}
			//else
			//{
			//	PlayerPrefs.CauseDamage();
			//}

			col.GetComponent<PlayerMovement> ().CauseDamage ();

			Destroy(gameObject);

			if (col.CompareTag ("FallDeath")) 
			{
				Destroy (gameObject);
			}
		}
	}
}
