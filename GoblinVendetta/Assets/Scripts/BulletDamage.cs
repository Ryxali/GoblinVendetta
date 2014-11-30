using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {
	public int damage = 1;
	public string allegiance = "Player";
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Projectile" && other.tag != "Ethereal" && other.tag != allegiance) {
			Destroy (transform.parent.gameObject);
			Hitpoints hp = other.transform.GetComponentInChildren<Hitpoints>();
			if(hp != null) {
				hp.Hit(damage);
			}
		}
	}

}
