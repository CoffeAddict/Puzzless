using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRenderChange : MonoBehaviour {
	void Start () { //En el awake se ajusta a la pantalla y en el start, entra en modo WorldSpace, para permitir el shake
		GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
	}
}
