using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour {

	bool trigged = false;
	public GameObject spawner;
	public GameObject boss;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" && trigged == false)
		{
			trigged = true;
			spawner.SetActive(false);
			boss.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
