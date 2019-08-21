using UnityEngine;
using System.Collections;

public class FondScript : MonoBehaviour {

	public Sprite herbePlaine;
	public Sprite neige;
	public Sprite sable;
	public Sprite herbeForet;
	public SpriteRenderer fond;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Biome") == 1) {
			fond.sprite = herbeForet;
		}
	
		if (PlayerPrefs.GetInt ("Biome") == 2) {
			fond.sprite = sable;
		}
		if (PlayerPrefs.GetInt ("Biome") == 3) {
			fond.sprite = herbeForet;
		}
		if (PlayerPrefs.GetInt ("Biome") == 4) {
			fond.sprite = neige;
		}
	}
	

}
