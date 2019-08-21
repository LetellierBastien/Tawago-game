using UnityEngine;
using System.Collections;

public class LamafaMulti : MonoBehaviour {
	
	public Rigidbody lamaFA;
	public AudioClip uAAAAA;
	public Transform lamafapos;
	private int i;
	private GameObject player;
	private Vector3 playerpos;
	public float time;
	
	// Use this for initialization
	void Start () {
		i = Random.Range (0, 2);
		time=Random.Range(1,150)/100;
	}
	
	// Update is called once per frame
	void Update () {
		if (i == 1) {
			player = GameObject.Find ("Joueur 1");
			playerpos = player.transform.position;
			lamafapos.transform.LookAt (playerpos);
		} else {
			player = GameObject.Find ("PERSOMULTI1(Clone)");
			playerpos = player.transform.position;
			lamafapos.transform.LookAt (playerpos);
		}
		float distance = Vector3.Distance (lamafapos.transform.position, player.transform.position);
		
		if (distance > 5)
		{
			lamafapos.transform.Translate (Vector3.forward * Time.deltaTime * 5);
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
			
			StatsPlayerMulti vie = player.GetComponent<StatsPlayerMulti>();
			vie.Life = vie.Life - dmg;
			time = 5;
			
			GetComponent<AudioSource>().PlayOneShot (uAAAAA);
		}
		
		if (time > 0)
		{
			time = time - Time.deltaTime;
		}
		
	}
}