using UnityEngine;
using System.Collections;

public class GoblinStats {

	public float speed, height, jumpforce;
	public int hp, dmg;
	public string description;

	public GoblinStats (float speed, float height, float jumpforce, int hp, int dmg, string description)
	{
		this.speed = speed;
		this.height = height;
		this.jumpforce = jumpforce;
		this.hp = hp;
		this.dmg = dmg;
		this.description = description;
	}

	public GoblinStats (GoblinStats stats)
	{
		speed = stats.speed;
		height = stats.height;
		jumpforce = stats.jumpforce;
		hp = stats.hp;
		dmg = stats.dmg;
		description = stats.description;
	}
}
