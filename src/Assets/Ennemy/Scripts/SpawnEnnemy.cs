using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnEnnemy : MonoBehaviour {

	public Rigidbody Wufdob;
	public Rigidbody Dygoak;
	public Rigidbody LamaFA;
	public Rigidbody Lazawak;
	public Transform origine;
	public StatsPlayer player;
	public Random rand = new Random();
	public List<int> enn = new List<int>();

	//Vector3 randomPosition = origine.position + (Random.insideUnitCircle * 5);


	// Use this for initialization
	void Awake () {
		int i = Random.Range (2,5);
		int neg = 0;
		while (i>0)
		{	
			
			int choix = Random.Range (1,5);
			
			if (choix == 1)
			{
				enn.Add(1);
				Vector3 random = new Vector3(0.0F, 0.0F, 0.0F);
				neg = Random.Range (0,2);
				if (neg == 0) 
				{
					neg = -1;
				}
				random.x = Random.Range(20.0F, 30.0F) * neg;
				random.y = 0F; 	
				neg = Random.Range (0,2);
				if (neg == 0) 
				{
					neg = -1;
				}
				random.z = Random.Range(20.0F, 30.0F) * neg;
				Rigidbody instance;
				instance = Instantiate (Dygoak, random, origine.rotation) as Rigidbody;
				
				
			}
			
			else if (choix == 2)
			{
				enn.Add(2);
				Vector3 random2 = new Vector3(0.0F, 0.0F, 0.0F);
				neg = Random.Range (0,2);
				if (neg == 0) 
				{
					neg = -1;
				}
				random2.x = Random.Range(20.0F, 30.0F)*neg ;
				random2.y = 1F;
				neg = Random.Range (0,2);
				if (neg == 0) 
				{
					neg = -1;
				}
				random2.z = Random.Range(20.0F, 30.0F)*neg;
				Rigidbody instance2;
				instance2 = Instantiate (Wufdob, random2, origine.rotation) as Rigidbody;
				
			}
			else if (choix == 3)
			{
				enn.Add(3);
				Vector3 random2 = new Vector3(0.0F, 0.0F, 0.0F);
				neg = Random.Range (0,2);
				if (neg == 0) 
				{
					neg = -1;
				}
				random2.x = Random.Range(20.0F, 30.0F)*neg ;
				random2.y = 0F;
				neg = Random.Range (0,2);
				if (neg == 0) 
				{
					neg = -1;
				}
				random2.z = Random.Range(20.0F, 30.0F)*neg;
				Rigidbody instance2;
				instance2 = Instantiate (LamaFA, random2, origine.rotation) as Rigidbody;
			}
			else if (choix == 4)
			{
				enn.Add(4);
				Vector3 random2 = new Vector3(0.0F, 0.0F, 0.0F);
				neg = Random.Range (0,2);
				if (neg == 0) 
				{
					neg = -1;
				}
				random2.x = Random.Range(20.0F, 30.0F)*neg ;
				random2.y = 0F;
				neg = Random.Range (0,2);
				if (neg == 0) 
				{
					neg = -1;
				}
				random2.z = Random.Range(20.0F, 30.0F)*neg;
				Rigidbody instance2;
				instance2 = Instantiate (Lazawak, random2, origine.rotation) as Rigidbody;
			}
			i = i-1;
		}
	
	}

}
