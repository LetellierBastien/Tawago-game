using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Option : MonoBehaviour {

	public GameObject menuOption;




	public void SaveModif () {

		GameObject image = menuOption.transform.Find ("Image").gameObject; 


		GameObject son = image.transform.Find ("Son").gameObject; 
		GameObject sonScroll = son.transform.Find ("BarS").gameObject; 
		Scrollbar sonScr = sonScroll.GetComponent<Scrollbar>();

		GameObject musique = image.transform.Find ("Musique").gameObject; 
		GameObject musiqueScroll = musique.transform.Find ("BarM").gameObject; 
		Scrollbar musiqueScr = musiqueScroll.GetComponent<Scrollbar>();

		GameObject sens = image.transform.Find ("Sensitivite").gameObject; 
		GameObject sensScroll = sens.transform.Find ("BarSe").gameObject; 
		Scrollbar sensScr = sensScroll.GetComponent<Scrollbar>();
		
		PlayerPrefs.SetFloat ("Son", sonScr.value);
		PlayerPrefs.SetFloat ("Musique", musiqueScr.value);
		if (sensScr.value <0.1f)
		{
			sensScr.value = 0.1f;
		}
		PlayerPrefs.SetFloat ("Sens", sensScr.value);

	}
}
