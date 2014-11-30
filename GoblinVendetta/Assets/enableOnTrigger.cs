using UnityEngine;
using System.Collections;

public class enableOnTrigger : MonoBehaviour {
	public GameObject obj;
	public GameObject wall;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			obj.SetActive(true);
			wall.SetActive(true);
		}
	}
}
