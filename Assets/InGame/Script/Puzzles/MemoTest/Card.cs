using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	public int CardNumber;

	float SpeedEasy = 0.75f;
	float SpeedMedium = 1f;
	float SpeedHard = 1.5f;

	GameObject AnsManager;
	GameObject PuzzleGen;
	bool checkCorrect;
	bool checkWrong;

	void Awake(){
		AnsManager = GameObject.FindWithTag("AnswerMan"); //Busca objetos por tag
		PuzzleGen = GameObject.FindWithTag("PuzzleGen");
	}

	void Start(){
		CardNumber = GetComponent<Animator> ().GetInteger ("CardNum"); //Asigna el numero de carta a una varible
		GetComponent<Animator> ().speed = SpeedEasy;
		switch (PuzzleGen.GetComponent<PuzzleGen> ().difficulty) { //Cambia la velocidad de animacion
		case 0:
			GetComponent<Animator> ().speed = SpeedEasy;
			break;
		case 1:
			GetComponent<Animator> ().speed = SpeedMedium;
			break;
		case 2:
			GetComponent<Animator> ().speed = SpeedHard;
			break;
		}
	}

	 public void OnClick(){
		if (Input.touchCount == 1) {
			
			gameObject.GetComponent<Button> ().interactable = false; //Al tocarla, no se puede volver a tocarla en la misma jugada

			if (AnsManager.GetComponent<AnswrMngrMemoTest> ().FirstCardChecker == false) { //Si es la primera carta
				AnsManager.GetComponent<AnswrMngrMemoTest> ().FirstCardPressed = CardNumber;
				AnsManager.GetComponent<AnswrMngrMemoTest> ().FirstCardChecker = true;
				GetComponent<Animator> ().SetBool ("Click", true); //Activa animacion de click

			} else if (AnsManager.GetComponent<AnswrMngrMemoTest> ().SecondCardChecker == false) { //Si es la segunda
				AnsManager.GetComponent<AnswrMngrMemoTest> ().SecondCardPressed = CardNumber;
				AnsManager.GetComponent<AnswrMngrMemoTest> ().SecondCardChecker = true;
				GetComponent<Animator> ().SetBool ("Click", true);
			} else if (AnsManager.GetComponent<AnswrMngrMemoTest> ().ThirdCardChecker == false) { //Si es la tercera
				AnsManager.GetComponent<AnswrMngrMemoTest> ().ThirdCardPressed = CardNumber;
				AnsManager.GetComponent<AnswrMngrMemoTest> ().ThirdCardChecker = true;
				GetComponent<Animator> ().SetBool ("Click", true);
			}
			
		}
	}

	void Update()
    {
        AnimStatesChecker();
	}

    public void AnimStatesChecker()
    {
        if (GetComponent<Animator>().GetBool("Click") == true && checkCorrect == false && AnsManager.GetComponent<AnswrMngrMemoTest>().Correct == true)
        { //Si el state de animacion es click y la jugada es correcta, activa animacion
            checkCorrect = true;
            CorrectAns();
        }

        if (GetComponent<Animator>().GetBool("Click") == true && checkWrong == false && AnsManager.GetComponent<AnswrMngrMemoTest>().Wrong == true)
        {//Si el state de animacion es click y la jugada no es correcta, activa animacion
            checkWrong = true;
            WrongAns();
        }
    }

    IEnumerator AutoDestruction(float time) //tiempo de autodestruccion
	{		
		yield return new WaitForSeconds(time);
		Destroy (gameObject);
	}

	void CorrectAns(){
		GetComponent<Animator> ().SetBool ("Correct", true);
		StartCoroutine (AutoDestruction (1f));
		Cleaner ();
	}

	void WrongAns(){ //Acciones al equivocarse
		GetComponent<Animator> ().SetBool ("Click", false);
		GetComponent<Animator> ().SetBool ("Wrong", true);
		gameObject.GetComponent<Button> ().interactable = true;
		Cleaner ();
	}

	void Cleaner(){ //Resetea variables
		checkCorrect = false;
		checkWrong = false;
	}
}
