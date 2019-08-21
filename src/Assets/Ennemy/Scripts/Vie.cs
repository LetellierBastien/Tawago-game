using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Vie : MonoBehaviour {
	public GameObject healthBar;
	public StatsPlayer player;
	public Color col1;
	public Color colmoy;
	public Color colnul;
	
	// Use this for initialization
	void Start () {

	}


	void Update () {
		float mL = PlayerPrefs.GetInt ("MaxLife");
		float vie = player.Life / mL;

		if (healthBar != null)
		{
		healthBar.GetComponent<Scrollbar>().size = vie;

		if (player.Life / mL > 0.5f) 
		{
			healthBar.transform.Find ("Mask").Find ("Sprite").GetComponent <Image> ().color = col1;
		} 
		else if (player.Life/mL <= 0.5f && player.Life/mL >= 0.25f) 
		{
			healthBar.transform.Find ("Mask").Find ("Sprite").GetComponent <Image> ().color = colmoy;
		}

		else
		{
			healthBar.transform.Find ("Mask").Find ("Sprite").GetComponent <Image> ().color = colnul;
		}
		}
	}

}
