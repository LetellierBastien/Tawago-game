using UnityEngine;
using System.Collections;

public class StatPlayerPvP : MonoBehaviour {
	
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
			Life = 100;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Life <= 0) 
		{
			death += 1;
			player.transform.position = DeathPoint.transform.position;
			Life = 100 - (20 * death);
			
		}
		
		
		if (Input.GetMouseButtonDown (0)) {
			time = 100;
			
			
		}
		time -= 3;
	}
	
	void OnCollisionEnter(Collision col)
	{
		StatPlayerPvP2 en;
		DmgEpeeMulti ep;
		

		if (time > 50 && col.gameObject.name != "Plane_001" && col.gameObject.name != "Plane" && !GetComponent<NetworkView>().isMine) {
			en=col.gameObject.GetComponent<StatPlayerPvP2>();
			ep = GetComponentInChildren<DmgEpeeMulti>();
			en.Life = en.Life - ep.dmg;
		}


	}
}
