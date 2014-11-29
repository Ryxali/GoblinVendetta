using UnityEngine;
using System.Collections;

public class PeasantAI : MonoBehaviour {

	private float lastJump;
	private float currentSpeed;
	private int direction;
	public float jumpForce = 500;
	public float speed = 100;
	public float acceleration = 10;
	public GlobalVariables globalVariables;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{	
		float difference = transform.position.x - globalVariables.GetPlayerPos();
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
	}
	
	void Jump ()
	{
		rigidbody2D.AddForce(Vector2.up * jumpForce);
	}
}
