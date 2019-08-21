using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public CameraFollow playerCam;
	private int joueur = 0;
	public GameObject playerPrefab;
	public GameObject playerPrefab2;
	public SpawnPoint[] spawnPoints;


	// Use this for initialization
	void Start () {

		if (Network.isServer) {
		
			SpawnPlayer ();
			joueur += 1;
		}
		else {
			Network.Connect (NetworkManager.GameToJoin);

		}
	}
	

	void OnConnectedToServer () {
		Debug.Log ("Un nouveau joueur s'est connecté !");
		SpawnPlayer ();
	}

	private void SpawnPlayer(){
		int index = 0;

		if (NetworkManager.GameToJoin != null)
			index = NetworkManager.GameToJoin.connectedPlayers;

		Debug.Log (index);

		if (joueur == 0) {
			var player = Network.Instantiate (playerPrefab, spawnPoints[joueur].transform.position, spawnPoints[index].transform.rotation, joueur) as GameObject;
			player.name = "Joueur 1";
			playerCam.target = player.transform;
			playerCam.enabled = true;
		
		} else {
			var player = Network.Instantiate (playerPrefab2, spawnPoints[joueur].transform.position, spawnPoints[index].transform.rotation, joueur) as GameObject;
			player.gameObject.name = "Joueur 2";
			playerCam.target = player.transform;
			playerCam.enabled = true;
		}
		/*
		playerCam.transform.position = spawnPoints.transform.position - new Vector3 (0, 0, 0);
		playerCam.transform.rotation = spawnPoints.transform.rotation;			*/	

	}
}
