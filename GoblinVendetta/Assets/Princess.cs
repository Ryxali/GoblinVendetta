using UnityEngine;
using System.Collections;

public class Princess : Hitpoints {
	// Use this for initialization
	void Start () {
		if (transform.position.x < GlobalVariables.vars.cam.transform.position.x)
			rigidbody2D.AddForce(new Vector2(1,1) * Random.Range(100, 400));
		else
			rigidbody2D.AddForce(new Vector2(-1,1) * Random.Range (100, 400));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}