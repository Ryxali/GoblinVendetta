using UnityEngine;
using System.Collections;

public class Hitpoints : MonoBehaviour {
	public int hp;
	public virtual void Hit (int damage)
	{
		hp -= damage;
	}
}
