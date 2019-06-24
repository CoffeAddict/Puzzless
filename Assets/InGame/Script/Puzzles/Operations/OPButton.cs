using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPButton : MonoBehaviour {
	int Oper;
	int LocalN1;
	int LocalN2;
	public GameObject AnswerManager;
	public GameObject PuzzleManager;

    public void Onclick(int Number){ //Al hacer click
		if (Input.touchCount == 1) {
			Oper = Number; //Asinga las variables
			LocalN1 = Mathf.RoundToInt(PuzzleManager.GetComponent<PuzzleManagerOP>().N1);
			LocalN2 = Mathf.RoundToInt(PuzzleManager.GetComponent<PuzzleManagerOP>().N2);

			 if(Oper == AnswerManager.GetComponent<AnswrMngrOP>().OP){ //Verifica si es correcta
				CorrectAns();
			}else /*Casos con multiples respuetas*/ if(LocalN1 == 1 || LocalN2 == 1){ 
				if(Oper == 2 || Oper == 3){ //Dividido y multiplicado por 1
					CorrectAns();
				}else{
				WrongAns();
				}
			}else if(LocalN1 == 2 && LocalN2 == 2){ //Sumar 2+2 y 2*2
				if(Oper == 0 || Oper == 2){
					CorrectAns();
				}else{
				WrongAns();
				}
			}else{
				WrongAns();
			}
		}
	}

	void CorrectAns(){
		AnswerManager.GetComponent<AnswrMngrOP>().CorrectAnswer();
	}
	void WrongAns(){
		AnswerManager.GetComponent<AnswrMngrOP>().WrongAnswer();
	}
}
