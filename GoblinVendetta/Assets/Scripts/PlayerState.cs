using UnityEngine;
using System.Collections;

public class PlayerState : Hitpoints {
	public GoblinStats stats;

	public void SetStats (GoblinStats s)
	{
		stats = new GoblinStats(s);
	}

	public GoblinStats GetStats ()
	{
		return stats;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
