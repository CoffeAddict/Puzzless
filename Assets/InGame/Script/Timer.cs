using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public int Seconds;
	Text text;
	GameObject LevelManager;
	GameObject MainCamera;

	public bool check; 


	public void Start () {
		LevelManager = GameObject.FindWithTag ("LvlManager"); //Busca al LevelManager y lo asigna a una variable
		MainCamera = GameObject.FindWithTag ("MainCamera");
		text = GetComponent<Text> (); //Igual el texto del objeto a una variable
		StartCoroutine (WaitForSeconds (1f));
	}

	public void Update()
    {
        SecondsChecker();
    }

    private void SecondsChecker()
    {
        if (Seconds == 0)
        { //Al llegar a 0, pierde
            StartCoroutine(Lose(0.3f));
        }
    }

    private IEnumerator WaitForSeconds(float time){ 
		for(int i = 0; i > -1; i++){ //Bucle infinito
				Seconds--;
				text.text = Seconds.ToString(); //Actualiza el text a la variable segundos
				yield return new WaitForSeconds (time);
		}
	}

	private IEnumerator Lose(float time){ //Acciones al perder
		yield return new WaitForSeconds (time);
		Handheld.Vibrate(); //Generacion vibracion generica
		MainCamera.GetComponent<CameraShake> ().Active = true; //Activa el shake de la camara
		LevelManager.GetComponent<LvlMngr> ().lives = 4; //El jugador pierde
		LevelManager.GetComponent<LvlMngr> ().LivesManager(); //Actualiza las vidas
	}
}
