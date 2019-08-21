using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform _transform;
	private Quaternion _rotation;
	public Transform target;
	public Transform camlook;
	public Vector3 offset = new Vector3(0, -5, 10);
	public float damping = 5;


	void Awake()
	{
		enabled = false;

	}
	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void LateUpdate () {
			
			_rotation = new Quaternion (target.rotation.w,target.rotation.x, target.rotation.y, target.rotation.z);
			//_rotation = Quaternion.Euler (camlook.transform.eulerAngles.x, camlook.transform.eulerAngles.y, camlook.transform.eulerAngles.z);
			_transform.position = new Vector3 (target.transform.position.x, target.transform.position.y + 2, target.transform.position.z);
			//_transform.position = Vector3.Lerp(_transform.position, target.transform.position - (_rotation * offset), Time.deltaTime * damping);
			//_transform.LookAt (camlook.transform);

	}
}
