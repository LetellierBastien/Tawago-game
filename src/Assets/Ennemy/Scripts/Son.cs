using UnityEngine;
using System.Collections;

public class Son : MonoBehaviour {

	public AudioClip son;
	// Use this for initialization
	public void sond () {
		GetComponent<AudioSource>().PlayOneShot (son);
	}

}
