using UnityEngine;
using System.Collections;

public class enableOnTrigger : MonoBehaviour {
	public GameObject obj;
<<<<<<< HEAD
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			obj.SetActive(true);
=======
	public GameObject wall;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			obj.SetActive(true);
			wall.SetActive(true);
>>>>>>> master
		}
	}
}
