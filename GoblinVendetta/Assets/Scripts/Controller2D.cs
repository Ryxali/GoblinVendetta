 	using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {
	FireController fController;
	private Transform character;
	private Vector2 dir;
	// Current target
	private Vector3 target;
	private bool doubleJumped = false;
	public Animator sprite;
	public Transform pivot;
	// Acceleration
	public float speed = 5;
	// Terminal leg-providied velocity
	public float maxSpeed = 10;
	public float jumpForce = 10;

	public const int LEFT = -1;
	public const int RIGHT = 1;

	public bool isFlying { get {return flying;}}
	private bool flying = false;

	public AudioClip[] BallistaSound;
	public AudioClip[] JumpSound;


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
		flying = true;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().Sleep();
		sprite.SetTrigger ("Reset");
		GlobalVariables.vars.camFollower.clip = false;
		GlobalVariables.vars.guitext.text = transform.GetComponent<PlayerState>().stats.description;
		yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().WakeUp();
		for (int i = 0; i < GlobalVariables.vars.spawnFolder.transform.childCount; ++i) {
			Destroy(GlobalVariables.vars.spawnFolder.transform.GetChild(i).gameObject);
		}
		GetComponent<AudioSource>().PlayOneShot(BallistaSound[Random.Range(0,BallistaSound.Length)]);
		GlobalVariables.vars.guitext.text = transform.GetComponent<PlayerState>().stats.description;
		float difference = GlobalVariables.vars.landingPosition.x - transform.position.x;
		float airtime = 5;
		float s = difference / airtime;
		while (transform.position.x < GlobalVariables.vars.landingPosition.x - (difference * 0.3f)) {
			float y;
			y = Mathf.MoveTowards (transform.position.y, 20, 0.5f);
			Vector3 vec = new Vector3 (transform.position.x, y, transform.position.z);
			transform.position = vec;
			Vector2 vel = Vector2.right * s;
			transform.GetComponent<Rigidbody2D>().velocity = vel;
			yield return null;
		}
		while (!feet.isGrounded) {
			yield return null;
		}
		flying = false;
		GlobalVariables.vars.guitext.text = "";
		GlobalVariables.vars.camFollower.clip = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flying == false) {
			sprite.SetBool("isGrounded", feet.isGrounded);
			Vector3 f = Vector3.one;
			if((Screen.width / 2 - Input.mousePosition.x) > 0 )
				f.x *= -1;
			pivot.localScale = f;

			Vector3 curVel = new Vector3 ();
			curVel.x = character.GetComponent<Rigidbody2D>().velocity.x;
			curVel.y = character.GetComponent<Rigidbody2D>().velocity.y;

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
					sprite.SetTrigger("Jump");
					//character.rigidbody2D.AddRelativeForce(new Vector2(0, jumpForce));
					doubleJumped = false;
					curVel.y = jumpForce;
					PlayJumpSound();
				} else if (!doubleJumped) {
					sprite.SetTrigger("DoubleJump");
					doubleJumped = true;
					curVel.y += jumpForce / 2;
					fController.FireDown ();
				}
			}


			character.GetComponent<Rigidbody2D>().velocity = curVel + t;
			sprite.SetFloat("xVelocity", character.GetComponent<Rigidbody2D>().velocity.x);

		}
	}
	void PlayJumpSound()
	{
		GetComponent<AudioSource>().PlayOneShot(JumpSound[Random.Range(0,JumpSound.Length)]);
	}

	public void SetStats(GoblinStats s)
	{
		maxSpeed = s.speed;
		jumpForce = s.jumpforce;
	}

	public void Knockback(Vector3 otherpos)
	{
		int dir;
		if (otherpos.x - transform.position.x > 0)
			dir = -1;
		else
			dir = 1;
		Vector2 vel = GetComponent<Rigidbody2D>().velocity;
		vel.x = maxSpeed * dir;
		GetComponent<Rigidbody2D>().velocity = vel;
	}
}
