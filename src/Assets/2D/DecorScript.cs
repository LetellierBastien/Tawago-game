using UnityEngine;
using System.Collections;

public class DecorScript : MonoBehaviour {

	public GameObject d1;
	public GameObject d2;

	public GameObject f1;
	public GameObject f2;

	public GameObject p1;
	public GameObject p2;

	public GameObject m1;
	public GameObject m2;

	// Use this for initialization
	void Start () {
		GameObject decor1 = f1;
		GameObject decor2 = f2;
		if (PlayerPrefs.GetInt ("Biome") == 1) {
			 decor1 = f1;
			 decor2 = f2;
		}
		if (PlayerPrefs.GetInt ("Biome") == 2) {
			 decor1 = d1;
			 decor2 = d2;
		}
		if (PlayerPrefs.GetInt ("Biome") == 4) {
			 decor1 = m1;
			 decor2 = m2;
		}
		if (PlayerPrefs.GetInt ("Biome") == 3) {
			 decor1 = p1;
			 decor2 = p2;
		}


		if (PlayerPrefs.HasKey ("NbDec1"))
		{
			int nb = PlayerPrefs.GetInt ("NbDec1");
			for (int i =1; i<=nb; i++)
			{

					Vector3 random = new Vector3 (PlayerPrefs.GetFloat("Decor1X" + i.ToString()), PlayerPrefs.GetFloat("Decor1Y" + i.ToString()), 0.0F);
					
					Instantiate (decor1, random, Quaternion.identity);
					

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
						int i = Random.Range (4, 7);
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

							Instantiate (decor1, random, Quaternion.identity);

							PlayerPrefs.SetFloat ("Decor1X" + nb.ToString(), random.x);
							PlayerPrefs.SetFloat ("Decor1Y" + nb.ToString(), random.y);
							
							i = i - 1;
						}
					}
				}
			}
			
			PlayerPrefs.SetInt ("NbDec1", nb);
		}

		if (PlayerPrefs.HasKey ("NbDec2"))
		{
			int nb = PlayerPrefs.GetInt ("NbDec2");
			for (int i =1; i<=nb; i++)
			{
				
				Vector3 random = new Vector3 (PlayerPrefs.GetFloat("Decor2X" + i.ToString()), PlayerPrefs.GetFloat("Decor2Y" + i.ToString()), 0.0F);

				Instantiate (decor1, random, Quaternion.identity);

				
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
						int i = Random.Range (4, 7);
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
						
							Instantiate (decor2, random, Quaternion.identity);

							PlayerPrefs.SetFloat ("Decor2X" + nb.ToString(), random.x);
							PlayerPrefs.SetFloat ("Decor2Y" + nb.ToString(), random.y);
							
							i = i - 1;
						}
					}
				}
			}
			
			PlayerPrefs.SetInt ("NbDec2", nb);
		}
	
	}


	
	// Update is called once per frame

}
