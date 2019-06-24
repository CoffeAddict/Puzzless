using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public int score;
	Text text;

	public void Start(){
		text = GetComponent<Text> (); //Obtiene el componente de texto
	}

    public void RenewText()
    {
        text.text = score.ToString();//Iguala el texto a una varible
    }
}
