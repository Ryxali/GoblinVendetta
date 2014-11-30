using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float nextSpawn = 0;
	public GameObject spawn;
	public int spawnIntervalMin = 5;
	public int spawnIntervalMax = 10;
	public int spawns = 1;
	public GameObject folder;

	public float minDistance = 5;
	public float maxDistance = 7;
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
			float dist = GlobalVariables.vars.player.transform.position.x - transform.position.x;
			if(dist < 0) dist *= -1;
			if(maxDistance > dist && dist > minDistance) {
				for(int i = 0; i < spawns; ++i) {
					GameObject o = (GameObject)Instantiate(spawn);
					o.transform.position = transform.position;
					o.transform.parent = folder.transform;
				}
			}
		}
	}
}