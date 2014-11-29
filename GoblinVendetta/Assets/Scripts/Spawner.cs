using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float nextSpawn = 0;
	public GameObject spawn;
	public int spawnIntervalMin = 5;
	public int spawnIntervalMax = 10;
	public int spawns = 1;
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
			GameObject o = (GameObject)Instantiate(spawn);
			for(int i = 0; i < spawns; ++i) {
				o.transform.position = transform.position;
			}
		}
	}
}