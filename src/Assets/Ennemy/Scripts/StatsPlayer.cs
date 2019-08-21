using UnityEngine;
using System.Collections;

public class StatsPlayer : MonoBehaviour {

	public int Life; 
	public Transform DeathPoint;
	public Rigidbody player;
	public int time=0;


	public void setLife(int newLife)
	{
		if(newLife < 0)
		{
			Life = 0;}
		else{
		 	Life = newLife;
		}
	}

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("Life"))
		{
			Life = PlayerPrefs.GetInt ("Life");
		}
		else
		{
			Life = 100;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Life <= 0) 
		{
			Screen.lockCursor = false;
			Application.LoadLevel ("Mort");


		}
			

		if (Input.GetMouseButtonDown (0)) {
			time = 100;

		
		}
		time -= 3;
	}

	void OnCollisionEnter(Collision col)
	{
		Ennemy en;
		DmgEpee ep;
		
		if (col.gameObject.name == "Wufdog(Clone)" && time < 50) {
			Life -= 5*PlayerPrefs.GetInt("Etage");	
			player.transform.Translate (Vector3.back * 4);
		}

				
		else if (col.gameObject.name == "bebe 1(Clone)" || col.gameObject.name == "BOULET(Clone)" ) {
						Life -= 7*PlayerPrefs.GetInt("Etage");
				}
		else if (time > 50 && col.gameObject.name != "Plane_001" && col.gameObject.name != "Plane" ) {
			en=col.gameObject.GetComponent<Ennemy>();
			ep = GetComponentInChildren<DmgEpee>();
			en.life = en.life - ep.dmg;
		}


	}
}
