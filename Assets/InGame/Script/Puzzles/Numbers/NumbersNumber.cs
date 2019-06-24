using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumbersNumber : MonoBehaviour {
	public Sprite[] NumbersSprite = new Sprite[20];
	public int Number;
    public Image NumberImgObj;

	void Start () { 
		NumberImgObj.sprite = NumbersSprite[Number]; //Dependiendo de la variable que le baje el padre
		//asigna una imagen
	}

}