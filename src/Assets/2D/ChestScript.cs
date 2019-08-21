using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {

	public Rigidbody2D coffre;

	public Transform origine;


	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("NbCoffre"))
		{
			int nb = PlayerPrefs.GetInt ("NbCoffre");
			for (int i =1; i<=nb; i++)
			{
				if (PlayerPrefs.GetInt ("CoffreB" + i.ToString()) == 1)
				{
					Vector3 random = new Vector3 (PlayerPrefs.GetFloat("CoffreX" + i.ToString()), PlayerPrefs.GetFloat("CoffreY" + i.ToString()), 0.0F);
					Rigidbody2D c;
					c = Instantiate (coffre, random, origine.rotation) as Rigidbody2D;
					c.GetComponent<CoffreN>().nb = i;
				}
			}
		}
		else
		{
			bool [,] map = gameObject.GetComponent<SpawnMap>().map;

			int nb=0;
			for (int a =0; a<7; a++)
			{
				for (int b = 0; b <7; b++)
				{
					if (map [a,b])
					{
					int i = Random.Range (2, 4);
					int neg = 0;
					while (i>0) {	
							Vector3 random = new Vector3 (42.5f*(b - 2f), 32f*(a - 2f), 0.0F);
							neg = Random.Range (0, 2);
							if (neg == 0) {
									neg = -1;
							}
							random.x = random.x + (Random.Range (1.0F, 14.0F) * neg);
							random.z = 0F; 	
							neg = Random.Range (0, 2);
							if (neg == 0) {
									neg = -1;
							}
							random.y = random.y + (Random.Range (1.0F, 7.0F) * neg);
							nb += 1;
							Rigidbody2D c;
							c = Instantiate (coffre, random, origine.rotation) as Rigidbody2D;
							c.GetComponent<CoffreN>().nb = nb;
							PlayerPrefs.SetFloat ("CoffreX" + nb.ToString(), random.x);
							PlayerPrefs.SetFloat ("CoffreY" + nb.ToString(), random.y);
							PlayerPrefs.SetInt ("CoffreB" + nb.ToString(), 1);
						
							i = i - 1;
					}
				}
			}
		}

		PlayerPrefs.SetInt ("NbCoffre", nb);
		}
	}

}
