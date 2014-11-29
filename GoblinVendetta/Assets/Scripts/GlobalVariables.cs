using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

	public GameObject player;
	public PlayerState playerState;
	public Vector2 catapultPosition;
	public Vector2 landingPosition;
	public bool playerShouldRespawn = false;
	public bool shotIsDone = false;
	public GUIText guitext;

	public float GetPlayerPos()
	{
		return player.transform.position.x;
	}
}
