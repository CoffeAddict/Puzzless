using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectorAdapter_Dinamic: MonoBehaviour {
	public int localColor_Dinamic;

    public Sprite SpritesBlue;
    public Sprite SpritesGreen;
    public Sprite SpritesRed;
    public Sprite SpritesYellow;

	public void SwitchColors(){
		switch(localColor_Dinamic){
			case 0:
					gameObject.GetComponent<Image>().sprite = SpritesBlue;
				break;
			case 1:
					gameObject.GetComponent<Image>().sprite = SpritesGreen;				
				break;
			case 2:
					gameObject.GetComponent<Image>().sprite = SpritesRed;				
				break;
			case 3:
					gameObject.GetComponent<Image>().sprite = SpritesYellow;				
				break;
		}
	}
}
