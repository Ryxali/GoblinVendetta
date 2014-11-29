 	using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {

	private Transform character;
	private Vector2 dir;
	// Current target
	private Vector3 target;
	// Current velocity
	private Vector3 vel;

	// Acceleration
	public float speed = 5;
	// Terminal leg-providied velocity
	public float maxSpeed = 10;
	public float jumpForce = 10;

	public FeetCollider feet;

	// Use this for initialization
	void Awake () {
		character = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 curVel = new Vector3 ();
		curVel.x = character.rigidbody2D.velocity.x;
		curVel.y = character.rigidbody2D.velocity.y;

		dir.x = Input.GetAxis ("Horizontal");
		dir.y = Input.GetAxis ("Vertical");

		Vector3 t = new Vector3 ();
		t.x = dir.x * speed * Time.deltaTime + curVel.x;
		curVel.x = 0;

		if (t.magnitude > maxSpeed) {
			t = t.normalized * maxSpeed;
		}
		//character.position = t;
		if (feet.isGrounded && Input.GetButton ("Jump")) {
			//character.rigidbody2D.AddRelativeForce(new Vector2(0, jumpForce));
			curVel.y = jumpForce;
		}

		character.rigidbody2D.velocity = curVel + t;


	}
}
