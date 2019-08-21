using UnityEngine;
using System.Collections;

public class destruct : MonoBehaviour {

	void OnCollisionEnter(Collision  col){

		if (col.gameObject.name == "Player(Clone)" || col.gameObject.name == "Joueur 1" || col.gameObject.name == "PERSOMULTI1(Clone)" ) 
		{
			Destroy(gameObject);
		}

		Destroy(gameObject,1.5f);

	}
}
