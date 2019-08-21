using UnityEngine;
using System.Collections;

public class SpawnMap : MonoBehaviour {

	public GameObject foret;
	public GameObject desert;
	public GameObject plaine;

	public GameObject montagne;
	public int biome;
	public int dim = 7;
	public bool [,] map = new bool[7,7] ;
	public Rigidbody2D coffre;
	public Rigidbody2D echelle;




	// Use this for initialization
	void Awake () {
		// Selection des biomes
		if (PlayerPrefs.HasKey ("Biome"))
		{
			biome = PlayerPrefs.GetInt ("Biome");
		}
		else 
		{
			biome = Random.Range (1, 5);
			PlayerPrefs.SetInt ("Biome" , biome);
		}

		Vector3 nul = new Vector3 (0f, 0f, 00f);



			for (int a =0; a<dim ; a++)
			{
				for (int b=0; b<dim; b++)
				{
					map [a,b] = false;
				}

			}

		if (biome == 1) {
//-------------------------------------------------------------------------------------------------------------------------------------------------
//*******************************************************FORET*************************************************************************************
//-------------------------------------------------------------------------------------------------------------------------------------------------

						int nb = 1;
						GameObject last = Instantiate (foret, new Vector3 (0f, 0f, 10f), Quaternion.identity) as GameObject;

						last.name = last.name + nb.ToString ();
						map [dim / 2, dim / 2] = true;

						int x = dim / 2; // I
						int y = dim / 2; // ->

						// idee: faire un tableau de bolle représentant la map (change nom avec les dim du tab)
						int continu = 0;

						do {
								if (PlayerPrefs.HasKey ("Map" + (nb + 1).ToString ())) {
										continu = PlayerPrefs.GetInt ("Map" + (nb + 1).ToString ());
								} else {
										continu = Random.Range (1, 10);
								}
				
								if (continu < 3) { // haut
										if ((x + 1 < dim) && !map [x + 1, y]) {
												x = x + 1;
												nb = nb + 1;
												GameObject nouv = Instantiate (foret, new Vector3 (last.transform.position.x, last.transform.position.y + 31f, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												map [x, y] = true;
												Destroy (GameObject.Find (last.name + "/1er plan/H"));


												/*int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;

							}
							*/
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						


												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
										} 
			
								} else if (continu < 5) { // Bas
										if ((x - 1 >= 0) && !map [x - 1, y]) {
												x = x - 1;
												map [x, y] = true;
												nb = nb + 1;
												GameObject nouv = Instantiate (foret, new Vector3 (last.transform.position.x, last.transform.position.y - 31f, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/B"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/

												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}




												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
										}

								} else if (continu < 7) { // Droite
										if ((y + 1 < dim) && !map [x, y + 1]) {
												y = y + 1;
												map [x, y] = true;
												nb = nb + 1;
						GameObject nouv = Instantiate (foret, new Vector3 (last.transform.position.x + 41.6f, last.transform.position.y, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/D"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}




												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;

										}


								} else if (continu < 9) { // Gauche
										if ((y - 1 >= 0) && !map [x, y - 1]) {
												y = y - 1;
												map [x, y] = true;
												nb = nb + 1;
						GameObject nouv = Instantiate (foret, new Vector3 (last.transform.position.x - 41.6f, last.transform.position.y, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/G"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/


												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}



												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;

										}

								} else {
										Vector3 random = last.transform.position;
										int neg = 0;
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
										Rigidbody2D instance;
										instance = Instantiate (echelle, random, Quaternion.identity) as Rigidbody2D;
										PlayerPrefs.SetInt ("Map" + (nb + 1).ToString (), continu);
								}


						} while (continu!=9);
			
						// Si il y a dj des PlayerPref
			

				} else if (biome == 2) {
//-------------------------------------------------------------------------------------------------------------------------------------------------
//*******************************************************DESERT*************************************************************************************
//-------------------------------------------------------------------------------------------------------------------------------------------------
		
						int nb = 1;
						GameObject last = Instantiate (desert, new Vector3 (0f, 0f, 10f), Quaternion.identity) as GameObject;
			
						last.name = last.name + nb.ToString ();
						map [dim / 2, dim / 2] = true;
			
						int x = dim / 2; // I
						int y = dim / 2; // ->
			
						// idee: faire un tableau de bolle représentant la map (change nom avec les dim du tab)
						int continu = 0;
			
						do {
								if (PlayerPrefs.HasKey ("Map" + (nb + 1).ToString ())) {
										continu = PlayerPrefs.GetInt ("Map" + (nb + 1).ToString ());
								} else {
										continu = Random.Range (1, 10);
								}
				
								if (continu < 3) { // haut
										if ((x + 1 < dim) && !map [x + 1, y]) {
												x = x + 1;
												nb = nb + 1;
												GameObject nouv = Instantiate (desert, new Vector3 (last.transform.position.x, last.transform.position.y + 31f, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												map [x, y] = true;
												Destroy (GameObject.Find (last.name + "/1er plan/H"));
						
						
												/*int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;

							}
							*/
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
										} 
					
								} else if (continu < 5) { // Bas
										if ((x - 1 >= 0) && !map [x - 1, y]) {
												x = x - 1;
												map [x, y] = true;
												nb = nb + 1;
												GameObject nouv = Instantiate (desert, new Vector3 (last.transform.position.x, last.transform.position.y - 31f, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/B"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
						
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
										}
					
								} else if (continu < 7) { // Droite
										if ((y + 1 < dim) && !map [x, y + 1]) {
												y = y + 1;
												map [x, y] = true;
												nb = nb + 1;
												GameObject nouv = Instantiate (desert, new Vector3 (last.transform.position.x + 41.6f, last.transform.position.y, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/D"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
						
										}
					
					
								} else if (continu < 9) { // Gauche
										if ((y - 1 >= 0) && !map [x, y - 1]) {
												y = y - 1;
												map [x, y] = true;
												nb = nb + 1;
												GameObject nouv = Instantiate (desert, new Vector3 (last.transform.position.x - 41.6f, last.transform.position.y, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/G"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
						
						
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
						
										}
					
								} else {
										Vector3 random = last.transform.position;
										int neg = 0;
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
										Rigidbody2D instance;
										instance = Instantiate (echelle, random, Quaternion.identity) as Rigidbody2D;
										PlayerPrefs.SetInt ("Map" + (nb + 1).ToString (), continu);
								}
				
				
						} while (continu!=9);

			
				} else if (biome == 3) {
			
						//-------------------------------------------------------------------------------------------------------------------------------------------------
						//*******************************************************Plaine*************************************************************************************
						//-------------------------------------------------------------------------------------------------------------------------------------------------
			
						int nb = 1;
						GameObject last = Instantiate (plaine, new Vector3 (0f, 0f, 10f), Quaternion.identity) as GameObject;
			
						last.name = last.name + nb.ToString ();
						map [dim / 2, dim / 2] = true;
			
						int x = dim / 2; // I
						int y = dim / 2; // ->
			
						// idee: faire un tableau de bolle représentant la map (change nom avec les dim du tab)
						int continu = 0;
			
						do {
								if (PlayerPrefs.HasKey ("Map" + (nb + 1).ToString ())) {
										continu = PlayerPrefs.GetInt ("Map" + (nb + 1).ToString ());
								} else {
										continu = Random.Range (1, 10);
								}
				
								if (continu < 3) { // haut
										if ((x + 1 < dim) && !map [x + 1, y]) {
												x = x + 1;
												nb = nb + 1;
												GameObject nouv = Instantiate (plaine, new Vector3 (last.transform.position.x, last.transform.position.y + 31f, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												map [x, y] = true;
												Destroy (GameObject.Find (last.name + "/1er plan/H"));
						
						
												/*int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;

							}
							*/
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
										} 
					
								} else if (continu < 5) { // Bas
										if ((x - 1 >= 0) && !map [x - 1, y]) {
												x = x - 1;
												map [x, y] = true;
												nb = nb + 1;
												GameObject nouv = Instantiate (plaine, new Vector3 (last.transform.position.x, last.transform.position.y - 31f, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/B"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
						
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
										}
					
								} else if (continu < 7) { // Droite
										if ((y + 1 < dim) && !map [x, y + 1]) {
												y = y + 1;
												map [x, y] = true;
												nb = nb + 1;
												GameObject nouv = Instantiate (plaine, new Vector3 (last.transform.position.x + 41.6f, last.transform.position.y, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/D"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
						
										}
					
					
								} else if (continu < 9) { // Gauche
										if ((y - 1 >= 0) && !map [x, y - 1]) {
												y = y - 1;
												map [x, y] = true;
												nb = nb + 1;
												GameObject nouv = Instantiate (plaine, new Vector3 (last.transform.position.x - 41.6f, last.transform.position.y, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/G"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
						
						
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
						
										}
					
								} else {
										Vector3 random = last.transform.position;
										int neg = 0;
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
										Rigidbody2D instance;
										instance = Instantiate (echelle, random, Quaternion.identity) as Rigidbody2D;
										PlayerPrefs.SetInt ("Map" + (nb + 1).ToString (), continu);
								}
				
				
						} while (continu!=9);

				} else if (biome == 4) {
			
						//-------------------------------------------------------------------------------------------------------------------------------------------------
						//*******************************************************Montagne*************************************************************************************
						//-------------------------------------------------------------------------------------------------------------------------------------------------
			
						int nb = 1;
						GameObject last = Instantiate (montagne, new Vector3 (0f, 0f, 10f), Quaternion.identity) as GameObject;
			
						last.name = last.name + nb.ToString ();
						map [dim / 2, dim / 2] = true;
			
						int x = dim / 2; // I
						int y = dim / 2; // ->
			
						// idee: faire un tableau de bolle représentant la map (change nom avec les dim du tab)
						int continu = 0;
			
						do {
								if (PlayerPrefs.HasKey ("Map" + (nb + 1).ToString ())) {
										continu = PlayerPrefs.GetInt ("Map" + (nb + 1).ToString ());
								} else {
										continu = Random.Range (1, 10);
								}
				
								if (continu < 3) { // haut
										if ((x + 1 < dim) && !map [x + 1, y]) {
												x = x + 1;
												nb = nb + 1;
						GameObject nouv = Instantiate (montagne, new Vector3 (last.transform.position.x, last.transform.position.y + 31f, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												map [x, y] = true;
												Destroy (GameObject.Find (last.name + "/1er plan/H"));
						
						
												/*int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;

							}
							*/
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
										} 
					
								} else if (continu < 5) { // Bas
										if ((x - 1 >= 0) && !map [x - 1, y]) {
												x = x - 1;
												map [x, y] = true;
												nb = nb + 1;
						GameObject nouv = Instantiate (montagne, new Vector3 (last.transform.position.x, last.transform.position.y - 31f, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/B"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
						
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
										}
					
								} else if (continu < 7) { // Droite
										if ((y + 1 < dim) && !map [x, y + 1]) {
												y = y + 1;
												map [x, y] = true;
												nb = nb + 1;
						GameObject nouv = Instantiate (montagne, new Vector3 (last.transform.position.x + 41.6f, last.transform.position.y, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/D"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
						
										}
					
					
								} else if (continu < 9) { // Gauche
										if ((y - 1 >= 0) && !map [x, y - 1]) {
												y = y - 1;
												map [x, y] = true;
												nb = nb + 1;
						GameObject nouv = Instantiate (montagne, new Vector3 (last.transform.position.x - 41.6f, last.transform.position.y, last.transform.position.z), Quaternion.identity) as GameObject;
												nouv.name = nouv.name + nb.ToString ();
												Destroy (GameObject.Find (last.name + "/1er plan/G"));
												/*
						int i = Random.Range (2,4);
						int neg = 0;
						while (i>0) {	
							Vector3 random = nouv.transform.position;
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
							Rigidbody2D instance;
							instance = Instantiate (coffre, random, Quaternion.identity) as Rigidbody2D;
							
							i = i - 1;
						}
*/
						
						
												if (x < dim - 1 && map [x + 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/H"));
												}
												if (x > 0 && map [x - 1, y]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/B"));
												}
												if (y > 0 && map [x, y - 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/G"));
												}
												if (y < (dim - 1) && map [x, y + 1]) {
														Destroy (GameObject.Find (nouv.name + "/1er plan/D"));
												}
						
						
						
												PlayerPrefs.SetInt ("Map" + nb.ToString (), continu);
												last = nouv;
						
										}
					
								} else {
										Vector3 random = last.transform.position;
										int neg = 0;
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
										Rigidbody2D instance;
										instance = Instantiate (echelle, random, Quaternion.identity) as Rigidbody2D;
										PlayerPrefs.SetInt ("Map" + (nb + 1).ToString (), continu);
								}
				
				
						} while (continu!=9);

				}



	}
}
