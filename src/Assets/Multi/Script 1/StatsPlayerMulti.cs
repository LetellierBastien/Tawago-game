using UnityEngine;
using System.Collections;

public class StatsPlayerMulti : MonoBehaviour {

	public int Life; 
	public Transform DeathPoint;
	public Rigidbody player;
	public int time=0;
	private int death = 0;

	//public Camera cam;

	void Awake(){
		//if(networkView.isMine){
		//	cam.enabled = true;
		//}else{
		//	cam.enabled = false;
		//}
	}

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
			Life = 200;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<NetworkView>().isMine) {
			if (Input.GetKeyDown(KeyCode.P))
			{
				Network.Disconnect();
			}
			
		}
		if (GameObject.Find ("WufdogMulti(Clone)") == null && GameObject.Find ("DygoakMulti(Clone)") == null && GameObject.Find ("LamafaMultmi(Clone)") == null && GameObject.Find ("LazawacMulti(Clone)") == null) {
			Life = 200;		
		}
		if (Life <= 0) 
		{
			death += 1;
			player.transform.position = DeathPoint.transform.position;
			Life = 200 - (20 * death);

		}
			

		if (Input.GetMouseButtonDown (0)) {
			time = 100;

		
		}
		time -= 3;
	}

	void OnCollisionEnter(Collision col)
	{
		Ennemy en;
		DmgEpeeMulti ep;
		
		if (col.gameObject.name == "WufdogMulti(Clone)" && time < 50) {
			Life -= Random.Range (3,8);	
			player.transform.Translate (Vector3.back * 4);
		}
		
				
		else if (col.gameObject.name == "bebeMulti(Clone)") {
						Life -= 10;
				}
		else if (col.gameObject.name == "BOULET(Clone)") {
			Life -= 5;
		}
	else if (time > 50 && col.gameObject.name != "Plane_001" && col.gameObject.name != "Plane" ) {
			en=col.gameObject.GetComponent<Ennemy>();
			ep = GetComponentInChildren<DmgEpeeMulti>();
			en.life = en.life - ep.dmg;
		}


	}
}
