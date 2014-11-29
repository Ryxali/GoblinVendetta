using UnityEngine;
using System.Collections;

public class GoblinSpawner : MonoBehaviour {

	public GlobalVariables globalVariables;
	public GoblinGenerator goblinGenerator;

	void Update ()
	{
		if (globalVariables.playerShouldRespawn == true) {
			globalVariables.playerState.SetStats(goblinGenerator.Generate(globalVariables.playerState.GetStats()));
			globalVariables.landingPosition = globalVariables.player.transform.position;
			globalVariables.player.transform.position = globalVariables.catapultPosition;
			globalVariables.playerShouldRespawn = false;
			StartCoroutine(globalVariables.player.GetComponent<Controller2D>().Fly());
		}
	}
}