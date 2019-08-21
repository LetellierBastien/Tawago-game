using UnityEngine;
using System.Collections;

public class IAWufdobMulti : MonoBehaviour {

	public Transform Wufdobpos;
	private Vector3 playerpos;
	private int i;

	public GameObject him;


	// Use this for initialization
	void Start () {


		i = Random.Range (1, 3);

	}


	// Update is called once per frame
	void Update () {

			if (i == 1) {
				var playerobject = GameObject.Find ("Joueur 1");
				playerpos = playerobject.transform.position;
				Wufdobpos.LookAt (playerpos);
				Wufdobpos.Translate (Vector3.forward * Time.deltaTime * 7);

			} else {
				var playerobject = GameObject.Find ("PERSOMULTI1(Clone)");
				playerpos = playerobject.transform.position;
				Wufdobpos.LookAt (playerpos);
				Wufdobpos.Translate (Vector3.forward * Time.deltaTime * 7);
			}

	}
	void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.name == "Joueur 1" || col.gameObject.name == "PERSOMULTI1(Clone)") {
						Wufdobpos.Translate (Vector3.back * 3);

				} else if (col.gameObject.name == "epee1") {
						Wufdobpos.Translate (Vector3.back * 3);
				}

	}

}