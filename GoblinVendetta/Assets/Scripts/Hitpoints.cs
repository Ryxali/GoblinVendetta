using UnityEngine;
using System.Collections;

public class Hitpoints : MonoBehaviour {
	public int hp;
	public virtual void Hit (int damage)
	{
		hp -= damage;
		if (hp <= 0)
			Die ();
	}

	public virtual void Die() {
		Destroy (gameObject);
	}
}