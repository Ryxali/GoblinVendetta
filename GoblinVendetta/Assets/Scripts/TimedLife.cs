using UnityEngine;
using System.Collections;

public class TimedLife : MonoBehaviour {

	public float lifeTime;
	private float endTime;
	void Awake() {
		endTime = Time.time + lifeTime;
	}
	// Update is called once per frame
	void Update () {
		if(Time.time > endTime) {
			Destroy(gameObject);
		}
	}
}
