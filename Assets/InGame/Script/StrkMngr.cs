using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrkMngr : MonoBehaviour {
	public int Streak;
	public GameObject StreakObj;
	public Transform Canvas;

	int LastColor;

	int random;
	public void AddStreak () {	//Aumenta el streak
			Streak++;
			StreakAnimManager ();
	}

	void StreakAnimManager(){//Animacion de la racha
		if (Streak != 1) { //Si hay mas de 1 racha
			StreakObj.GetComponent<Text> ().text = "X" + Streak;
			RandomColor ();
			Instantiate (StreakObj, Canvas);
		}
	}

	void RandomColor()
    { //Asigna un color aleatorio a la animacion de la racha


        for (int i = 0; i < 1; i++) //Verifica que no se repita el color
        {
            random = Mathf.RoundToInt(Random.Range(0f, 3f));
            if (random != LastColor)
            {
                ColorAssigner();
				LastColor = random;
            }
            else
            {
                i--;
            }
        }
    }

    private void ColorAssigner() //Asigna un color al obj de racha
    {
        switch (random)
        {
            case 0:
                StreakObj.GetComponent<Text>().color = new Color32(167, 204, 227, 255); //Celeste
                break;
            case 1:
                StreakObj.GetComponent<Text>().color = new Color32(76, 194, 74, 255); //Verde
                break;
            case 2:
                StreakObj.GetComponent<Text>().color = new Color32(228, 63, 63, 255); //Rojo
                break;
            case 3:
                StreakObj.GetComponent<Text>().color = new Color32(251, 211, 65, 255); //Amarillo
                break;
        }
    }
}
