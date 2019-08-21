using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Chat : MonoBehaviour {
	
	public string[] lignechat = new string[4];
	public string texte;


	void OnGUI (){
		GUI.Label (new Rect (0, Screen.height - 100, 1000, 20), lignechat [3]);
		GUI.Label (new Rect (0, Screen.height - 80, 1000, 20), lignechat [2]);
		GUI.Label (new Rect (0, Screen.height - 60, 1000, 20), lignechat [1]);
		GUI.Label (new Rect (0, Screen.height - 40, 1000, 20), lignechat [0]);
		texte = GUI.TextField (new Rect (20, Screen.height - 20, 200, 20), texte);
		if ((GUI.Button (new Rect (225, Screen.height - 20, 100, 20), "Envoyer") && texte.Length != 0) || (Input.GetKeyDown(KeyCode.KeypadEnter) && texte.Length != 0)) {
			GetComponent<NetworkView>().RPC ("Rafraichir",RPCMode.All, texte);
			texte = "";
		}
	}

	[RPC]
	void Rafraichir(string texte1)
	{
		lignechat [3] = lignechat [2];
		lignechat [2] = lignechat [1];
		lignechat [1] = lignechat [0];
		lignechat [0] = texte1;
	}
	
}

