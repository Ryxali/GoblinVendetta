using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

	public GameObject player;
	public PlayerState playerState;
	public bool playerShouldRespawn = false;
	public Vector2 catapultPosition;

	public float GetPlayerPos()
	{
		return player.transform.position.x;
	}
}
