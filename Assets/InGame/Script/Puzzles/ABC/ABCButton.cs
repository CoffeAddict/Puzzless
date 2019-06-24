using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABCButton : MonoBehaviour {
	GameObject AnsManager;
	public Text letter;
	public int SP = -1;

	void Start(){
		AnsManager = GameObject.FindWithTag("AnswerMan"); //Busca al objetos con un tag
	}
	public void OnClick(){
		if (Input.touchCount == 1)
        {
            AnsManager.GetComponent<AnswrMngrABC>().ArrayPos++;//Aumenta una posicion del array para indicar cual letra se refiere
            AnsManager.GetComponent<AnswrMngrABC>().DsrLetters[AnsManager.GetComponent<AnswrMngrABC>().ArrayPos] = letter.text.ToString(); //Iguala el texto del boton a una variable
            AnsManager.GetComponent<AnswrMngrABC>().ABCAnswerChecker();
            AnswerChecker();
        }
    }

    private void AnswerChecker()
    {
        if (AnsManager.GetComponent<AnswrMngrABC>().ArrayPos >= 0)
        {
			string CorrectLetter = AnsManager.GetComponent<AnswrMngrABC>().OrgLetters[AnsManager.GetComponent<AnswrMngrABC>().ArrayPos].ToString();
			
            if (letter.text.ToString().ToLower() == CorrectLetter)
            { //Si la letra presionada es correcta
                StartCoroutine(SmallerAndDestroy());
            }
        }
    }

    IEnumerator SmallerAndDestroy() //Activa la animacion y luego destruye el objeto
	{	
		GetComponent<Animator> ().SetBool ("Trigger", true);
		yield return new WaitForSeconds(1f);
		Destroy (gameObject);
	}
}
