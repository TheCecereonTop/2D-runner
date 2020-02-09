using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public float timePassed = 0;

	public Text Timetext;

	public Text brightText; 

	public int ModusActual = 0;

	private bool gameOver = false;

	public static UIManager uiManager;

	public GameObject gameOverMessage;

	// Use this for initialization
	void Awake () {
		if (uiManager == null) 
		{
			uiManager = this;
		} 

		else if (uiManager != this) 

		{
			Destroy (gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (!gameOver) 
		{
			timePassed += Time.deltaTime;
			Timetext.text = "Time: " + Mathf.Round (timePassed);
		}

		if (gameOver && Input.GetKeyDown (KeyCode.Space)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
			
		
	}

	public void setDeath()
	{
		ModusActual++;
		brightText.text = "Brights: " + Mathf.Round(ModusActual);
	}

	public int GetDeath()
	{
		return ModusActual;
	}

	public void ResetBrights()
	{
		brightText.text = "Brights: " + Mathf.Round(ModusActual);
	}

	public void GameOver()
	{
		gameOver = true;
		gameOverMessage.SetActive (true);
			
	}
}
