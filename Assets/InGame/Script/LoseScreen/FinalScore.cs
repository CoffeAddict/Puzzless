using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public GameObject ScoreObj;
	void Start () {
		gameObject.GetComponent<Text>().text= "Score: " + ScoreObj.GetComponent<Text>().text;
	}
}
