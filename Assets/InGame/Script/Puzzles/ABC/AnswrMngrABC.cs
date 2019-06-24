using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class AnswrMngrABC : MonoBehaviour {

	GameObject LevelManager;
	GameObject MainCamera;

	public char[] OrgLetters = new char[4];
	public string[] DsrLetters = new string[4];
	public Text[] LettersObj = new Text[4];
	public int ArrayPos = -1;
	bool check02;
	public RuntimeAnimatorController Bigger;

	bool SolvedOnce;

	void Start(){
		Array.Sort (OrgLetters); //Ordena las letras spawneadas
		LevelManager = GameObject.FindWithTag ("LvlManager"); //Busca al LevelManager y lo asigna a una variable
		MainCamera = GameObject.FindWithTag ("MainCamera");
	}

	public void ABCAnswerChecker(){
		if (ArrayPos >= 0 && DsrLetters[ArrayPos] != "") { //Si se empezo a tocar letras
			if (DsrLetters [ArrayPos].ToLower() == OrgLetters[ArrayPos].ToString()) {// y es correcta

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
		LettersObj [ArrayPos].GetComponent<Animator>().runtimeAnimatorController = Bigger;//Asigna la animacion al texto de respuesta
		LettersObj [ArrayPos].text = DsrLetters [ArrayPos];//Asignar esa letra a las respuestas
	}

	void WrongAns(){
			Handheld.Vibrate(); //Generacion vibracion generica
			MainCamera.GetComponent<CameraShake> ().Active = true; //Activa el shake de la camara
			LevelManager.GetComponent<LvlMngr> ().lives++; //Agrega un error
			LevelManager.GetComponent<LvlMngr> ().LivesManager(); //chekea las vidas
			ArrayPos--; //Y resta una posicion para tener posibilidad de elegir esa letra

			LevelManager.GetComponent<LvlMngr>().StreakWrongAction(); //Resetea el streak
	}
}
