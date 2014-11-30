using UnityEngine;
using System.Collections;

public class enableOnTrigger : MonoBehaviour {
	public GameObject obj;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			obj.SetActive(true);
		}
	}
}
