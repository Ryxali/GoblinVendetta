﻿using UnityEngine;
using System.Collections;

public class MoneyladyAI : MonoBehaviour {

	private float lastToss;
	private float currentSpeed;
	private int direction;
	public float jumpForce = 500;
	public float speed = 100;
	public float acceleration = 10;

	public AudioClip[] LadyAttackSound;
	public GameObject projectile;
	public float projectileSpeed = 10;
	public float tossInterval = 3;
	public int coinsPerToss = 5;
	public float minAngle = -30;
	public float maxAngle = 30;
	public float angleRadius;
	public Vector2 offset;

	private Vector3 minEuler;
	private Vector3 maxEuler;



	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		minEuler = Quaternion.AngleAxis (minAngle, Vector3.forward) * Vector3.up;
		maxEuler = Quaternion.AngleAxis (maxAngle, Vector3.forward) * Vector3.up;
		if (Time.time - lastToss > tossInterval) {

			PlayLadyAttackSound();
			for(int i = 0; i < coinsPerToss; ++i) {
				GameObject o = (GameObject)Instantiate(projectile);
				
				o.transform.position =
					transform.position +
					new Vector3(offset.x, offset.y, 0) +
					Vector3.Lerp(minEuler, maxEuler, (float)i / (float)coinsPerToss) * angleRadius;
				
				o.GetComponent<Rigidbody2D>().velocity = 
					(o.transform.position - transform.position).normalized * 
					projectileSpeed + 
					new Vector3(transform.GetComponent<Rigidbody2D>().velocity.x, transform.GetComponent<Rigidbody2D>().velocity.y, 0);
			}
			lastToss = Time.time;
		}
		
		float difference = transform.position.x - GlobalVariables.vars.GetPlayerPos();
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

	void PlayLadyAttackSound()
	{
		if(LadyAttackSound.Length > 0)
			GetComponent<AudioSource>().PlayOneShot(LadyAttackSound[Random.Range(0,LadyAttackSound.Length)]);
	}
}
