using UnityEngine;
using System.Collections;

public class PeasantAI : MonoBehaviour {

	private float lastJump;
	private float currentSpeed;
	private int direction;
	public float jumpForce = 500;
	public float speed = 100;
	public float acceleration = 10;
	public PeasantStrike strike;
	public float attackspeed = 1;

	private float lastattack = 0;
	
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			GlobalVariables.vars.player.GetComponent<PlayerState>().Hit(1);
			GlobalVariables.vars.player.GetComponent<Controller2D>().Knockback(transform.position);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{	
		float difference = transform.position.x - GlobalVariables.vars.GetPlayerPos();
		if (difference > 0)
			direction = -1;
		else 
			direction = 1;
		Vector3 nPos = new Vector3 ();
		nPos.x = strike.transform.position.x * direction;
		nPos.y = strike.transform.position.y;
		nPos.z = strike.transform.position.z;
		strike.transform.position = nPos;
		
		currentSpeed += acceleration * Time.deltaTime * direction;
		
		if (currentSpeed > speed)
			currentSpeed = speed;
		else if (currentSpeed < -speed)
			currentSpeed = -speed;
		
		Vector2 vel = rigidbody2D.velocity;
		vel.x = currentSpeed;
		rigidbody2D.velocity = vel;
		/*if (lastattack + attackspeed < Time.time) {
			lastattack = Time.time;
			StartCoroutine(strike.Strike());
		}*/
	}
	
	void Jump ()
	{
		rigidbody2D.AddForce(Vector2.up * jumpForce);
	}
}
