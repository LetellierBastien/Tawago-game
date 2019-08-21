using UnityEngine;
using System.Collections;

public class IALamaFA : MonoBehaviour {

	public GameObject lamaFA;
	public AudioClip uAAAAA;
	public Ennemy en;
	public float time;

	// Use this for initialization
	void Start () {
		en.life = 20 * PlayerPrefs.GetInt ("Etage");

		time=Random.Range(1,300)/100;
	}
	
	// Update is called once per frame
	void Update () {

		GameObject player = GameObject.Find ("Player(Clone)");
		Vector3 playerpos= player.transform.position;
		lamaFA.transform.LookAt (playerpos);
		float distance = Vector3.Distance (lamaFA.transform.position, player.transform.position);

		if (distance > 5)
		{
		lamaFA.transform.Translate (Vector3.forward * Time.deltaTime * 5);
		}

		if (time <= 0) 
		{
			distance = 100/distance;

			int dmg = (int) distance;

			if (dmg > 20)
			{
				dmg = 20;
			}
			if (dmg <1)
			{
				dmg =1;
			}

			StatsPlayer vie = player.GetComponent<StatsPlayer>();
			vie.Life = vie.Life - dmg*PlayerPrefs.GetInt("Etage");
			time = 5;

			GetComponent<AudioSource>().PlayOneShot (uAAAAA);
		}

		if (time > 0)
		{
			time = time - Time.deltaTime;
		}

	}
}