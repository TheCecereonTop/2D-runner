using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

	public bool Chomper;
	public bool Shooter;
	public bool Bright;

	public int chomperRatio = 5;
	public int shooterRatio = 5;
	public int brightRatio  =5;

	public GameObject chomperEnemy;
	public GameObject shooterEnemy;
	public GameObject brightObject;

	// Use this for initialization
	void Start () {

		timeCheck ();
			

		int chomperChance = UnityEngine.Random.Range (0, chomperRatio);
		int shooterChance = UnityEngine.Random.Range (0, shooterRatio);
		int brightChance = UnityEngine.Random.Range (0, brightRatio);

		if (chomperChance == 0 && Chomper == true)
			Instantiate (chomperEnemy, transform.position, transform.rotation);
		if (shooterChance == 0 && Shooter == true)
			Instantiate (shooterEnemy, transform.position, transform.rotation);
		if (brightChance == 0 && Bright == true)
			Instantiate (brightObject, transform.position, transform.rotation);

		//Debug.Log ("Chomper: " + chomperRatio);
		//Debug.Log ("Shooter: " + shooterRatio);
		//Debug.Log ("Bright: " + brightRatio);
		
	}

	public void timeCheck()
	{
		if (UIManager.uiManager.timePassed < 30) 
		{
			chomperRatio = 5;
			shooterRatio = 5;
			brightRatio = 5;
		}

		if (UIManager.uiManager.timePassed > 30 && UIManager.uiManager.timePassed < 60) 
		{
			chomperRatio = 5;
			shooterRatio = 5;
			brightRatio = 6;
		}
		if (UIManager.uiManager.timePassed > 60 && UIManager.uiManager.timePassed < 90) 
		{
			chomperRatio = 4;
			shooterRatio = 4;
			brightRatio = 7;
		}

		if (UIManager.uiManager.timePassed > 90 && UIManager.uiManager.timePassed < 120) 
		{
			chomperRatio = 4;
			shooterRatio = 4;
			brightRatio = 8;
		}

		if (UIManager.uiManager.timePassed > 120 && UIManager.uiManager.timePassed < 150) 
		{
			chomperRatio = 3;
			shooterRatio = 3;
			brightRatio = 9;
		}
		if (UIManager.uiManager.timePassed > 150 && UIManager.uiManager.timePassed < 180) 
		{
			chomperRatio = 3;
			shooterRatio = 3;
			brightRatio = 10;
		}
		if (UIManager.uiManager.timePassed > 180 && UIManager.uiManager.timePassed < 210) 
		{
			chomperRatio = 2;
			shooterRatio = 2;
			brightRatio = 11;
		}
		if (UIManager.uiManager.timePassed > 210 && UIManager.uiManager.timePassed < 240) 
		{
			chomperRatio = 2;
			shooterRatio = 2;
			brightRatio = 12;
		}
		if (UIManager.uiManager.timePassed > 240 && UIManager.uiManager.timePassed < 270) 
		{
			chomperRatio = 1;
			shooterRatio = 1;
			brightRatio = 13;
		}
		if (UIManager.uiManager.timePassed > 270 && UIManager.uiManager.timePassed < 300) 
		{
			chomperRatio = 1;
			shooterRatio = 1;
			brightRatio = 14;
		}
		if (UIManager.uiManager.timePassed > 300 && UIManager.uiManager.timePassed < 330) 
		{
			chomperRatio = 1;
			shooterRatio = 1;
			brightRatio = 15;
		}
		if (UIManager.uiManager.timePassed >= 360) 
		{
			chomperRatio = 1;
			shooterRatio = 1;
			brightRatio = 16;
		}
	}

	
}
