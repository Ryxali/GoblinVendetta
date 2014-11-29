using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {

	private Transform character;
	private Vector2 dir;
	public float speed;

	// Use this for initialization
	void Awake () {
		character = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		dir.x = Input.GetAxis ("Horizontal");
		dir.y = Input.GetAxis ("Vertical");
		float x = character.position.x + dir.x * Time.deltaTime * speed;
		Vector3 t = new Vector3 ();
		t.x = x;
		character.position = t;
	}
}
