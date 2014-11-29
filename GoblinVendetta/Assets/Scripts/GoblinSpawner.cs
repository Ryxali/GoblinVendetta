using UnityEngine;
using System.Collections;

public class GoblinSpawner : MonoBehaviour {

	public GoblinGenerator goblinGenerator = new GoblinGenerator();

	void Update ()
	{
		if (GlobalVariables.vars.playerShouldRespawn == true) {
			GlobalVariables.vars.playerState.SetStats(goblinGenerator.Generate(GlobalVariables.vars.playerState.GetStats()));
			GlobalVariables.vars.landingPosition = GlobalVariables.vars.player.transform.position;
			GlobalVariables.vars.player.transform.position = GlobalVariables.vars.catapultPosition.position;
			GlobalVariables.vars.player.rigidbody2D.velocity = Vector3.zero;
			GlobalVariables.vars.playerShouldRespawn = false;
			StartCoroutine(GlobalVariables.vars.player.GetComponent<Controller2D>().Fly());
		}
	}
}