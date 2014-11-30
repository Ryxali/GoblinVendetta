using UnityEngine;
using System.Collections;

public class enableOnTrigger : MonoBehaviour {
	public GameObject obj;

	public GameObject wall;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {

			if(GlobalVariables.vars.BossMusicPlaying == false){

			GlobalVariables.vars.BossMusic = true;
			GlobalVariables.vars.BossMusicAlive = true;
			GlobalVariables.vars.BossMusicPlaying = true;
			}

			obj.SetActive(true);
			wall.SetActive(true);

		}
	}
}
