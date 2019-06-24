using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuzzleManagerOP : MonoBehaviour {

	public float N1;
	public float N2;
	public int OP;
	float Result;
	public GameObject N1Obj;
	public GameObject N2Obj;
	public GameObject ResultObj;

	public GameObject AnswerManager;

	void Start () {
		SelectOperation_Numbers();
	}

	void SelectOperation_Numbers(){ //Elige las variable 
		N1 = Random.Range(1,10);
		N2 = Random.Range(1,10);		
		OP = Mathf.RoundToInt(Random.Range(0f,3f));
		switch(OP){
			case 0:
				Result = N1+N2;
				break;
			case 1:
				Result = N1-N2;
				break;
			case 2:
				Result = N1*N2;
				break;
			case 3:
				Result = N1/N2;
				break;
		}
		SetData();
	}
	void SetData(){ //Asigna las variables
		N1Obj.GetComponent<Text>().text = N1.ToString();
		N2Obj.GetComponent<Text>().text = N2.ToString();
		ResultObj.GetComponent<Text>().text = System.Math.Round(Result,2).ToString();
		AnswerManager.GetComponent<AnswrMngrOP>().GetAnswer();		
	}
}
