using UnityEngine;
using System.Collections;

public class DmgEpee : MonoBehaviour {


	public int dmg;

	public void Awake ()
	{
		if (PlayerPrefs.HasKey ("DmgEpee"))
		{
		dmg = PlayerPrefs.GetInt ("DmgEpee");
		}
		else
		{
			dmg = 5;
		}

	}

}
