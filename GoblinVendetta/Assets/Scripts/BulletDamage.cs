using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {
	int damage = 1;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Projectile" && other.tag != "Player") {
			Destroy (transform.parent.gameObject);
			Hitpoints hp = other.transform.GetComponentInChildren<Hitpoints>();
			if(hp != null) {
				hp.Hit(damage);
			}
		}
	}

}
