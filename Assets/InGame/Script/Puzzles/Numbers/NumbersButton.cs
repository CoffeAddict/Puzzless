using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersButton : MonoBehaviour {
	GameObject AnsManager;
	public int SP = -1;

	void Start(){
		AnsManager = GameObject.FindWithTag("AnswerMan"); //Busca al objetos con un tag
	}
	public void OnClick(){
		if (Input.touchCount == 1) { //Si toca la pantalla
			AnsManager.GetComponent<AnswrMngrNumbers> ().ArrayPos++;//Aumenta una posicion del array para indicar cual numero se refiere
			AnsManager.GetComponent<AnswrMngrNumbers> ().DsrNumbers [AnsManager.GetComponent<AnswrMngrNumbers> ().ArrayPos] = gameObject.GetComponent<NumbersNumber>().Number; //Iguala el texto del boton a una variable
			AnsManager.GetComponent<AnswrMngrNumbers> ().NumberAnswerChecker(); //Permite que se verifique si la numero esta bien
			if(AnsManager.GetComponent<AnswrMngrNumbers> ().ArrayPos >= 0){
				if (gameObject.GetComponent<NumbersNumber>().Number == AnsManager.GetComponent<AnswrMngrNumbers> ().OrgNumbers [AnsManager.GetComponent<AnswrMngrNumbers> ().ArrayPos]){ //Si la numero presionada es correcta
					StartCoroutine (SmallerAndDestroy ());
				}
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
