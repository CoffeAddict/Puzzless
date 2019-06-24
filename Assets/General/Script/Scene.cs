using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void Buttons(string ChangeTo)
    {   //Cambia a la escena indicada en el boton
        SceneManager.LoadScene(ChangeTo);
    }
}
