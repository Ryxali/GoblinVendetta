using UnityEngine;
using System.Collections;

public class GoblinGenerator {
	//The max difference in stat increases/decreases and the max and min values
	public float speed = 2, speedMax = 14, speedMin = 6, height = 0.2f, heightMax = 1.4f, heightMin = 0.8f, jumpforce = 2, jumpforceMax = 14, jumpforceMin = 6;
	public int hp = 2, hpMax = 8, hpMin = 2, dmg = 2, dmgMax = 7, dmgMin = 3;

	public GoblinStats Generate (GoblinStats stats)
	{
		GoblinStats newStats = new GoblinStats(stats);
		int stat = Random.Range (1, 11);

		string descr = "";

		if (stat == 1) {
			if (Random.Range(0, 2) == 0)
				descr += "Never accomplishing much this goblin was always pushed around by his mother until last week when he finally became";
			else
				descr += "Growing up as an orphan survived by pickpocketing gelatinous cubes. These days he makes a living as";
			newStats.speed += Random.Range (0.0f, speed);
			if (newStats.speed > speedMax)
				newStats.speed = speedMax;
		} else if (stat == 2) {
			if (Random.Range(0, 2) == 0)
				descr += "Born in under a bridge this goblin always thought he was destined for greater things like a troll or something, instead he became";
			else
				descr += "Being so big this goblin is almost always hungry, his father is rumored to be an orc. As a child he would always steal food from the other younglings. He got punished by his village elder by being put to work as";
			newStats.height += Random.Range (0.0f, height);
			if (newStats.height > heightMax)
				newStats.height = heightMax;
		} else if (stat == 3) {
			descr += "Being ugly even for goblin standards, this monstrosity had to spend his whole life dodging dodging his fathers broomstick for being in his field of vision. Now however he works as";
			newStats.jumpforce += Random.Range (0.0f, jumpforce);
			if (newStats.jumpforce > jumpforceMax)
				newStats.jumpforce = jumpforceMax;
		} else if (stat == 4) {
			descr += "Goblins are good at taking punishment. This goblin in particular. That didn’t benefit him much however when working as";
			newStats.hp += Random.Range(1, hp + 1);
			if (newStats.hp > hpMax)
				newStats.hp = hpMax;
		} else if (stat == 5) {
			descr += "No goblins are fond of other races, or even goblins for that matter. But this one in particular has a vendetta against everything, he hates the world with a passion. And he has anger management issues, which is the reason he got fired from working as";
			newStats.dmg += Random.Range(1, dmg + 1);
			if (newStats.dmg > dmgMax)
				newStats.dmg = dmgMax;
		}

		else if (stat == 6) {
			descr += "This goblin only recently learned how to tie his own shoes, but at least he got lucky because he gets to work as";
			newStats.speed -= Random.Range (0.0f, speed);
			if (newStats.speed < speedMin)
				newStats.speed = speedMin;
		} else if (stat == 7) {
			descr += "The smallest out of 67 siblings this goblin did not have an easy childhood. Later he grew up to be";
			newStats.height -= Random.Range (0.0f, height);
			if (newStats.height < heightMin)
				newStats.height = heightMin;
		} else if (stat == 8) {
			descr += "As a baby goblin he was used as a football by some peasant kids. He broke a lot of bones that didn’t heal properly afterwards so he never managed to achieve anything greater than";
			newStats.jumpforce -= Random.Range (0.0f, jumpforce);
			if (newStats.jumpforce < jumpforceMin)
				newStats.jumpforce = jumpforceMin;
		} else if (stat == 9) {
			descr += "An old war veteran from the 100 year massacre of goblins this goblin has become both frail and hard of hearing. He hoped to be able to live out his last days as";
			newStats.hp -= Random.Range (1, hp + 1);
			if (newStats.hp < hpMin)
				newStats.hp = hpMin;
		} else {
			descr += "There are those who are at the pinnacle of innovation and creativity, always trying out the latest type of bludgeon or shiv, and then there’s this goblin who prefers to stick to the old ways. He used to work as";
			newStats.dmg -= Random.Range(1, dmg + 1);
			if (newStats.dmg < dmgMin)
				newStats.dmg = dmgMin;
		}

		stat = Random.Range (1, 6);

		if (stat == 1)
			descr += " a fairy dust scrubber at the local night club.";
		else if (stat == 2)
			descr += " an ogre club protection helmet tester.";
		else if (stat == 3)
			descr += " a test subject for the royal apothecary society after testing was deemed to inhumane to be used on sewer rats.";
		else if (stat == 4)
			descr += " a janitor at the swamp troll tuberculosis and plague ward.";
		else
			descr += " a food sampler for a group of rock eating giants. And no, goblins can not digest rocks.";

		descr += " Recently he got picked up by a swarm of ravenous goblins with a magic pendant. This is his last chance at a better life, lets hope he doesn’t waste it.";
		newStats.description = descr;
		return newStats;
	}
}