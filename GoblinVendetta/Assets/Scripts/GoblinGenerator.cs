using UnityEngine;
using System.Collections;

public class GoblinGenerator {
	//The max difference in stat increases/decreases
	public float speed, height, jumpforce;
	public int hp, dmg;

	GoblinStats Generate (GoblinStats stats)
	{
		GoblinStats newStats = new GoblinStats(stats);
		int stat_1 = Rand (5);
		int stat_2 = stat_1;
		while (stat_2 == stat_1)
			stat_2 = Rand (5);
		string descr_start, descr_end;
		descr_start = "This goblin ";
		descr_end = " and ";

		if (stat_1 == 1) {
			descr_start += "is faster";
			newStats.speed += Random.Range (0, speed);
		} else if (stat_1 == 2) {
			descr_start += "is taller";
			newStats.height += Random.Range (0, height);
		} else if (stat_1 == 3) {
			descr_start += "jumps higher";
			newStats.jumpforce += Random.Range (0, jumpforce);
		} else if (stat_1 == 4) {
			descr_start += "has more health";
			newStats.hp += Rand (hp);
		} else if (stat_1 == 5) {
			descr_start += "deals more damage";
			newStats.dmg += Rand (dmg);
		}

		if (stat_2 == 1) {
			descr_end += "is slower";
			newStats.speed += Random.Range (0, speed);
		} else if (stat_2 == 2) {
			descr_end += "is shorter";
			newStats.height += Random.Range (0, height);
		} else if (stat_2 == 3) {
			descr_end += "jumps lower";
			newStats.jumpforce += Random.Range (0, jumpforce);
		} else if (stat_2 == 4) {
			descr_end += "has less health";
			newStats.hp += Rand (hp);
		} else if (stat_2 == 5) {
			descr_end += "deals less damage";
			newStats.dmg += Rand (dmg);
		}
		newStats.description = descr_start + descr_end;
		return newStats;
	}

	int Rand (int n)
	{
		float random = Random.Range(0,n);
		for (int i = 1; i <= n; i++) {
			if (random < i)
			{
				return i;
			}
		}
		return n;
	}
}