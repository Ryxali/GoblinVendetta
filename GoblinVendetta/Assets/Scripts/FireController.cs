using UnityEngine;
using System.Collections;
//[RequireComponent(Controller2D)]
public class FireController : MonoBehaviour {

	public Animator sprite;
	public AudioClip[] ShootSound;
	public GameObject projectile;
	public GameObject explosion;
	public float recoil = 8;
	public float projectileSpeed = 8;
	public float scatter = 1;
	public int projectiles = 8;
	public Vector2 offset = new Vector2(1, 1);
	private Controller2D controller;
	private bool canFire = true;

	// Use this for initialization
	void Awake () {
		controller = transform.GetComponent<Controller2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(canFire && !controller.isFlying && Input.GetButtonDown("Fire1")) {
			canFire = false;
			sprite.SetTrigger("Fire");
			Vector3 force = new Vector3();
			int t = -1;
			if((Screen.width / 2 - Input.mousePosition.x) > 0 ) {
				t = 1;
			}
			PlayShootSound();
			force.x = recoil * t;
			transform.rigidbody2D.AddRelativeForce(force);
			force.x = projectileSpeed * -t;
			GameObject e = (GameObject)Instantiate(explosion);
			e.transform.position = controller.transform.position + new Vector3(offset.x * -t, offset.y, 0);
			for(int i = 0; i < projectiles; ++i) {

				GameObject o = (GameObject)Instantiate(projectile);
				Vector3 off = new Vector3(offset.x + Random.Range(-1, 1)*scatter, offset.y + i * (scatter) - scatter/2, 0);
				off.x *= -t;
				o.transform.position = controller.transform.position + off;

				o.rigidbody2D.velocity = force;
			}

		}
		canFire = !sprite.GetCurrentAnimatorStateInfo (0).IsTag ("fire");
	}

	public void FireDown() {
		Vector3 force = new Vector3();
		//force.y = recoil;
		//transform.rigidbody2D.AddRelativeForce(force);
		force.y = -projectileSpeed;
		PlayShootSound ();
		for(int i = 0; i < projectiles; ++i) {
			
			GameObject o = (GameObject)Instantiate(projectile);
			Vector3 off = new Vector3(i * (scatter) - scatter/2, Random.Range(-1, 1)*scatter, 0);
			o.transform.position = controller.transform.position + off;
			
			o.rigidbody2D.velocity = force;
		}
	}

	void PlayShootSound()
	{
		if(ShootSound.Length > 0)
			audio.PlayOneShot(ShootSound[Random.Range(0,ShootSound.Length)]);
	}

	public void SetStats(GoblinStats s)
	{
		projectiles = s.dmg;
	}
}
