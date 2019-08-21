using UnityEngine;
using System.Collections;

public class Debut : MonoBehaviour {

	public GameObject perso;
	public StatsJoueur2D stats;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("Life"))
		{
			stats.vie = PlayerPrefs.GetInt ("Life");
			stats.maxLife = PlayerPrefs.GetInt ("MaxLife");
		}
		else
		{
			stats.vie = 100;
			stats.maxLife = 100;
		}


		if (PlayerPrefs.HasKey ("DmgEpee"))
		{
			stats.dmgEpee = PlayerPrefs.GetInt ("DmgEpee");
		}
		else
		{
			stats.dmgEpee = 5;
		}




		Vector3 position;
		if (PlayerPrefs.HasKey("x") && PlayerPrefs.HasKey ("y"))
		{
			position = new Vector3 (PlayerPrefs.GetFloat ("x") , PlayerPrefs.GetFloat ("y") , 0) ;
		}
		else 
		{
			position = Vector3.zero;
		}



		if (PlayerPrefs.HasKey ("XP"))
		{
			stats.nivo = PlayerPrefs.GetInt ("Niveau");
			stats.xp = PlayerPrefs.GetInt ("XP");
		}
		else
		{
			stats.nivo = 1;
			stats.xp = 0;
		}


		GameObject p = Instantiate (perso, position , Quaternion.identity) as GameObject;
		if (!PlayerPrefs.HasKey("Etage"))
		{
		PlayerScript ps = p.GetComponent<PlayerScript> ();
		ps.dif = 1;
		}

		if (PlayerPrefs.HasKey ("Etage"))
		{
			stats.etage = PlayerPrefs.GetInt("Etage");
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
