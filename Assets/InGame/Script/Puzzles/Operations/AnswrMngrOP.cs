using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswrMngrOP : MonoBehaviour {
	
	public GameObject PuzzleManager;
	GameObject LevelManager;
	GameObject MainCamera;

	public int OP;
	bool SolvedOnce;

	void Start(){
		LevelManager = GameObject.FindWithTag ("LvlManager"); //Busca al objetos y los asigna a una variable
		MainCamera = GameObject.FindWithTag ("MainCamera");
	}
	public void GetAnswer(){ //Asigna la respuesta al puzzle
		OP = PuzzleManager.GetComponent<PuzzleManagerOP>().OP;
	}

	public void WrongAnswer(){
		Handheld.Vibrate(); //Generacion vibracion generica
		MainCamera.GetComponent<CameraShake> ().Active = true; //Activa el shake de la camara
		LevelManager.GetComponent<LvlMngr> ().lives++; //Agrega un error
		LevelManager.GetComponent<LvlMngr> ().LivesManager(); //chekea las vidas
		LevelManager.GetComponent<LvlMngr>().StreakWrongAction(); //Resetea el streak
	}

	public void CorrectAnswer(){

		if(SolvedOnce == false){
				SolvedOnce = true;
				LevelManager.GetComponent<LvlMngr> ().Solved();
			}
	}
}
