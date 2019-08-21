using UnityEngine;
using System.Collections;

public class MouseMulti : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape"))
			Screen.lockCursor = false;

		if (Input.GetKey(KeyCode.L))
			Screen.lockCursor = true;
	
	}
}
