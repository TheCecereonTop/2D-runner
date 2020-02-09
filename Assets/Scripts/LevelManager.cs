using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public static LevelManager levelManager;

//	private float seconds;
//	private int secondsToInt;
//	private int minutes

	// Use this for initialization
	void Awake () {
		if (levelManager == null) 
		{
			levelManager = this;
		} 

		else if (levelManager != this) 
			
		{
			Destroy (gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
