using UnityEngine;
using System.Collections;

public class IALazawac : MonoBehaviour {

	
	public Rigidbody Lazawac;
	public Rigidbody Bullet;
	public Transform position;
	public Transform position2;
	public Transform position3;
	public Transform Lazawacpos;
	private int repos =0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var playerobject = GameObject.Find ("Player(Clone)");
		//Vector3 playerpos = playerobject.transform.position;
		Vector3 playerpos = new Vector3 (playerobject.transform.position.x, 0,playerobject.transform.position.z);
		Lazawacpos.LookAt (playerpos);
		if (Vector3.Distance (Lazawacpos.position, playerpos) < 25)
		{
			if (repos <= 0) 
			{
				Rigidbody projectile;
				Rigidbody projectile2;
				Rigidbody projectile3;
				projectile = Instantiate (Bullet, position.position, position.rotation) as Rigidbody;
				projectile2 = Instantiate (Bullet, position2.position, position2.rotation) as Rigidbody;
				projectile3 = Instantiate (Bullet, position3.position, position3.rotation) as Rigidbody;
				projectile.AddForce (position.forward * 3000);
				projectile2.AddForce (position.forward * 4000);
				projectile3.AddForce (position.forward * 5000);

				repos = 200;
			}
		}
		else {
			//Dygoakpos.Translate (Vector3.forward * Time.deltaTime );	
			Lazawacpos.Translate (Vector3.forward * Time.deltaTime * 10);	
			
			
			
		}
		repos = repos - 1;
	}
	

}
