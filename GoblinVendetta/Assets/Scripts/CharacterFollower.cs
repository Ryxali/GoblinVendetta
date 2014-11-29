using UnityEngine;
using System.Collections;

public class CharacterFollower : MonoBehaviour {

	public Transform target;
	public float panSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(
			transform.position,
			target.position,
			panSpeed * Vector3.Distance(transform.position, target.position));
	}
}
