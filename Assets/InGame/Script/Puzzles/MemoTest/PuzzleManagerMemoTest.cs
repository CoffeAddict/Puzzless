using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerMemoTest : MonoBehaviour {
	public GameObject[] Card = new GameObject[9];
	public GameObject[] Spawnpoint = new GameObject[9];

	public int[] num = new int[9];
	bool check = false;
	int j;

	public GameObject[] SpawnedCards = new GameObject[9];

	void Start () {
		RandomNumbers ();
		CardSpawner ();
	}

	void RandomNumbers(){ //Elige las variables y las asigna

		num[0] = Random.Range (0, num.Length); //El primer numero no hace falta compararlo

		for (int i = 1; i < num.Length; i++) { //Va tirar numeros aletorios dependiendo del array

			num [i] = Random.Range (0, num.Length); //Numero aleatorio
			check = false; //Resetea la variable

			while(check == false){ //checkea el boolean

				if (i != j) { //Si no se compara con sigo mismo

					if (num [i] == num [j]) { //Si es igual a otro numero de array, tira otro numero

						num [i] = Random.Range (0, num.Length);
						j = 0; //Resetea el comparadro

					} else { //Si es correcto, aumenta el comparador
						j++;
					}

				} else { //Si se compara con sigo mismo, salta a la siguiente
					j++;
				}

				if (j == num.Length) { //Si se comparo con todos, resetea variable, quiebra el while y pasa a la siguiente
					check = true;
					j = 0;
				}
			}
		}
	}

	void CardSpawner(){	
		int color = GameObject.FindWithTag("LvlManager").GetComponent<ColorSelectorManager>().Color;
		for(int i = 0; i < Card.Length; i++)
        { //Spawnea cada carta en un spawnpoint			
            SpawnedCards[i] = (GameObject)Instantiate(Card[i], Spawnpoint[num[i]].transform);
            AssignColor(color, i);
        }
    }

    private void AssignColor(int color, int i)
    {
        SpawnedCards[i].GetComponent<ColorSelectorMemotest>().localColor = color;
        SpawnedCards[i].GetComponent<ColorSelectorMemotest>().SwitchColors();
    }
}
