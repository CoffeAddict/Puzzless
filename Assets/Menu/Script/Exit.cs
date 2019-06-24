using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
	void Update () {
		Escape();
	}
    void Escape(){
		if(Input.GetKeyDown(KeyCode.Escape)){ //Si se toca Escape o volver en celulares
		//cierra la aplicacion
			Application.Quit ();
		}
	}
}
