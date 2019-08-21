using UnityEngine;
using System.Collections;

public class IAWufdob : MonoBehaviour {

	public Transform Wufdobpos;

	public GameObject him;
	private int time = 0;
	public Ennemy en;
	// Use this for initialization
	void Start () {

		en.life = 10 * PlayerPrefs.GetInt ("Etage");
	}


	// Update is called once per frame
	void Update () {
		if (time <=0)
		{
			time = 0;
		GameObject playerobject = GameObject.Find ("Player(Clone)");
		Vector3 playerpos= playerobject.transform.position;
		Wufdobpos.LookAt (playerpos);
		}
		Wufdobpos.Translate (Vector3.forward * Time.deltaTime * 7);
		//time = time - 2;

	
	}
	void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.name == "Player(Clone)") {
						Wufdobpos.Translate (Vector3.back * 3);

				} else if (col.gameObject.name == "epee") {
						Wufdobpos.Translate (Vector3.back * 3);
				}

	}

}