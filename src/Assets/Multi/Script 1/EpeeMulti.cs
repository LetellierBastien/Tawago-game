using UnityEngine;
using System.Collections;

public class EpeeMulti : MonoBehaviour {

	public AudioClip son;
	public int time=0;
	public StatsPlayerMulti him;

	Animator anim;

	void Start ()
	{
		him = GetComponent<StatsPlayerMulti> ();
		anim = GetComponent<Animator>();
	}


	public void Update ()
	{
	
		if (GetComponent<NetworkView>().isMine) {
			if (Input.GetMouseButtonDown (0) && time <= 0) {
				time = 100;
				GetComponent<AudioSource>().PlayOneShot (son);
				anim.SetBool ("Click", true);
						
			}
			if (time > 0) {
				time -= 3;


			} else {
				anim.SetBool ("Click", false);
			}
		}
	}


}
