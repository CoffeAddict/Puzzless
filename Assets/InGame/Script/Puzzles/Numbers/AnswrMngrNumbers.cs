using UnityEngine;
using UnityEngine.UI;
using System;

public class AnswrMngrNumbers : MonoBehaviour {
	GameObject LevelManager;
	GameObject MainCamera;

	public int[] OrgNumbers = new int[4];
	public int[] DsrNumbers = new int[4];
	public Text[] NumbersObj = new Text[4];

	public int ArrayPos = -1;
	bool check02;
	bool SolvedOnce;

	public RuntimeAnimatorController Bigger;
	void Start () {
		Array.Sort (OrgNumbers); //Ordena las numeros spawneadas
		LevelManager = GameObject.FindWithTag ("LvlManager"); //Busca objetos y los asigna a una variable
		MainCamera = GameObject.FindWithTag ("MainCamera");
	}

    public void NumberAnswerChecker(){
		if (ArrayPos >= 0) { //Si se empezo a tocar numeros

			if (DsrNumbers [ArrayPos] == OrgNumbers[ArrayPos]) {// y es correcta

				CorrectAns ();

			} else { //En caso de respuesta incorrecta

				WrongAns ();
			}
		}

		if (ArrayPos == 3 && check02 == false) { //Si se resolvio el puzzle, avisar al LevelManager 
			check02 = true;

			if(SolvedOnce == false){
				SolvedOnce = true;
				LevelManager.GetComponent<LvlMngr> ().Solved();
			}
		}
	}

	void CorrectAns(){
		NumbersObj [ArrayPos].GetComponent<Animator>().runtimeAnimatorController = Bigger;//Asigna la animacion al into de respuesta
		NumbersObj [ArrayPos].text = (DsrNumbers [ArrayPos]+1).ToString();//Asignar esa numero a las respuestas
	}

	void WrongAns(){
			Handheld.Vibrate(); //Generacion vibracion generica
			MainCamera.GetComponent<CameraShake> ().Active = true; //Activa el shake de la camara
			LevelManager.GetComponent<LvlMngr> ().lives++; //Agrega un error
			LevelManager.GetComponent<LvlMngr> ().LivesManager(); //chekea las vidas
			ArrayPos--; //Y resta una posicion para tener posibilidad de elegir esa numero

			LevelManager.GetComponent<LvlMngr>().StreakWrongAction(); //Resetea el streak
	}
}
