using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float timer;

    void Start()
    {
        StartCoroutine(Destroyer(timer));
    }
    IEnumerator Destroyer(float time)
    { //Acciones al perder
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
