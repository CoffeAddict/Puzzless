using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {
	void Start () {
		try{
			PlayerPrefs.SetInt ("MaxScore", 0); //Resetea la variable de maxScore
			Debug.Log("var MaxScore cleaned");

		}catch{
			Debug.Log("var MaxScore not cleaned");
		}
		
	}
}

