using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class PlayerScript : MonoBehaviour {

	public Sprite coffre2;
	public Vector2 speed = new Vector2(10, 10);
	private Vector2 movement;
	public SpriteRenderer sprite;
	public SpriteRenderer epees;
	public AudioClip sonCoffre;
	public AudioClip sonAttack;
	public GameObject self;
	public StatsJoueur2D stat ; 
	public GameObject menuPose;
	public GameObject menuOption;
	public GameObject fenetreObj;
	public GameObject ecranNoir;
	public int dif;

	///Déclaration des Sprite (animation)
	public Sprite haut1;
	public Sprite haut2;
	public Sprite haut0;

	public Sprite droite1;
	public Sprite droite2;
	public Sprite droite0;

	public Sprite bas1;
	public Sprite bas2;
	public Sprite bas0;

	public Sprite gauche1;
	public Sprite gauche2;
	public Sprite gauche0;

	///Fin Déclaration des Sprite (animation)

	private bool ok2=false;
	private GameObject echelle;
	private bool ok=false;
	private int vie;
	private GameObject  coffre;
	private bool nAttack=true;
	private float time;
	private bool pasPose=true; 
	private bool nonInst=true;
	private int precY=-1;
	private int precX;
	private int tmps;
	private int change=1;
	private Vector2 lastMouvement = Vector2.zero;
	private bool pasSort = true;
	private Image enoir = null;
	private bool objFind = false;
	private bool objNInst = true;


	public void Start ()
	{
		stat = GameObject.Find ("Script").GetComponent<StatsJoueur2D> ();
	}


	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.name == "Cheast(Clone)")
		{
			ok = true;
			coffre = coll.gameObject;

		}

		if (coll.gameObject.name == "echelle(Clone)")
		{
			ok2 = true;
			echelle = coll.gameObject;
			
		}

	}




	void OnTriggerExit2D(Collider2D coll) 
	{
		if (coll.gameObject.name == "Cheast(Clone)")
		{
			ok = false;
		}
		if (coll.gameObject.name == "echelle(Clone)")
		{
			ok2 = false;
			echelle = coll.gameObject;
			
		}
		
	}



	// Use this for initialization
	void Update () {
				if (PlayerPrefs.GetInt ("CanMove") == 1) {
						if (!objFind) {
								if (pasPose) {
										if (pasSort) {
												if (nAttack) {

														float inputX = Input.GetAxis ("Horizontal");
														float inputY = Input.GetAxis ("Vertical");

														Screen.lockCursor = false;
														movement = new Vector2 (speed.x * inputX, speed.y * inputY);




														//Animation Gaver Chiante...--------------------------------------------------------------------

														SpriteRenderer im = self.GetComponent<SpriteRenderer> ();
														if (inputX == 0) {
																if (inputY == 0) {
																		if (precY > 0) {
																				im.sprite = haut0;
																		} else if (precY < 0) {
																				im.sprite = bas0;
																		} else if (precX > 0) {
																				im.sprite = droite0;
																		} else if (precX < 0) {
																				im.sprite = gauche0;
																		}
																} else if (inputY < 0) {

																		if (change % 4 == 0) {
																				im.sprite = bas2;
																		} else if (change % 4 == 1) {
																				im.sprite = bas0;
																		} else if (change % 4 == 2) {
																				im.sprite = bas1;
																		} else if (change % 4 == 3) {
																				im.sprite = bas0;
																		}


																		if (precY == inputY) {
																				tmps = tmps - 2;
																				if (tmps < 0) {
																						change = 1 + change;
																						tmps = 15;
																				}
																		} else {
																				change = 0;
																				tmps = 15;
																		}
																		precY = -1;
																		precX = 0;

																} else if (inputY > 0) {
																		if (change % 4 == 0) {
																				im.sprite = haut2;
																		} else if (change % 4 == 1) {
																				im.sprite = haut0;
																		} else if (change % 4 == 2) {
																				im.sprite = haut1;
																		} else if (change % 4 == 3) {
																				im.sprite = haut0;
																		}


																		if (precY == inputY) {
																				tmps = tmps - 2;
																				if (tmps < 0) {
																						change = 1 + change;
																						tmps = 15;
																				}
																		} else {
																				change = 0;
																				tmps = 15;
																		}

																		precY = 1;
																		precX = 0;

																}
														} else if (inputX > 0) {

																if (change % 4 == 0) {
																		im.sprite = droite2;
																} else if (change % 4 == 1) {
																		im.sprite = droite0;
																} else if (change % 4 == 2) {
																		im.sprite = droite1;
																} else if (change % 4 == 3) {
																		im.sprite = droite0;
																}


																if (precX == inputX) {
																		tmps = tmps - 2;
																		if (tmps < 0) {
																				change = 1 + change;
																				tmps = 15;
																		}
																} else {
																		change = 0;
																		tmps = 15;
																}


																precX = 1;
																precY = 0;
														} else if (inputX < 0) {
																if (change % 4 == 0) {
																		im.sprite = gauche2;
																} else if (change % 4 == 1) {
																		im.sprite = gauche0;
																} else if (change % 4 == 2) {
																		im.sprite = gauche1;
																} else if (change % 4 == 3) {
																		im.sprite = gauche0;
																}


																if (precX == inputX) {
																		tmps = tmps - 2;
																		if (tmps < 0) {
																				change = 1 + change;
																				tmps = 15;
																		}
																} else {
																		change = 0;
																		tmps = 15;
																}

																precX = -1;
																precY = 0;
														}

														//Fin Animation Gaver Chiante... ---------------------------------------------------------------------


														if (inputX != 0 || inputY != 0) {
																// mouvement

																if (Random.Range (0, dif) == 1) {
																		// Attaquer
																		AudioSource audios;
																		audios = self.GetComponent<AudioSource> ();
																		audios.clip = sonAttack;
																		audios.PlayOneShot (sonAttack);
																		nAttack = false;
																}

														}

														if (ok) {
																// Ouverture coffre---------------------------------------------------------------------------
																sprite.color = new Color (255f, 255f, 255f, 1f);
																if (Input.GetButtonDown ("Fire1")) {
																		SpriteRenderer text = coffre.GetComponent<SpriteRenderer> ();
																		text.sprite = coffre2;
																		AudioSource audioCoffre = coffre.GetComponent<AudioSource> ();
																		audioCoffre.PlayOneShot (sonCoffre);
																		objFind = true;


																		PlayerPrefs.SetInt ("CoffreB" + coffre.GetComponent<CoffreN> ().nb, 0);
																
																		ok = false;
																		objNInst = true;

																		if (PlayerPrefs.HasKey ("Etage")) {
																				int rnd = Random.Range (1, 7);
																				if (rnd == 1) {
									
																						stat.xp = stat.xp + 5 * PlayerPrefs.GetInt ("Etage");
																						if (stat.xp >= 30 * stat.nivo) {
																								stat.xp = stat.xp - 30 * stat.nivo;
																								stat.nivo = stat.nivo + 1;
																								stat.dmgEpee = stat.dmgEpee + 5;
																								stat.maxLife = stat.maxLife + 10;
																								stat.vie += 10;
																						}
																						PlayerPrefs.SetString ("Objet", ("un livre. \n Tu gagnes " + (5 * PlayerPrefs.GetInt ("Etage") + " xp.")));
																				}
																				if (rnd == 2 || rnd == 6) {
																						int vieRdu = Random.Range (1, 10) * PlayerPrefs.GetInt ("Niveau");
																						stat.vie = stat.vie + vieRdu;
										
																						if (stat.vie > stat.maxLife) {
																								stat.vie = stat.maxLife;
																						}
																						PlayerPrefs.SetString ("Objet", ("une potion rouge. \n Elle te soigne de " + vieRdu + " PV."));

																				}
																				if (rnd == 3) {
																						int vieRdu = Random.Range (1, 10) * PlayerPrefs.GetInt ("Niveau");
																						stat.vie = stat.vie - vieRdu;
											
																						if (stat.vie < 0) {
																								stat.vie = 1;
																						}
																						PlayerPrefs.SetString ("Objet", ("une potion noir. \n Elle t'inflige " + vieRdu + " dégat."));
											
																				}
										if (rnd == 4) {
											dif = dif /2;
											PlayerPrefs.SetString ("Objet", ("une potion rose. \n Elle attire les monstres!"));
											
										}
										if (rnd == 5) {
											stat.dmgEpee = stat.dmgEpee + (1*PlayerPrefs.GetInt("Niveau"));
											PlayerPrefs.SetString ("Objet", ("une pierre à affuter. \n Ton épée gagne "+  1*PlayerPrefs.GetInt("Etage") +" dégat!"));
											
										}
																		} else {
																				PlayerPrefs.SetString ("Objet", "une épée.");
																				PlayerPrefs.SetInt ("CheastOpen", 1);
																	
																		}



																}
														} else if (ok2) {
																sprite.color = new Color (255f, 255f, 255f, 1f);
																if (Input.GetButtonDown ("Fire2")) {

																		pasSort = false;
																}
														} else {
																sprite.color = new Color (255f, 255f, 255f, 0f);
			
														}

												} else { // attaque -------------------------------------------------------------
														movement = Vector2.zero;
														time = time + Time.deltaTime;
														epees.color = new Color (255f, 255f, 255f, time);


														if (time > 2) {
																//load level baston
																PlayerPrefs.SetFloat ("x", gameObject.transform.position.x);
																PlayerPrefs.SetFloat ("y", gameObject.transform.position.y);


																stat = GameObject.Find ("Script").GetComponent<StatsJoueur2D> ();
																PlayerPrefs.SetInt ("XP", stat.xp); 
																PlayerPrefs.SetInt ("Life", stat.vie); 
																PlayerPrefs.SetInt ("MaxLife", stat.maxLife); 
																PlayerPrefs.SetInt ("Niveau", stat.nivo); 
																PlayerPrefs.SetInt ("DmgEpee", stat.dmgEpee); 

																if (PlayerPrefs.HasKey ("Biome")) {
																		if (PlayerPrefs.GetInt ("Biome") == 2) {
																				Application.LoadLevel ("TEST2");
																		} else if (PlayerPrefs.GetInt ("Biome") == 1) {
																				Application.LoadLevel ("Foret");

																		}
											else if (PlayerPrefs.GetInt ("Biome") == 3) {
												Application.LoadLevel ("Plaine");
												
											}
									else if (PlayerPrefs.GetInt ("Biome") == 4) {
										Application.LoadLevel ("Montagne");
										
									}
											} else {
																		Application.LoadLevel ("2DProj");
																}

														}

												}
												// Menu Pause
												if (Input.GetKeyDown ("p")) {
														pasPose = false;
												}
										} else {
												// Prise de l'echelle--------------------------------------------------------------
										

												if (time == 0) {
														GameObject ecrNoir = Instantiate (ecranNoir) as GameObject;
					
														enoir = ecrNoir.transform.Find ("Noir").GetComponent<Image> ();
														bool b = true;
														int nb = 1;
														while (b) {
																b = false;

																if (PlayerPrefs.HasKey ("Map" + (nb + 1).ToString ())) {
																		PlayerPrefs.DeleteKey ("Map" + (nb + 1).ToString ());
																		b = true;
																}
																nb = nb + 1;
														
														}
														PlayerPrefs.DeleteKey ("Biome");
														for (int c = 1; c<PlayerPrefs.GetInt("NbCoffre"); c++) {
																PlayerPrefs.DeleteKey ("CoffreX" + c.ToString ());
																PlayerPrefs.DeleteKey ("CoffreY" + c.ToString ());
																PlayerPrefs.DeleteKey ("CoffreB" + c.ToString ());
														}

														for (int c = 1; c<PlayerPrefs.GetInt("NbDec2"); c++) {
															PlayerPrefs.DeleteKey ("Decor2X" + c.ToString ());
															PlayerPrefs.DeleteKey ("Decor2Y" + c.ToString ());
															
														}
														for (int c = 1; c<PlayerPrefs.GetInt("NbDec1"); c++) {
															PlayerPrefs.DeleteKey ("Decor1X" + c.ToString ());
															PlayerPrefs.DeleteKey ("Decor1Y" + c.ToString ());
															
														}
														PlayerPrefs.DeleteKey ("NbDec1");
														PlayerPrefs.DeleteKey ("NbDec2");
														PlayerPrefs.DeleteKey ("NbCoffre");
														if (PlayerPrefs.HasKey ("x")) {
																PlayerPrefs.DeleteKey ("x");
																PlayerPrefs.DeleteKey ("y");
														}
														PlayerPrefs.DeleteKey ("EchelleX");
														PlayerPrefs.DeleteKey ("EchelleY");
														PlayerPrefs.SetInt ("XP", stat.xp); 
														PlayerPrefs.SetInt ("Life", stat.vie); 
														PlayerPrefs.SetInt ("MaxLife", stat.maxLife); 
														PlayerPrefs.SetInt ("Niveau", stat.nivo); 
														PlayerPrefs.SetInt ("DmgEpee", stat.dmgEpee); 
						
														movement = Vector2.zero;
						
														if (PlayerPrefs.HasKey ("Etage")) {
																PlayerPrefs.SetInt ("Etage", PlayerPrefs.GetInt ("Etage") + 1);
							
														} else {
																PlayerPrefs.SetInt ("Etage", 1);
														}
										
												}

												time = time + Time.deltaTime;

												enoir.color = new Color (0f, 0f, 0f, time * 1.2f);
				
				
												if (time > 1) {
														Application.LoadLevel ("2DProj");
												}
										}
								} else {
										movement = Vector2.zero;
										if (nonInst) {
												nonInst = false;
												Instantiate (menuPose);
										}
								}
						} else {
								if (objNInst) {
										Instantiate (fenetreObj);

										GameObject textCont = GameObject.Find ("ObjetText");
										Text text = textCont.GetComponent<Text> ();
										text.text = text.text + PlayerPrefs.GetString ("Objet");
										movement = Vector2.zero;
										objNInst = false;
										time = 0;
								}

								time = time + Time.deltaTime;
								if (Input.GetButtonDown ("Fire1") && time > 0.5f) {
										objFind = false;
										Destroy (GameObject.Find ("obj(Clone)"));
										Destroy (coffre);
										time = 0;
								}
					
						}
				}
		}



	// Update is called once per frame
	void FixedUpdate () {

		self.transform.Translate (movement);


	}



	#region Menu pose

	// Menu pause
	public void Resume ()
	{
		GameObject blbl =GameObject.Find("Canvas(Clone)");
		Destroy (blbl);
		blbl = GameObject.Find("Perso(Clone)");
		PlayerScript blblbl = blbl.GetComponent<PlayerScript> ();
		blblbl.pasPose = true;
		blblbl.nonInst = true;
	}

	public void Reset ()
	{
		GameObject blbl =GameObject.Find("Script");
		StatsJoueur2D blblbl = blbl.GetComponent <StatsJoueur2D> ();
		blblbl.vie = 100;
		blblbl.dmgEpee = 5;
		PlayerPrefs.DeleteAll();
	}

	public void Menu () 
	{
		Application.LoadLevel ("Menu");
	}

	public void Option ()
	{
		GameObject blbl =GameObject.Find("Canvas(Clone)");
		Destroy (blbl);
		GameObject image = menuOption.transform.Find ("Image").gameObject; 


		GameObject son = image.transform.Find ("Son").gameObject; 
		GameObject sonScroll = son.transform.Find ("BarS").gameObject; 
		Scrollbar sonScr = sonScroll.GetComponent<Scrollbar>();
		sonScr.value = 1.0f;
		if (PlayerPrefs.HasKey ("Son"))
		{
			sonScr.value = PlayerPrefs.GetFloat ("Son");
		}

		GameObject musique = image.transform.Find ("Musique").gameObject; 
		GameObject musiqueScroll = musique.transform.Find ("BarM").gameObject; 
		Scrollbar musiqueScr = musiqueScroll.GetComponent<Scrollbar>();
		musiqueScr.value = 1.0f;
		if (PlayerPrefs.HasKey ("Musique"))
		{
			musiqueScr.value = PlayerPrefs.GetFloat ("Musique");
		}


		GameObject sens = image.transform.Find ("Sensitivite").gameObject; 
		GameObject sensScroll = sens.transform.Find ("BarSe").gameObject; 
		Scrollbar sensScr = sensScroll.GetComponent<Scrollbar>();
		sensScr.value = 1.0f;
		if (PlayerPrefs.HasKey ("Sens"))
		{
			sensScr.value = PlayerPrefs.GetFloat ("Sens");

		}

		Instantiate (menuOption);


	}

	public void Retour ()
	{
		GameObject blbl =GameObject.Find("Option(Clone)");
		Destroy (blbl);
		blbl = GameObject.Find("Perso(Clone)");
		PlayerScript blblbl = blbl.GetComponent<PlayerScript> ();
		blblbl.nonInst = true;
	}

	#endregion

}

