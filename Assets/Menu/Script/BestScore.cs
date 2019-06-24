using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BestScore : MonoBehaviour {

	public GameObject ScoreTxt;
	public GameObject ScoreBg;
	public Sprite[] HudColors = new Sprite[4];
	void Awake ()
    {
        CheckBestScore();
		RandomSprite();
    }

    private void CheckBestScore()
    {
        if (PlayerPrefs.HasKey("MaxScore") == true)
        { //Si existe la variable de maxscore
            ScoreTxt.GetComponent<Text>().text = "Best Score"+ Environment.NewLine + PlayerPrefs.GetInt("MaxScore"); //Actualiza el maxscore
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

	void RandomSprite(){
		int randomPos = Mathf.RoundToInt(UnityEngine.Random.Range(0,3));
		ScoreBg.GetComponent<Image>().sprite = HudColors[randomPos];
	}
}
