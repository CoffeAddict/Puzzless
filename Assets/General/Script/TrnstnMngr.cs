using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrnstnMngr : MonoBehaviour
{
    public string m_Scene;

    public RuntimeAnimatorController TransitonWallpaperAnim;

    public GameObject TransitionWallpaperObj;

    public GameObject ReadyObj;

    public GameObject PuzzleGenObj;
    public GameObject LvlManagerObj;
    public GameObject TimerObj;
    public GameObject ScoreObj;

    void Start()
    {
        m_Scene = SceneManager.GetActiveScene().name.ToString(); //Obtiene el nombre de la escena actual
        SceneActions();
    }

    public void SceneActions()
    {
        TransitionWallpaperObj.GetComponent<Animator>().runtimeAnimatorController = TransitonWallpaperAnim;
        StartCoroutine(Ready(1.5f));
    }
    IEnumerator Ready(float index)
    {
        ChangeStatus(false);
        yield return new WaitForSeconds(0.35f);
        ReadyObj.SetActive(true);
        yield return new WaitForSeconds(index);
        Destroy(GameObject.FindWithTag("ReadyObj"));
        ChangeStatus(true);
    }

    void ChangeStatus(bool index)
    {
        LvlManagerObj.SetActive(index);

        PuzzleGenObj.SetActive(index);

        ScoreObj.SetActive(index);

        if (index == false)
        {
            TimerObj.SetActive(index);
        }
        else
        {
            StartCoroutine(TimerDelayer(0.1f));
        }
    }

    IEnumerator TimerDelayer(float time)
    {
        yield return new WaitForSeconds(time);
        TimerObj.SetActive(true);
        TimerObj.GetComponent<Timer>().Update();
    }

}
