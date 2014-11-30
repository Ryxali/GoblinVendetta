using UnityEngine;
using System.Collections;

public class TestMusicManager : MonoBehaviour { 

	public AudioSource PaybackTime;
	public AudioSource DeathTheme;
	public AudioSource HaremOfDread;



	void Start () {
	
		PaybackTime.Play ();
		PaybackTime.loop = true;
		HaremOfDread.loop = true;
		DeathTheme.loop = false;

	}
	
	// Update is called once per frame
	void Update () {


		if(GlobalVariables.vars.MusicDeath == true){
			PaybackTime.Stop();
			DeathTheme.PlayDelayed(0.5f);
			GlobalVariables.vars.MusicDeath = false;
			StartCoroutine(test());
		}

		if(GlobalVariables.vars.BossMusic == true){
			PaybackTime.Stop();
			HaremOfDread.Play();
			GlobalVariables.vars.BossMusic = false;
			StartCoroutine(test2());
		}

	}

	IEnumerator test()
	{


		while (DeathTheme.isPlaying == true)
			yield return null;
		PaybackTime.Play ();
		yield return null;
	}

	IEnumerator test2()
	{
		
		
		while (HaremOfDread.isPlaying == true)
			if(GlobalVariables.vars.BossMusicAlive == false){
			HaremOfDread.Stop();
		
		}
			yield return null;
		PaybackTime.Play ();
		yield return null;
	}
}
