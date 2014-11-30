using UnityEngine;
using System.Collections;

	

public class PlayerState : Hitpoints {
	public GoblinStats stats = new GoblinStats(1,1,1,1,1,"lol");
	public AudioClip[] DamageSound;
	public AudioClip[] DeathSound;

	public void SetStats (GoblinStats s)
	{
		stats = new GoblinStats(s);
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
		GlobalVariables.vars.playerShouldRespawn = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void PlayDamageSound()
	{
		audio.PlayOneShot(DamageSound[Random.Range(0,DamageSound.Length)]);
	}
	
}
