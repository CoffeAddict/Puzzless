using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardActive : MonoBehaviour {
	void Start () {
		StartCoroutine (Disable (gameObject.GetComponent<Animator>().speed+1.5f));
	}

	IEnumerator Disable(float time){ //Desactiva la carta en un tiempo especifico para evitar el touch indeseado
		yield return new WaitForSeconds (time);
		gameObject.GetComponent<Button> ().interactable = true;
	}
}
