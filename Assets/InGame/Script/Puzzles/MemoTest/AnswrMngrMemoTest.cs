using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswrMngrMemoTest : MonoBehaviour {
	public int FirstCardPressed;
	public int SecondCardPressed;
	public int ThirdCardPressed;

	public bool FirstCardChecker;
	public bool SecondCardChecker;
	public bool ThirdCardChecker;

	public bool Correct;
	public bool Wrong;

	bool check01;
	bool check02;
	int AllSolve;

	GameObject LevelManager;
	GameObject MainCamera;

	bool SolvedOnce;
	void Start(){
		LevelManager = GameObject.FindWithTag ("LvlManager"); //Busca objetos por TAG
		MainCamera = GameObject.FindWithTag ("MainCamera");
	}
	
	void Update () {
		CardAnswerChecker ();
	}

	IEnumerator Cleaner(){ //Resetea variables
		check01 = false;
		ThirdCardPressed = 0;
		SecondCardPressed = 0;
		FirstCardPressed = 0;
		ThirdCardChecker = false;
		SecondCardChecker = false;
		FirstCardChecker = false;
		yield return new WaitForSeconds(0.05f);
		Correct = false;
		Wrong = false;
	}

	public void CardAnswerChecker(){
		
		if (SecondCardChecker == true && check01 == false) { //Si se presionaron por lo menos 2 cartas
			check01 = true;
			if (FirstCardPressed == SecondCardPressed) { // y son iguales
				if (ThirdCardChecker == true) { // y se presiono una tercera

					if (ThirdCardPressed == SecondCardPressed) { //y son iguales, es correcto
						CorrectAns ();
					} else { //Si no, esta mal
						WrongAns ();
					}
				} else {// Si no se presiono, sigue atento
					check01 = false;
				}
			} else { //Si no son iguales, esta mal
				WrongAns();
			}
		}

		if (AllSolve == 3 && check02 == false) { //Si se resolvieron todos, se resolvio el puzzle
			check02 = true;

			if(SolvedOnce == false){
				SolvedOnce = true;
				LevelManager.GetComponent<LvlMngr> ().Solved();
			}
		}
	}

	void CorrectAns(){ //Que hacer si es correcto
		Correct = true;
		AllSolve++;
		StartCoroutine (Cleaner ());
	}

	void WrongAns(){ //Si es incorrecto
		StartCoroutine (Cleaner ());

			Wrong = true;
			Handheld.Vibrate (); //Generacion vibracion generica
			MainCamera.GetComponent<CameraShake> ().Active = true; //Activa el shake de la camara
			LevelManager.GetComponent<LvlMngr> ().lives++;
			LevelManager.GetComponent<LvlMngr> ().LivesManager(); //chekea las vidas

		LevelManager.GetComponent<LvlMngr>().StreakWrongAction(); //Resetea el streak
	}
}

