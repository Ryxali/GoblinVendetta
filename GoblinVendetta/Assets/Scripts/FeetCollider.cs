using UnityEngine;
using System.Collections;

public class FeetCollider : MonoBehaviour {

	public Rigidbody2D body;

	public bool isGrounded { get; private set; }
	private bool feetTouching = false;
	void Update() {
		isGrounded = feetTouching && Mathf.Approximately(body.velocity.y, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		feetTouching = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		feetTouching = false;
	}
}
