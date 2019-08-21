using UnityEngine;
using System.Collections;

public class FPC : MonoBehaviour {

	public GameObject player;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Z))
		{
			player.transform.Translate (Vector3.forward * Time.deltaTime * 10);

		}
		if (Input.GetKey(KeyCode.S))
		{
			player.transform.Translate (Vector3.back * Time.deltaTime * 10);

		}
		if (Input.GetKey(KeyCode.D))
		{
			player.transform.Translate (Vector3.right * Time.deltaTime * 10);
		}
		if (Input.GetKey(KeyCode.Q))
		{
			player.transform.Translate (Vector3.left * Time.deltaTime * 10);
		}
		if (Input.GetKey(KeyCode.J))
		{
			player.transform.Translate (Vector3.up * Time.deltaTime * 5);
		}
		
		
	}
}
