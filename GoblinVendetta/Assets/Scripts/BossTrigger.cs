using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour {

	bool trigged = false;
	public GameObject[] spawners;
	public GameObject boss;

	void Awake()
	{
		trigged = true;
		foreach(GameObject o in spawners) {
			o.SetActive(false);
		}
		gameObject.SetActive(false);
	}
}
