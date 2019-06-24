using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Version : MonoBehaviour {
	public string VersionString;

	void Start () {
		gameObject.GetComponent<Text> ().text = VersionString; //iguala el texto a un string
	}
}
