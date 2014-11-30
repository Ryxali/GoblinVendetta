using UnityEngine;
using System.Collections;

	

public class PlayerState : Hitpoints {
	public GoblinStats stats = new GoblinStats(10,1,10,5,5,"Standard");
	public AudioClip[] DamageSound;
	public AudioClip[] DeathSound;
	public GameObject[] hearts;

	void Awake()
	{
		SetStats (stats);
	}

	public void SetStats (GoblinStats s)
	{
		stats = new GoblinStats(s);
		hp = stats.hp;
		Vector3 scale = transform.localScale;
		scale.y = stats.height;
		transform.localScale = scale;
		gameObject.GetComponent<Controller2D> ().SetStats (stats);
		gameObject.GetComponent<FireController> ().SetStats (stats);
	}

	public GoblinStats GetStats ()
	{
		return stats;
	}

	public override void Hit (int damage)
	{
		PlayDamageSound ();
		base.Hit (damage);
	}

	public override void Die() {
		audio.PlayOneShot(DeathSound[Random.Range(0,DeathSound.Length)]);
		GlobalVariables.vars.MusicDeath = true;
		GlobalVariables.vars.guitext.text = "STOPPA LÅTEN";
		GlobalVariables.vars.playerShouldRespawn = true;
	}

	void Update() {
		int i = 0;
		for (; i < hp; ++i)
			hearts [i].SetActive (true);
		for (; i < hearts.Length; ++i)
			hearts [i].SetActive (false);
	}

	void PlayDamageSound()
	{
		audio.PlayOneShot(DamageSound[Random.Range(0,DamageSound.Length)]);
	}
	
}
