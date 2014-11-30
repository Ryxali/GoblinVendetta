using UnityEngine;
using System.Collections;

	

public class PlayerState : Hitpoints {
	public GoblinStats stats = new GoblinStats(10,1,10,5,5,"Standard");
	public AudioClip[] DamageSound;
	public AudioClip[] DeathSound;

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
