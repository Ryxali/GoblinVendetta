using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour {
	public static GlobalVariables vars { get; private set; }
	public GameObject player;
	public PlayerState playerState;
	public Transform catapultPosition;
	public float flyHeight = 10;
	public Vector2 landingPosition;
	public bool playerShouldRespawn = false;
	public bool shotIsDone = false;
	public Text guitext;
	public bool MusicDeath = false;
	public bool BossMusic = false;
	public bool BossMusicAlive = false;
	public CharacterFollower camFollower;
	public GameObject spawnFolder;
	public Camera cam;
	public bool Footsteps = false;

	public float GetPlayerPos()
	{
		return player.transform.position.x;
	}

	void Awake() {
		vars = this;
	}
}
