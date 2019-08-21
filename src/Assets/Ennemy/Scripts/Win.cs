using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Win : MonoBehaviour {
	public List<int> enn;
	public GameObject healthBarre;
	public GameObject viseur;
	public GameObject fenetreWin;
	public bool ok = true;

	public void Start () 
	{
		SpawnEnnemy m = GetComponent<SpawnEnnemy>();
		enn = m.enn;
	}

	public void Update () {


		if (GameObject.Find("Wufdog(Clone)")==null && GameObject.Find("Dygoak1(Clone)")==null && GameObject.Find("Lazawac(Clone)")==null && ok && GameObject.Find("Lamafa(Clone)")==null)
		{

			fin ();
			ok = false;
			Screen.lockCursor = false;
		}
	
	}

	public void fin () 
	{
		int xp = 0;
		Destroy (healthBarre);
		Destroy (viseur);
		GameObject currentImage = Instantiate (fenetreWin, Vector3.zero, Quaternion.identity) as GameObject;
		currentImage.transform.parent = transform;

		RectTransform rectTransform = currentImage.GetComponent<RectTransform> ();
		rectTransform.localPosition = new Vector3 (0, 0, 0);


		int nbD=0;
		int nbW = 0;
		int nbLFA = 0;
		int nbLaza = 0;
		foreach (int a in enn) 
		{
			if (a == 1)
			{
				nbD = nbD + 1;
				xp+= 10 * PlayerPrefs.GetInt ("Etage");
			}
			else if (a==2)
			{
				nbW=nbW+1;
				xp+=5* PlayerPrefs.GetInt ("Etage");;
			}
			else if (a==3)
			{
				nbLFA = nbLFA +1;
				xp+=10* PlayerPrefs.GetInt ("Etage");;
			}
			else if (a==4)
			{
				nbLaza = nbLaza +1;
				xp+=20* PlayerPrefs.GetInt ("Etage");;
			}
		}

		GameObject textwin = GameObject.Find ("TextWin");

		Text text =textwin.GetComponent<Text>();
		text.text = "Vous avez battus: \n";

		if (nbD >0 ) 
		{
			text.text = text.text + nbD + " Dygoak \n";
		}

		if (nbW > 0)
		{
			text.text = text.text+ nbW + " Wufdob \n";

		}
		if (nbLFA > 0)
		{
			text.text = text.text+ nbLFA + " LamaFA \n";
			
		}
		if (nbLaza > 0)
		{
			text.text = text.text+ nbLaza + " Lazawac \n";
			
		}

		text.text = text.text+ "Vous avez gané " + xp + "XP \n";
		xp += PlayerPrefs.GetInt ("XP");

		GameObject player = GameObject.Find ("Player(Clone)");
		StatsPlayer stat = player.GetComponent<StatsPlayer> ();


		int i = 0;
		while (xp >= 30 )
		{
			i++;
			xp += -30;
			PlayerPrefs.SetInt("Niveau", PlayerPrefs.GetInt("Niveau") + 1);
			PlayerPrefs.SetInt("MaxLife", PlayerPrefs.GetInt("MaxLife") + 10);
			stat.Life += 10;
			PlayerPrefs.SetInt("DmgEpee", PlayerPrefs.GetInt("DmgEpee") + 5);
		}
		if (i >0)
		text.text += i+ " LVL UP!!";

		PlayerPrefs.SetInt("XP",xp);
		PlayerPrefs.SetInt("Life", stat.Life);
	}

}
