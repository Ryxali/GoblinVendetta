using UnityEngine;
using System.Collections;

public class Baroness : Hitpoints {
	enum State {normal, whirlwind, lunge};
	State state = State.normal;
	public int lungeDistance;
	public float lungeForce, jumpForce;
	public int whirlDmg, lungeDmg;

	float currentSpeed;
	public float speed, whirlSpeed, acceleration;

	public FeetCollider feet;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.ToString() == "Princess") {
			state = State.whirlwind;
		}
		else if (other.gameObject.ToString() == "Player") {
			if (state == State.whirlwind)
				GlobalVariables.vars.player.GetComponent<PlayerState>().Hit(whirlDmg);
			else if (state == State.lunge)
				GlobalVariables.vars.player.GetComponent<PlayerState>().Hit(lungeDmg);
		}
	}

	void Update ()
	{
		if (state == State.normal) {
			int direction;
			float difference = transform.position.x - GlobalVariables.vars.GetPlayerPos ();
			if (difference > 0)
				direction = -1;
			else 
				direction = 1;
			
			currentSpeed += acceleration * Time.deltaTime * direction;
			
			if (currentSpeed > speed)
				currentSpeed = speed;
			else if (currentSpeed < -speed)
				currentSpeed = -speed;
			
			Vector2 vel = rigidbody2D.velocity;
			vel.x = currentSpeed;
			rigidbody2D.velocity = vel;

			//Lunge
			if ((difference > 0 && difference < lungeDistance) || (difference < 0 && difference > -lungeDistance)) {
				state = State.lunge;
				StartCoroutine (Lunge (direction));
			}
		}
	}

	IEnumerator Whirlwind ()
	{
		for (int i = 0; i < 5; i++) {
			while (!feet.isGrounded)
			{
				yield return null;
			}
			float difference = transform.position.x - GlobalVariables.vars.GetPlayerPos();
			int direction;
			if (difference > 0)
				direction = -1;
			else 
				direction = 1;
			
			currentSpeed = whirlSpeed * direction;
			
			Vector2 vel = rigidbody2D.velocity;
			vel.x = currentSpeed;
			rigidbody2D.velocity = vel;

			rigidbody2D.AddForce(jumpForce * Vector2.up);
		}
		state = State.normal;
		yield return null;
	}

	IEnumerator Lunge(int d)
	{
		Vector2 vel = rigidbody2D.velocity;
		vel.x = lungeForce * d;
		rigidbody2D.velocity = vel;
		yield return new WaitForSeconds(3);
		state = State.normal;
		currentSpeed = 0;
		yield return null;
	}
}