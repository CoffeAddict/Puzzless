using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruct : MonoBehaviour {

	public RuntimeAnimatorController PuzzleSmaller;
	public void AutoDestruct(){
			StartCoroutine (AutoDestruction (0.25f));
	}

	IEnumerator AutoDestruction(float time) //tiempo de autodestruccion
	{		
		gameObject.GetComponent<Animator>().runtimeAnimatorController = PuzzleSmaller;
		yield return new WaitForSeconds(time);
		Destroy (gameObject);
	}
}
