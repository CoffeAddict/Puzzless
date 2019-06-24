using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public Transform camTransform;
	public bool Active;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 0.1f;
	Vector3 originalPos;


	void Awake(){
		camTransform = GetComponent (typeof(Transform)) as Transform; //iguala la posicion de la camara a una variable
		originalPos = camTransform.position; //guarda la posicion inicial
	}

	void FixedUpdate(){
		if (Active == true) { //Si el ModoShake esta activo
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount; //la posicion de la camara = un punto random dentro de un rango esferico del objeto
			StartCoroutine (Timer (0.1f)); //Inicia un timer (seria la duracion del shake)
		} else { //Si el shake no esta activo
			camTransform.localPosition = originalPos; //vuelve a la posicion original
		}
	}

	IEnumerator Timer (float shakeDuration) //Bucle infinito para que los botones sapen el estado de "cangePos"
	{	

		yield return new WaitForSeconds (shakeDuration);
		Active = false;	
	}
}
