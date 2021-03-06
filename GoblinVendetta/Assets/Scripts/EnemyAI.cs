﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

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
		if (Time.time - lastJump > 3) {
			Jump ();
			lastJump = Time.time;
		}

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

		Vector2 vel = GetComponent<Rigidbody2D>().velocity;
		vel.x = currentSpeed;
		GetComponent<Rigidbody2D>().velocity = vel;
	}

	void Jump ()
	{
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
	}
}
