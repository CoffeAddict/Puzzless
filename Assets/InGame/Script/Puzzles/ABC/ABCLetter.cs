using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ABCLetter : MonoBehaviour {

	/*Related:
	-ABCSpawner.cs
	*/

	public Text LetterText;
	public char Letter;

	void Start () { 
		LetterText.text = Letter.ToString(); //Cambia el texto del boton al indicado por el puzzle
	}

}
