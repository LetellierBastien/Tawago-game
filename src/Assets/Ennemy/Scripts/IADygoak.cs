using UnityEngine;
using System.Collections;

public class IADygoak : MonoBehaviour {


	public Rigidbody Dygoak;
	public Rigidbody Bullet;
	public Transform position;
	public Transform Dygoakpos;
	public Ennemy en;
	private int repos =0;
	// Use this for initialization
	void Start () {
		en.life = 20 * PlayerPrefs.GetInt ("Etage");
	}
	
	// Update is called once per frame
	void Update () {
		GameObject playerobject = GameObject.Find ("Player(Clone)");
		//Vector3 playerpos = playerobject.transform.position;
		Vector3 playerpos = new Vector3 (playerobject.transform.position.x, 0,playerobject.transform.position.z);
		Dygoakpos.LookAt (playerpos);
		if (Vector3.Distance (Dygoakpos.position, playerpos) < 15)
		{
			if (repos <= 0) 
			{
			Rigidbody projectile;
			projectile = Instantiate (Bullet, position.position, position.rotation) as Rigidbody;
			projectile.AddForce (position.forward * 5000);
			repos = 100;
			}
		}
		else {
			//Dygoakpos.Translate (Vector3.forward * Time.deltaTime );	
			Dygoakpos.Translate (Vector3.up * Time.deltaTime * 6);	


			
		}
		repos = repos - 1;
	}

	public void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Player(Clone)") {
		}
	}

}
