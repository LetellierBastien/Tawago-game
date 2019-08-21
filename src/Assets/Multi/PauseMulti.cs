using UnityEngine;
using System.Collections;

public class PauseMulti : MonoBehaviour {

	public GameObject pose;

	private bool pasPose = true;
	private bool inst = false;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("o")) {
			Application.LoadLevel("Menu");
			Screen.lockCursor = false;
		}

		if (Input.GetKeyDown ("p")) {
			pasPose = !pasPose;
		}

		if (!pasPose)
		{
			if (!inst)
			{
				Instantiate (pose);
				inst = true;
			}
		}
	
	}
}
