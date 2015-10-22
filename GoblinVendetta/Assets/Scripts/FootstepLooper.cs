using UnityEngine;
using System.Collections;

	public class FootstepLooper : MonoBehaviour {
	public AudioSource FootstepLoop;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float vX = GlobalVariables.vars.player.GetComponent<Rigidbody2D>().velocity.x;
		if(GlobalVariables.vars.Footsteps == true && (vX < -0.1 || 0.1 < vX) && !FootstepLoop.isPlaying){
			FootstepLoop.Play(); 
		}

		if(GlobalVariables.vars.Footsteps == false || vX == 0){
			FootstepLoop.Stop ();
		}
	}

}