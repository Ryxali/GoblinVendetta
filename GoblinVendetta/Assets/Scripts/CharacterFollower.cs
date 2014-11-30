using UnityEngine;
using System.Collections;

public class CharacterFollower : MonoBehaviour {

	public Transform target;
	public float panSpeed;
	public float bottom;
	public float top;
	public bool clip {private get; set;}
	private Vector3 tar = new Vector3();
	// Use this for initialization
	void Start () {
		clip = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tar.x = target.position.x;
		tar.y = target.position.y;
		tar.z = target.position.z;
		if (clip) {
			tar.y = Mathf.Max (tar.y, bottom);
			tar.y = Mathf.Min (tar.y, top);
		}
		transform.position = Vector3.MoveTowards(
			transform.position,
			tar,
			panSpeed * Vector3.Distance(transform.position, target.position));
	}
}
