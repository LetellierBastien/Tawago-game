using UnityEngine;
using System.Collections;

public class destructMulti : MonoBehaviour {

	void OnCollisionEnter(Collision  col){

		if (col.gameObject.name == "Joueur 1" || col.gameObject.name == "MAP_Desert_RPG" || col.gameObject.name == "PERSOMULTI1(Clone)") 
		{
			Destroy(gameObject);
		}

		Destroy(gameObject,5);

	}
}
