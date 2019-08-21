using UnityEngine;
using System.Collections;

public class Act : MonoBehaviour {

	// Update is called once per frame

	public void ChangeScene (string nom) {
		Application.LoadLevel (nom);
	
	}

	public void Begin (string nom) {
		Application.LoadLevel (nom);
		PlayerPrefs.DeleteAll ();
		
	}

	public void Death () {
		if (PlayerPrefs.GetInt("Biome") == 1)
		{
			Application.LoadLevel ("Foret");

		}
		else if (PlayerPrefs.GetInt("Biome") == 2)
		{
			Application.LoadLevel ("TEST2");

		}
		else if (PlayerPrefs.GetInt("Biome") == 3)
		{
			Application.LoadLevel ("Plaine");
			
		}
		else if (PlayerPrefs.GetInt("Biome") == 4)
		{
			Application.LoadLevel ("Montagne");
			
		}
	}

}
