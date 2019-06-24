using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectorManager : MonoBehaviour {

	public int Color; //0 = blue, 1 = green, 2 = red, 3 = yellow
	public int LastColor;
	public void SelectColor () {
		if(Color < 3){
			Color++;
		}else{
			Color = 0;
		}
	}
}
