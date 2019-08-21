using UnityEngine;
using System.Collections;

public class LevelPvP : MonoBehaviour {
	
	public CameraFollow playerCam;

	public GameObject playerPrefab;
	public GameObject playerPrefab2;
	public SpawnPoint[] spawnPoints;
	private bool voila;
	
	// Use this for initialization
	void Start () {
		voila = false;
		if (Network.isServer) {	
			SpawnPlayer (0);
		}
		else
			Network.Connect (NetworkManagerPvP.GameToJoin);
	}
	
	
	void OnConnectedToServer () {
		SpawnPlayer (1);
	}
	
	private void SpawnPlayer(int joueur){
		int index = 0;
		
		if (NetworkManagerPvP.GameToJoin != null)
			index = NetworkManagerPvP.GameToJoin.connectedPlayers;
		
		Debug.Log (index);
		
		if (joueur == 0 && !voila) {
			var player = Network.Instantiate (playerPrefab, spawnPoints[joueur].transform.position, spawnPoints[index].transform.rotation, joueur) as GameObject;
			player.name = "Joueur 1";
			playerCam.target = player.transform;
			playerCam.enabled = true;
			voila = true;
			
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
