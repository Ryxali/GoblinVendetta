using UnityEngine;
using System.Collections;
//[RequireComponent(Controller2D)]
public class FireController : MonoBehaviour {

	public GameObject projectile;
	public float recoil = 8;
	public float projectileSpeed = 8;
	public float scatter = 1;
	public int projectiles = 8;
	public Vector2 offset = new Vector2(1, 1);
	private Controller2D controller;

	// Use this for initialization
	void Awake () {
		controller = transform.GetComponent<Controller2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Vector3 force = new Vector3();
			int t = -1;
			if((Screen.width / 2 - Input.mousePosition.x) > 0 ) {
				t = 1;
			}
			force.x = recoil * t;
			transform.rigidbody2D.AddRelativeForce(force);
			force.x = projectileSpeed * -t;
			for(int i = 0; i < projectiles; ++i) {

				GameObject o = (GameObject)Instantiate(projectile);
				Vector3 off = new Vector3(offset.x + Random.Range(-1, 1)*scatter, offset.y + i * (scatter) - scatter/2, 0);
				off.x *= -t;
				o.transform.position = controller.transform.position + off;

				o.rigidbody2D.velocity = force;
			}

		}
	}

	public void FireDown() {
		Vector3 force = new Vector3();
		//force.y = recoil;
		//transform.rigidbody2D.AddRelativeForce(force);
		force.y = -projectileSpeed;
		for(int i = 0; i < projectiles; ++i) {
			
			GameObject o = (GameObject)Instantiate(projectile);
			Vector3 off = new Vector3(i * (scatter) - scatter/2, Random.Range(-1, 1)*scatter, 0);
			o.transform.position = controller.transform.position + off;
			
			o.rigidbody2D.velocity = force;
		}
	}
}
