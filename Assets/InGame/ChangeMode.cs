using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ChangeMode : MonoBehaviour
{
    public bool EditMode;
    public bool thisSceneMode;
    public bool thisSceneMode_Spawnpoint;
    public GameObject Spawnpoint;
    public GameObject Timer;
    public GameObject TransitionWallpaper;
    public GameObject ReadyObj;

    void Update()
    {
        if (EditMode == true && thisSceneMode == true && thisSceneMode_Spawnpoint == true)
        {
            Spawnpoint.SetActive(true);
            Timer.SetActive(false);
        }
        else if (EditMode == true && thisSceneMode == true)
        {
            Timer.SetActive(true);
            Spawnpoint.SetActive(true);
        }
        else if (EditMode == true)
        {
            ChangeStatus(false);
        }
        else
        {
            ChangeStatus(true);
        }
    }
    void ChangeStatus(bool index)
    {
        try
        {
            Spawnpoint.SetActive(index);
            Timer.SetActive(index);
            TransitionWallpaper.SetActive(index);
            ReadyObj.SetActive(index);
        }
        catch
        {
            Debug.Log("Error: An object that you want to access do not exist anymore");
        }
    }
}
