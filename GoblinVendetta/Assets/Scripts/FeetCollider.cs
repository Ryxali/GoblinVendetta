using UnityEngine;
using System.Collections;

public class FeetCollider : MonoBehaviour {

	public Rigidbody2D body;
	private int nSurfacesHit = 0;
	public bool isGrounded { get; private set; }
	private bool feetTouching = false;
	void Update() {
		isGrounded = feetTouching && Mathf.Approximately(body.velocity.y, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Surface") {
			++nSurfacesHit;
		}
		feetTouching = nSurfacesHit > 0;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Surface") {
			--nSurfacesHit;
		}
		feetTouching = nSurfacesHit > 0;
	}
}
