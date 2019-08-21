using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Intro : MonoBehaviour {

	public GameObject intro;
	public GameObject ecrBlanc;
	public float time=0;
	public GameObject perso;
	public Sprite haut;
	public Sprite bas;
	public Sprite gauche;
	public Sprite droite;


	private bool ecrBI = false;
	private Image blanc;
	private bool ok= false;
	private bool ok2=true;
	private bool ok3=true;
	private bool ok4=false;
	private SpriteRenderer pos;
	private bool ok5 = false;
	private bool ok6=false;
	// Use this for initialization
	void Start()
	{
		Instantiate (ecrBlanc);
		GameObject ecr = GameObject.Find ("Blanc");
		blanc = ecr.GetComponent<Image> ();

		perso = GameObject.Find("Perso(Clone)");
		pos = perso.GetComponent<SpriteRenderer>();
	}
	


	// Update is called once per frame
	void Update () {

		if (ok2) {
						ok = Input.GetButtonDown ("Fire1") || ok;
						
						if (ok) {
								blanc.color = new Color (1f, 1f, 1f, 1f - time * 0.005f);
								if (time <= 200) {
					
										time = time + 1;
					
								} else {
										ok = false;
										time = 0;
										Destroy (GameObject.Find ("Canvas 1(Clone)"));
										Instantiate (intro);

										Text txt = GameObject.Find ("TextI").GetComponent<Text>();
										txt.text = "Uh... Où suis-je?";
										ok2 = false;
										ok4=false;
								}
						}
				}
		ok4 = ok4 || (Input.GetButtonDown ("Fire1") && !ok2 && !ok5) ;
		if (ok4)
		{


			if (ok3)
			{
				Destroy (GameObject.Find ("Intro(Clone)"));
				pos.sprite = gauche;
				ok3=false;
			}

			time = time +1;
			if (time >=50 && time < 100)
			{
				pos.sprite = haut;
			}
			if (time >100 && time <150)
			{
				pos.sprite = droite;
			}

			if (time > 150)
			{
				time = 0;
				Instantiate (intro);
				SpriteRenderer enterpel = GameObject.Find("?!").GetComponent<SpriteRenderer>();
				enterpel.color = new Color (1f,1f,1f, 1f);
				Text txt = GameObject.Find ("TextI").GetComponent<Text>();
				txt.text = "Un coffre?! Allons l'ouvrir!";
				ok5 = true;
				ok4=false;
			}
			
		}
		if (ok5)
		{

			if (Input.GetButtonDown("Fire1"))
			{
				Destroy (GameObject.Find ("Intro(Clone)"));
				PlayerPrefs.SetInt("CanMove",1);
				SpriteRenderer enterpel = GameObject.Find("?!").GetComponent<SpriteRenderer>();
				enterpel.color = new Color (1f,1f,1f, 0f);
			}


		}
		if (PlayerPrefs.GetInt("CheastOpen") ==1 && Input.GetButtonDown("Fire1"))
		{
			PlayerPrefs.DeleteKey("CheastOpen");

			Instantiate (intro);
			ok6=true;
			Text txt = GameObject.Find ("TextI").GetComponent<Text>();
			txt.text = "Une jolie épée... Oh! une échelle... Allons voir où elle nous ammène.";
			PlayerPrefs.SetInt("CanMove",0);
		}
	}
}
