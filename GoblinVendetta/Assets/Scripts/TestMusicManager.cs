using UnityEngine;
using System.Collections;

public class TestMusicManager : MonoBehaviour { 

	public AudioSource PaybackTime;
	public AudioSource DeathTheme;
	public AudioSource HaremOfDread;



	void Start () {
	
		PaybackTime.Play ();
		PaybackTime.loop = true;
		DeathTheme.loop = false;
	}
	
	// Update is called once per frame
	void Update () {


		if(GlobalVariables.vars.MusicDeath == true){
			PaybackTime.Stop();
			DeathTheme.Play();
			GlobalVariables.vars.MusicDeath = false;
			StartCoroutine(test());
		}

	}

	IEnumerator test()
	{


		while (DeathTheme.isPlaying == true)
			yield return null;
		PaybackTime.Play ();
		yield return null;
	}
}
