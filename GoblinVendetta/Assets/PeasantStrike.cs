using UnityEngine;
using System.Collections;

public class PeasantStrike : MonoBehaviour {
	public int damage = 1;
	public AudioClip[] PAttackSound;

	// Indicates the player is within the bounds
	private bool present = false;
	void OnTriggerEnter2D(Collider2D other) {
		present = other.tag == "Player";

		if (other.tag == "Player") {
			GlobalVariables.vars.player.GetComponent<PlayerState>().Hit(1);
			GlobalVariables.vars.player.GetComponent<Controller2D>().Knockback(transform.position);
		}
	}

	void OnTriggerLeave2D(Collider2D other) {
		present = !(other.tag == "Player") && present;
	}

	void Awake() {
		StartCoroutine (Strike ());
	}

	public IEnumerator Strike() {
<<<<<<< HEAD
		if (present) {
			PlayPAttackSound();
			GlobalVariables.vars.player.GetComponent<PlayerState>().Hit(damage);
			GlobalVariables.vars.player.GetComponent<Controller2D>().Knockback(GetComponentInParent<Transform>().position);
=======
		while (true) {
			PlayPAttackSound ();
			yield return new WaitForSeconds (0.4f);
>>>>>>> master
		}
	}

	void PlayPAttackSound()
	{
		if(PAttackSound.Length > 0)
			audio.PlayOneShot(PAttackSound[Random.Range(0,PAttackSound.Length)]);
	}

}
