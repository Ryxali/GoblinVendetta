using UnityEngine;
using System.Collections;

public class Baroness : Hitpoints {
	enum State {normal, whirlwind, lunge};
	State state = State.normal;
	public Animator sprite;
	public int lungeDistance;
	public float lungeForce, jumpForce;
	public int whirlDmg, lungeDmg;
	public int princessSpawnInterval;
	float nextSpawn;
	public GameObject princess;
	public Transform spawnPos1, spawnPos2;
	float currentSpeed;
	public float speed, whirlSpeed, acceleration;

	public FeetCollider feet;
	public AudioSource BaronessWhirlwindSound;
	public AudioClip[] BaronessLungeSound;
	public GameObject gore;

	//bool Eprincess = false;

	public override void Die (){
		//audio.PlayOneShot(BaronessDeathSound[Random.Range(0,BaronessDeathSound.Length)]);
		GameObject o = (GameObject)Instantiate (gore);
		o.transform.position = transform.position;
		GlobalVariables.vars.BossMusicAlive = false;
		GlobalVariables.vars.BaronessIsDead = true;
		base.Die ();
		}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Princess") {
			Destroy(other.gameObject);
			//nextSpawn = Time.time + princessSpawnInterval;
			//Eprincess = false;
			if (state != State.whirlwind)
			{
				state = State.whirlwind;
				StartCoroutine(Whirlwind());
			}
		}
		else if (other.gameObject.tag == "Player") {
			if (state == State.whirlwind)
				GlobalVariables.vars.player.GetComponent<PlayerState>().Hit(whirlDmg);
			else if (state == State.lunge)
				GlobalVariables.vars.player.GetComponent<PlayerState>().Hit(lungeDmg);
			GlobalVariables.vars.player.GetComponent<Controller2D>().Knockback(transform.position);
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

		/*if (!Eprincess && nextSpawn < Time.time) {
			if (Random.Range(0, 2) == 0)
				Instantiate(princess, spawnPos1.position, spawnPos1.rotation);
			else 
				Instantiate(princess, spawnPos2.position, spawnPos2.rotation);
			Eprincess = true;
		}*/

		if (nextSpawn < Time.time) {
			if (Random.Range(0, 2) == 0)
				Instantiate(princess, spawnPos1.position, spawnPos1.rotation);
			else 
				Instantiate(princess, spawnPos2.position, spawnPos2.rotation);
			nextSpawn = Time.time + princessSpawnInterval;
		}
	}

	IEnumerator Whirlwind ()
	{
		BaronessWhirlwindSound.Play ();
		sprite.SetTrigger ("Whirlwind_Begin");
		yield return null;


		for (int i = 0; i < 5; i++) {
			Debug.Log("Woh");
			while (!feet.isGrounded)
			{
				Debug.Log ("Yay");
				yield return null;
			}
			Debug.Log ("Trololo");
			float difference = transform.position.x - GlobalVariables.vars.GetPlayerPos();
			int direction;
			if (difference > 0)
				direction = -1;
			else 
				direction = 1;
			
			currentSpeed = whirlSpeed * direction;
			
			Vector2 vel = rigidbody2D.velocity;
			vel.x = currentSpeed;

			rigidbody2D.velocity = (vel + (jumpForce * Vector2.up));
			yield return null;
		}
		state = State.normal;
		BaronessWhirlwindSound.Stop ();

		yield return null;
		sprite.SetTrigger ("Whirlwind_End");
	}

	IEnumerator Lunge(int d)
	{
		audio.PlayOneShot(BaronessLungeSound[Random.Range(0,BaronessLungeSound.Length)]);
		sprite.SetTrigger ("Dash_Begin");
		Vector2 vel = rigidbody2D.velocity;
		vel.x = lungeForce * d;
		rigidbody2D.velocity = vel;
		yield return new WaitForSeconds(3);
		if (state != State.whirlwind)
			state = State.normal;
		currentSpeed = 0;
		sprite.SetTrigger ("Dash_End");
		yield return null;
	}

}