using UnityEngine;
using System.Collections;

public class Volume : MonoBehaviour {

	public AudioSource audioSource;

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("Son"))
		{
			AudioListener.volume =  PlayerPrefs.GetFloat ("Son");
		}
		else 
		{
			AudioListener.volume =  1.0f;

		}

		if(PlayerPrefs.HasKey ("Musique"))
		{
			audioSource.volume = PlayerPrefs.GetFloat ("Musique");
		}
		else
		{
			audioSource.volume =  1.0f;
		}

	}
}
