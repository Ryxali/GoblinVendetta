using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour {
	
	void Awake()
	{

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Screen.showCursor = false;
		Vector3 mPos = GlobalVariables.vars.cam.ScreenToWorldPoint(Input.mousePosition);
		mPos.z = 0;
		transform.position = mPos;
	}
}
