using UnityEngine;
using System.Collections;

public class DmgEpeeMulti : MonoBehaviour {


	public int dmg;

	public void Awake ()
	{
		if (PlayerPrefs.HasKey ("DmgEpeeMulti"))
		{
		dmg = PlayerPrefs.GetInt ("DmgEpeeMulti");
		}
		else
		{
			dmg = 5;
		}

	}

}
