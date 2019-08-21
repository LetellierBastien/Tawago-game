using UnityEngine;
using System.Collections;

public class animMain : MonoBehaviour {

	public int time=0;
	
	Animator anim;
	
	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	
	
	public void Update ()
	{
		
		if (Input.GetMouseButtonDown (0) && time<=0) {
			time = 100;
			anim.SetBool("click" , true);
			
		}
		if (time > 0) {
			time -= 3;
			
			
		}
		else{
			anim.SetBool("click" , false);
		}
	}
}
