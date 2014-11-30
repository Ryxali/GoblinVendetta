using UnityEngine;
using System.Collections;

public class MoneyLadyStatus : Hitpoints {

	public GameObject splashEffect;

	public override void Die() {


		GameObject o = (GameObject)Instantiate (splashEffect);
		o.transform.position = transform.position;
		base.Die ();
	}


}
