using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

	public GameObject player;

	public float GetPlayerPos()
	{
		return player.transform.position.x;
	}
}
