using UnityEngine;
using System.Collections;

public class endMulti : MonoBehaviour {

	public void change ()
	{
		GameObject player = GameObject.Find ("Player(Clone)");
		StatsPlayer vie = player.GetComponent<StatsPlayer> ();
		PlayerPrefs.SetInt ("Life", vie.Life );
		Application.LoadLevel ("2DProj");
	}
}
