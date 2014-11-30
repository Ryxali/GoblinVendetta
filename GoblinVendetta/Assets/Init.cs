using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

	public GameObject level;
	public GameObject everything;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			everything.SetActive(true);
			level.SetActive (true);
			gameObject.SetActive(false);
		}

	}
}
