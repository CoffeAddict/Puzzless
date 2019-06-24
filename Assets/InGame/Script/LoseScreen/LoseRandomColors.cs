using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseRandomColors : MonoBehaviour {

	public GameObject MenuButton;
	public GameObject RetryButton;
	public Sprite[] ButtonColors = new Sprite[4];
	int randomNumber2;
	int randomNumber1;

	void Start()
    {
        RandomColors();
    }

    private void RandomColors()
    {
        randomNumber1 = Mathf.RoundToInt(Random.Range(0, 3));
        
        for (int i = 0; i < 1; i++)
        {
            randomNumber2 = Mathf.RoundToInt(Random.Range(0, 3));
            if (randomNumber2 == randomNumber1)
            {
                 i--;
            }
        }
		MenuButton.GetComponent<Image>().sprite = ButtonColors[randomNumber1];
		RetryButton.GetComponent<Image>().sprite = ButtonColors[randomNumber2];
    }
}
