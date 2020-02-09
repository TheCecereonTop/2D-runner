using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {

	public List<GameObject> groundList = new List<GameObject>();

	public static GroundSpawner groundSpawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn()
	{
		int groundIndex = UnityEngine.Random.Range (0, 3);
		Instantiate (groundList[groundIndex], transform.position, transform.rotation);
		//Debug.Log ("yay?");
	}
}
