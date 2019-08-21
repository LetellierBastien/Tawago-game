using UnityEngine;
using System.Collections;

public class Ennemy :MonoBehaviour {

	public int life;
	public GameObject him;


	public Ennemy (int Life , Rigidbody Text)
	{
		life = Life;


	}

	void Update ()
	{
				if (life <= 0) {

						Destroy (him);

				}
		}
}
