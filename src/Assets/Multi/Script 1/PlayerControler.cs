using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {
		
	private Transform _transform;
	private Vector3 _translation;
	//private Vector3 _rotation;
	private float _velocity = 0.95f;
	private NetworkView _ntView;
	public float moveSpeed = 15.0f;
	public float rotationSpeed = 65.0f;
	public string levelToLoad;

	void Awake() {
		if (!GetComponent<NetworkView>().isMine)
			enabled = false;
		else
			enabled = true;

	}
	// Use this for initialization
	void Start () {

		Screen.lockCursor = true;;
		_transform = GetComponent<Transform> ();
		_ntView = GetComponent<NetworkView> ();

	}

	// Update is called once per frame
	void Update () {
		if (enabled) {
			_translation.z = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
			
			if(Input.GetKey (KeyCode.Q))
				_translation.x = -moveSpeed * Time.deltaTime;
			else if (Input.GetKey(KeyCode.D))
				_translation.x = moveSpeed * Time.deltaTime;

			else if (Input.GetKey(KeyCode.P))
				{
					Network.Disconnect();
					Application.LoadLevel(levelToLoad);
				}
				

			
			//_rotation.y = Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
			
			_transform.Translate (_translation);
			//_transform.Rotate(_rotation);
			
			_translation.x *= _velocity;
			_translation.z *= _velocity;
			//_rotation.y *= _velocity;
		}


	}
}
