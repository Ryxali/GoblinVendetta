using UnityEngine;
using System.Collections;

public class Princess : Hitpoints {
	// Use this for initialization
	public Animator sprite;
	public GameObject gore;

	public override void Die(){
		//PrincessDeathSound.Play ();
		GameObject o = (GameObject)Instantiate (gore);
		o.transform.position = transform.position;
		base.Die ();
	}
	                         
	void Start () {
		if (transform.position.x < GlobalVariables.vars.cam.transform.position.x)
			GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1) * Random.Range(100, 400));
		else
			GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,1) * Random.Range (100, 400));
	}
	
	// Update is called once per frame
	void Update () {
		sprite.SetBool ("Flying", GetComponent<Rigidbody2D>().velocity.y < 0.1);
	}
}