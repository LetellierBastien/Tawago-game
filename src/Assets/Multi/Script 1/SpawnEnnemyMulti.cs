using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnEnnemyMulti : MonoBehaviour {

	public Rigidbody Wufdob;
	public Rigidbody Dygoak;
	public Rigidbody Lamafa;
	public Rigidbody Lazawac;
	public Random rand = new Random();
	public int vague;
	public int time;

	//Vector3 randomPosition = origine.position + (Random.insideUnitCircle * 5);
	void Start(){
		time = 300;
		vague = 1;
	}

	// Use this for initialization
	void Update (){
		if (time < 0 && GameObject.Find ("WufdogMulti(Clone)") == null && GameObject.Find ("DygoakMulti(Clone)") == null && GameObject.Find ("LamafaMultmi(Clone)") == null && GameObject.Find ("LazawacMulti(Clone)") == null) {
			time += 300;
			spawnEnnemy(vague+3);
			vague += 1;

		}
		time -= 1;
	}


	public void spawnEnnemy (int nbr) {

		int j = Random.Range (1, 4);
		int i = Random.Range (nbr, nbr + j);
		int neg = 0;
		while (i>0) {	
					
			int choix = Random.Range (1, 5);
					
			if (choix == 1) {
				
				Vector3 random = new Vector3 (0.0F, 0.0F, 0.0F);
				neg = Random.Range (0, 2);
				if (neg == 0) {
					neg = -1;
				}
				random.x = Random.Range (20.0F, 40.0F) * neg;
				random.y = 0F; 	
				neg = Random.Range (0, 2);
				if (neg == 0) {
					neg = -1;
				}
				random.z = Random.Range (20.0F, 40.0F) * neg;
				Spawn (random, Wufdob);
						
						
			} else if (i == 2) {
				Vector3 random2 = new Vector3 (0.0F, 0.0F, 0.0F);
				neg = Random.Range (0, 2);
				if (neg == 0) {
					neg = -1;
				}
				random2.x = Random.Range (20.0F, 40.0F) * neg;
				random2.y = 0F;
				neg = Random.Range (0, 2);
				if (neg == 0) {
					neg = -1;
				}
				random2.z = Random.Range (20.0F, 40.0F) * neg;
				Spawn (random2, Dygoak);
						
			
			} else if (i == 3) {
				Vector3 random2 = new Vector3 (0.0F, 0.0F, 0.0F);
				neg = Random.Range (0, 2);
				if (neg == 0) {
					neg = -1;
				}
				random2.x = Random.Range (20.0F, 40.0F) * neg;
				random2.y = 0F;
				neg = Random.Range (0, 2);
				if (neg == 0) {
					neg = -1;
				}
				random2.z = Random.Range (20.0F, 40.0F) * neg;
				Spawn (random2, Lamafa);
			
		
			} else if (i == 4) {
				Vector3 random2 = new Vector3 (0.0F, 0.0F, 0.0F);
				neg = Random.Range (0, 2);
				if (neg == 0) {
					neg = -1;
				}
				random2.x = Random.Range (20.0F, 40.0F) * neg;
				random2.y = 0F;
				neg = Random.Range (0, 2);
				if (neg == 0) {
					neg = -1;
				}
				random2.z = Random.Range (20.0F, 40.0F) * neg;
				Spawn (random2, Lazawac);
		
			}
			i -= 1;
		}
		nbr += Random.Range (1, 4);
	}






	
	private static void Spawn(Vector3 pos, Rigidbody monstre)
	{
		Rigidbody clone;
		clone = Network.Instantiate(monstre, pos, Quaternion.identity, 0) as Rigidbody;
	}



}
