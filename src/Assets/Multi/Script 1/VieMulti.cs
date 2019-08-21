using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VieMulti : MonoBehaviour {
	public GameObject healthBar;
	public StatsPlayer player;
	public Color col1;
	public Color colmoy;
	public Color colnul;
	
	// Use this for initialization
	void Start () {

	}


	void Update () {
		float vie = player.Life / 100F;

		if (healthBar != null)
		{
		healthBar.GetComponent<Scrollbar>().size = vie;

		if (player.Life > 50) 
		{
			healthBar.transform.Find ("Mask").Find ("Sprite").GetComponent <Image> ().color = col1;
		} 
		else if (player.Life <= 50 && player.Life >= 25) 
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
