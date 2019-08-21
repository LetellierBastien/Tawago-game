using UnityEngine;
using System.Collections;

public class EnnemyMulti :MonoBehaviour {

	public int life;
	public GameObject him;


	void Start (){
	
	}

	public EnnemyMulti (int Life , Rigidbody Text)
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
