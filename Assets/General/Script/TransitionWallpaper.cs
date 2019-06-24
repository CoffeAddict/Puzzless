using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionWallpaper : MonoBehaviour
{
    public string Scene;
    public void StartCount()
    {
        StartCoroutine(CountDown(1f));
    }
    IEnumerator CountDown(float index)
    { /*Espera un tiempo (mientras se ejecuta la anim de transicion)
	 y cambia de escena*/
        yield return new WaitForSeconds(index);
        SceneManager.LoadScene(Scene);
    }
}
