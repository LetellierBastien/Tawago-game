using UnityEngine;
using System.Collections;

public class IADygoakMulti : MonoBehaviour {


	public Rigidbody Dygoak;
	public Rigidbody Bullet;
	public Transform position;
	public Transform Dygoakpos;
	private int repos =0;
	private Vector3 playerpos;
	private bool enabled;
	private int i;

	// Use this for initialization
	void Start() {
		i = Random.Range (1, 3);
	}
	
	// Update is called once per frame
	void Update () {	

						
			if (i == 1) {
				var playerobject = GameObject.Find ("Joueur 1");
				//Vector3 playerpos = playerobject.transform.position;
				playerpos = new Vector3 (playerobject.transform.position.x, playerobject.transform.position.y, playerobject.transform.position.z);
				Dygoakpos.LookAt (playerpos);
			} else {
			var playerobject = GameObject.Find ("PERSOMULTI1(Clone)");
				playerpos = new Vector3 (playerobject.transform.position.x, playerobject.transform.position.y, playerobject.transform.position.z);
				Dygoakpos.LookAt (playerpos);
			}
			if (Vector3.Distance (Dygoakpos.position, playerpos) < 15) {
				if (repos <= 0) {
					Rigidbody projectile;
					projectile = Instantiate (Bullet, position.position, position.rotation) as Rigidbody;
					projectile.AddForce (position.forward * 5000);
					repos = 100;
				}
			} else {
				//Dygoakpos.Translate (Vector3.forward * Time.deltaTime );	
				Dygoakpos.Translate (Vector3.up * Time.deltaTime * 6);	


			
			}
			repos = repos - 1;

	}

	public void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Joueur 1" || col.gameObject.name == "PERSOMULTI1(Clone)") {
			Dygoak.AddForce (Vector3.back * 1000);
		}
	}

}
