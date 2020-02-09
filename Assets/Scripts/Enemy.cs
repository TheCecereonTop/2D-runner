using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D col)
	{
	//	if (col.CompareTag ("Shield")) 
		//{
			//other.GetComponentInParent<PlayerMovement>().shield.setActive(false);
			//gameObject.SetActive(false);
		//}

		if (col.CompareTag ("Attack"))
			Destroy (this.gameObject);
	}
}