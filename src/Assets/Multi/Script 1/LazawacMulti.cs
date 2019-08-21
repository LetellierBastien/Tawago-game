using UnityEngine;
using System.Collections;

public class LazawacMulti : MonoBehaviour {
	
	
	public Rigidbody Lazawac;
	public Rigidbody Bullet;
	public Transform position;
	public Transform position2;
	public Transform position3;
	public Transform Lazawacpos;
	private Vector3 playerpos;
	private int repos =0;
	private int i;
	// Use this for initialization
	void Start () {
		i = Random.Range (0, 2);
	}
	
	// Update is called once per frame
	void Update () {
		if (i == 0) {
			var playerobject = GameObject.Find ("Joueur 1");
			//Vector3 playerpos = playerobject.transform.position;
			playerpos = new Vector3 (playerobject.transform.position.x, 0, playerobject.transform.position.z);
			Lazawacpos.LookAt (playerpos);
		} else {
			var playerobject = GameObject.Find ("PERSOMULTI1(Clone)");
			//Vector3 playerpos = playerobject.transform.position;
			playerpos = new Vector3 (playerobject.transform.position.x, 0, playerobject.transform.position.z);
			Lazawacpos.LookAt (playerpos);
		}
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
				projectile.AddForce (0.0F,5.0F,0.0F);
				projectile2.AddForce (position.forward * 4000);
				projectile2.AddForce (0.0F,3.0F,0.0F);
				projectile3.AddForce (position.forward * 5000);
				
				repos = 100;
			}
		}
		else {
			//Dygoakpos.Translate (Vector3.forward * Time.deltaTime );	
			Lazawacpos.Translate (Vector3.forward * Time.deltaTime * 10);	
			
			
			
		}
		repos = repos - 1;
	}
	
	
}
