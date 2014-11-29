﻿ 	using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {
	FireController fController;
	private Transform character;
	private Vector2 dir;
	// Current target
	private Vector3 target;
	// Current velocity
	private Vector3 vel;
	private bool doubleJumped = false;
	// Acceleration
	public float speed = 5;
	// Terminal leg-providied velocity
	public float maxSpeed = 10;
	public float jumpForce = 10;

	public const int LEFT = -1;
	public const int RIGHT = 1;

	private bool flying = false;


	public float facing {
		get { return fac; }
		private set {
			if(value > 0) {
				fac = LEFT;
			} else if(value < 0) {
				fac = RIGHT;
			}
		}
	}
	private int fac = RIGHT;

	public bool facingRight { get {return facing == RIGHT; } }
	public bool facingLeft { get {return facing == LEFT; } }

	public FeetCollider feet;

	// Use this for initialization
	void Awake () {
		character = this.transform;
		fController = transform.GetComponent<FireController> ();
	}

	public IEnumerator Fly ()
	{
		GlobalVariables.vars.guitext.text = transform.GetComponent<PlayerState>().stats.description;
		flying = true;
		yield return new WaitForSeconds(5);

		while (transform.position.x < GlobalVariables.vars.landingPosition.x - 10) {
			float y;
			y = Mathf.MoveTowards (transform.position.y, 20, 1);
			Vector3 vec = new Vector3 (transform.position.x, y, transform.position.z);
			transform.position = vec;
			Vector2 vel = Vector2.right * 3;
			transform.rigidbody2D.velocity = vel;
			yield return null;
		}
		while (!feet.isGrounded) {
			yield return null;
		}
		flying = false;
		GlobalVariables.vars.guitext.text = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flying == false) {
			Vector3 curVel = new Vector3 ();
			curVel.x = character.rigidbody2D.velocity.x;
			curVel.y = character.rigidbody2D.velocity.y;

			dir.x = Input.GetAxis ("Horizontal");
			dir.y = Input.GetAxis ("Vertical");

			Vector3 t = new Vector3 ();
			t.x = dir.x * speed * Time.deltaTime + curVel.x;
			if (curVel.x != 0) {
				facing = curVel.x;
				curVel.x = 0;
			}


			if (t.magnitude > maxSpeed) {
				t = t.normalized * maxSpeed;
			}
			//character.position = t;
			if (Input.GetButtonDown ("Jump")) {
				if (feet.isGrounded) {
					//character.rigidbody2D.AddRelativeForce(new Vector2(0, jumpForce));
					doubleJumped = false;
					curVel.y = jumpForce;
				} else if (!doubleJumped) {
					doubleJumped = true;
					curVel.y = jumpForce / 2;
					fController.FireDown ();
				}
			}


			character.rigidbody2D.velocity = curVel + t;

		}
	}
}
