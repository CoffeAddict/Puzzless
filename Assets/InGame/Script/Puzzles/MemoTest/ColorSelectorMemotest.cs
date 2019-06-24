using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectorMemotest : MonoBehaviour {

	public int localColor;
	public RuntimeAnimatorController[] AnimColors = new RuntimeAnimatorController[4];
	public Sprite[] CardSprite = new Sprite[4];
	public void SwitchColors(){
		gameObject.GetComponent<Image>().sprite = CardSprite[localColor];
		gameObject.GetComponent<Animator>().runtimeAnimatorController = AnimColors[localColor];		
	}
}
