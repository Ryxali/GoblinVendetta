using UnityEngine;
using System.Collections;

public class PlayerState : Hitpoints {
	public GoblinStats stats = new GoblinStats(1,1,1,1,1,"lol");

	public void SetStats (GoblinStats s)
	{
		stats = new GoblinStats(s);
	}

	public GoblinStats GetStats ()
	{
		return stats;
	}

	public override void Die() {
		GlobalVariables.vars.playerShouldRespawn = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
