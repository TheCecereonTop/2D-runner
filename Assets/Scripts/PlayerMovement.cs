using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public static PlayerMovement playerMovement;

	private bool jump = false;
	public float moveForce = 20;
	public float maxSpeed = 10;
	public float jumpForce = 300;
	public float dashForce = 200;
	public Transform groundCheck;

	private bool onGround = false;
	private float horForce = 1;
	private bool dash = false;
	private Rigidbody2D rb;
	private GameObject gs;
	private bool Vivo = true;
	public bool canTriggerGround = true;

	public BoxCollider2D hitbox;

	//public int totalBrights;

	private bool damaged = false;

	private Animator anime;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anime = GetComponent<Animator> ();
		gs = GameObject.Find ("Ground Spawner");
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		//Debug.Log ("Brights: " + UIManager.uiManager.ModusActual);
		onGround = Physics2D.Linecast(transform.position,groundCheck.position,1<<LayerMask.NameToLayer("Ground"));

		anime.SetBool ("onGround", onGround);

		if (onGround) 
		{
			anime.SetBool ("Jump", false);
		}

		anime.SetBool ("Dash", dash);

		if (dash && !damaged) 
		{
			horForce -= 0.01f;
			if (rb.velocity.x <= 1) 
			{
				dash = false;
				horForce = 1;
			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			Jump ();
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			Dash ();
		}

		//totalBrights = UIManager.uiManager.ModusActual;
		//Debug.Log (UIManager.uiManager.ModusActual);

		//if (onGround == true)
			//Debug.Log ("Liftoff!");
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (1);
	}

	private void FixedUpdate()
	{
		if (Vivo) 
		{
			anime.SetFloat ("Speed", rb.velocity.x);
			rb.AddForce (Vector2.right * horForce * moveForce);
			if (rb.velocity.x > maxSpeed)
				rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x)*maxSpeed, rb.velocity.y);
			if (jump && !damaged) 
			{
				anime.SetBool ("Jump", true);
				rb.AddForce (new Vector2 (0, jumpForce));
				jump = false;
			}
			if (dash && !damaged) 
			{
				anime.SetBool ("Dash", true);
				rb.AddForce (new Vector2 (dashForce, 0.1f));
				StartCoroutine (Wait ());
				dash = false;
			}
		}
	}

	public void Jump ()
	{
		if (onGround) 
		{
			jump = true;
			//Debug.Log ("Jumped!");
		}
	}

	public void Dash()
	{
		if (onGround) 
		{
			dash = true;
			Debug.Log (Vivo);
		}
	}

	public void deathDamage()
	{
		damaged = false;
		horForce = 1;
	}

	public void CauseDamage()
	{
		if (damaged) {
			return;

		} 

		else if (Vivo && !damaged) 
		
		{
			
			if (UIManager.uiManager.ModusActual > 0) 
			{
				Debug.Log("Brights when hit: " + UIManager.uiManager.ModusActual);
				damaged = true;
				dash = false;
				jump = false;
				anime.SetBool ("Jump", false);
				rb.velocity = Vector2.zero;
				anime.SetTrigger ("Damaged");
				rb.AddForce (new Vector2 (-10, 10), ForceMode2D.Impulse);
				horForce = 0;

				if (UIManager.uiManager.ModusActual >= 10) 
				{
					UIManager.uiManager.ModusActual -= 10;
				}
				else if (UIManager.uiManager.ModusActual < 10) 
				{
					UIManager.uiManager.ModusActual = 0;
				}
				
				//UIManager.uiManager.ModusActual = (totalBrights);
				UIManager.uiManager.ResetBrights ();
				Debug.Log("WHAT???");

			}
				
		}
	}

	public void Died()
	{
		if (Vivo) 
		{
			damaged = true;
			dash = false;
			jump = false;
			anime.SetBool ("Jump", false);
			rb.velocity = Vector2.zero;
			horForce = 0;
			rb.AddForce (Vector2.up * 20, ForceMode2D.Impulse);
			hitbox.enabled = false;
			anime.SetBool ("Die", true);
			Invoke ("GameOver", 2f);
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Bright")) 
		{
			col.gameObject.SetActive (false);
			UIManager.uiManager.setDeath ();
		}

		if (col.CompareTag ("Enemy")) 
		{
			if (UIManager.uiManager.ModusActual == 0)
				Died ();
			else
				CauseDamage ();


		}

		if (col.CompareTag ("FallDeath")) 

		{
			Died ();

		}

		if (col.CompareTag ("Checkpoint")) 
		{
			//Destroy (col.gameObject);
			if (canTriggerGround == true) 
			{
				canTriggerGround = false;
				gs.GetComponent<GroundSpawner> ().Spawn ();
				Debug.Log ("YAY???");
				StartCoroutine (Wait ());
				canTriggerGround = true;
			}
		}


	}

	//private void OnTriggerExit2D(Collider2D col)
	//{
		

		
	//}

	public void GameOver()
	{
		UIManager.uiManager.GameOver ();
	}
}
