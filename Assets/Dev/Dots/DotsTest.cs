using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsTest : MonoBehaviour {

	public Camera MainCamera;
	public GameObject[] Dots;
	public GameObject FirstDot;
	public GameObject LastDot;
	bool[] DotTaken = new bool[9];
	public float TouchRange;
	Vector3 TouchPos;
	LineRenderer Line;
	int LineCount;
	public bool check01;
	bool check02;
	bool FirstMove;
	public bool GoUp; public bool GoDown; public bool GoLeft; public bool GoRight;

	void Start(){
		Line = gameObject.GetComponent<LineRenderer> ();
		LineCount = 1;
		Line.SetPosition(0,new Vector3(FirstDot.transform.position.x,FirstDot.transform.position.y,0));
		Line.SetPosition(1,new Vector3(FirstDot.transform.position.x,FirstDot.transform.position.y,0));
			GoUp = false;
			GoDown = true;
			GoLeft = false;
		GoRight = false;
	}

	void FixedUpdate () {
		//DotTaken = new bool[Dots.Length];
		OnTouch ();
	}

	void OnTouch(){
		if (Input.touchCount != 1) { //Si no hay mas o menos de un touch
			if (Input.touchCount > 1) {
				LineReset ();
			}
			if (Input.touchCount < 1 && check02 == true) {
				LineReset ();
			}
		} else { //Sino
			check02 = true;
			TouchPos = MainCamera.ScreenToWorldPoint (Input.GetTouch(0).position);//Se obtiene la posicion del touch
			LinePos(); 
		}
	}

	void LinePos(){ //Modifica la posicion de la linea
		
		SpotChecker ();
		DirectionChecker ();
	}

	void DirectionChecker(){
		if(GoLeft && TouchPos.y < Line.GetPosition (LineCount).y + TouchRange && TouchPos.x < Line.GetPosition (LineCount-1).x){ //Habilitar movimiento izquierda
			Line.SetPosition (LineCount, new Vector3 (TouchPos.x, Line.GetPosition(LineCount-1).y, 0));
		}
		if(GoRight && TouchPos.y > Line.GetPosition (LineCount).y - TouchRange && TouchPos.x > Line.GetPosition (LineCount-1).x){ //Habilitar movimiento derecha
			Line.SetPosition (LineCount, new Vector3 (TouchPos.x, Line.GetPosition(LineCount-1).y, 0));
		}
		if(GoDown && TouchPos.x < Line.GetPosition (LineCount-1).x + TouchRange && TouchPos.y < Line.GetPosition (LineCount-1).y){ //Habilitar movimiento abajo
			Line.SetPosition (LineCount, new Vector3 (Line.GetPosition(LineCount-1).x, TouchPos.y, 0));
		}
		if(GoUp && TouchPos.x > Line.GetPosition (LineCount-1).x - TouchRange && TouchPos.y > Line.GetPosition (LineCount-1).y){ //Habilitar movimiento arriba
			Line.SetPosition (LineCount, new Vector3 (Line.GetPosition(LineCount-1).x, TouchPos.y, 0));
		}
	}

	void SpotChecker(){
		for (int i = 0; i < Dots.Length; i++) { //Chekea la posiciones de todos los puntos del mapa
			if(Mathf.Round(Line.GetPosition(LineCount).x) == Mathf.Round(Dots[i].transform.position.x) && Mathf.Round(Line.GetPosition(LineCount).y) == Mathf.Round(Dots[i].transform.position.y) && i != 0 && DotTaken[i] == false && check01 == false){ //Si la posicion coincide, y no es el spawn, ni a si mismo
				check01 = true;
				DotTaken[i] = true; //Guarda que punto se toco
				Line.SetPosition (LineCount, new Vector3(Dots[i].transform.position.x,Dots[i].transform.position.y,0)); //Da una posicion fija al anterior
				LineCount++; //Y suma a la variable para empezar a darle una posicion con el touch al nuevo segmento
				Line.positionCount++;	//Agrega un segmento a la linea


				switch(i){
				case 1:
					GoUp = false;
					GoDown = true;
					GoLeft = false;
					GoRight = false;
					break;
				case 2:
					GoUp = false;
					GoDown = false;
					GoLeft = true;
					GoRight = true;
					break;
				case 3:
					GoUp = false;
					GoDown = false;
					GoLeft = false;
					GoRight = false;
					break;
				case 4:
					GoUp = false;
					GoDown = false;
					GoLeft = false;
					GoRight = true;
					break;
				case 5:
					GoUp = false;
					GoDown = true;
					GoLeft = false;
					GoRight = true;
					break;
				case 6:
					GoUp = false;
					GoDown = true;
					GoLeft = false;
					GoRight = false;
					break;
				case 7:
					GoUp = false;
					GoDown = true;
					GoLeft = false;
					GoRight = false;
					break;
				case 8:
					GoUp = false;
					GoDown = true;
					GoLeft = true;
					GoRight = false;
					break;
				case 9:
					GoUp = true;
					GoDown = false;
					GoLeft = false;
					GoRight = false;
					break;
				case 10:
					GoUp = false;
					GoDown = false;
					GoLeft = true;
					GoRight = false;
					break;
				case 11:
					GoUp = false;
					GoDown = false;
					GoLeft = false;
					GoRight = false;
					break;
				}
			}
		}
	}

	void LineReset(){ //Resetea la linea
		Line.positionCount = 2;
		Vector3[] dots = new Vector3[Line.positionCount]; //Crea un array de vectores base, para luego asignarselos a los puntos
		for (int j = 0; j < Line.positionCount; j++) { //Les asigna a todos, la posicion base
			dots [j] = new Vector3(FirstDot.transform.position.x,FirstDot.transform.position.y,0);
		}

		for (int k = 0; k < DotTaken.Length; k++) {
			DotTaken [k] = false;
		}
		Line.SetPositions (dots); //y luego la setea
		//Reseta para poder volver a detectar puntos en el mapa
		LineCount = 1; 
		check01 = false; 
		GoUp = false;
		GoDown = true;
		GoLeft = false;
		GoRight = false;
	}
}
