using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag != "Projectile" && other.tag != "Player")
			Destroy (transform.parent.gameObject);
	}

}
