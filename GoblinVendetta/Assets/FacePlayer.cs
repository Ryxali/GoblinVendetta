using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

	private Vector3 v = Vector3.one;
	// Update is called once per frame
	void Update () {
		v = Vector3.one;
		int f = 1;
		if (transform.position.x > GlobalVariables.vars.player.transform.position.x) {
			f = -1;
		}
		v.x *= f;
		transform.localScale = v;
	}
}
