﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDestroye : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player"))
			Destroy (this.gameObject);

	}
}
