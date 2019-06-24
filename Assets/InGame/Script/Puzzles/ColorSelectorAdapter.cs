using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectorAdapter : MonoBehaviour {
	GameObject LevelManager;
	public int localColor;
	public GameObject PuzzleObject;
	public Sprite[] ObjectsSprites;
	
	void Start(){
		LevelManager = GameObject.FindWithTag("LvlManager");
		localColor = LevelManager.GetComponent<ColorSelectorManager>().Color;
		SwitchColors();	
	}

	void SwitchColors(){
			PuzzleObject.GetComponent<Image>().sprite = ObjectsSprites[localColor];
	}

}
