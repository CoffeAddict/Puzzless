using UnityEngine;

public class PuzzleManagerNumbers : MonoBehaviour {
	public GameObject NumberObj;//Prefab numero
	public Transform[] Spawnpoint = new Transform[4];//Listado de Spawnpoint

	int num;//numero
	int allComp; //Cuantas veces se comparo
	public int[] number = new int[4];//Array de las numeros a Spawnear

	public GameObject AnswerManager;

    public GameObject[] SpawnedNumbers = new GameObject[4];

	void Start () {
		Spawn();
	}

	void Spawn()
    { //Elige las variales
        for (int i = 0; i <= 3; i++)
        {
            RandomNumber(); //Tira una numero random
            number[i] = num; //La agrega al array
            if (i == 0)
            { //Si es la primer numero, la spawnea de una				
                SpawnNumber(i);
            }
            else
            { //Sino, verifica que no se repita
                for (int j = 0; j <= 3; j++)
                { //Tiene que verificar con las cuatro numeros					
                    if (i != j)
                    { //Menos con ella misma						
                        if (number[i] != number[j])
                        { //Si es diferente suma a la variable que verifica							
                            allComp++;
                        }
                        else
                        { //Si es igual, vuelve a elegir otra numero							
                            i--;
                            allComp = 0;
                            break;
                        }
                    }
                }
                if (allComp == 3)
                { //Si es diferente a todas, la spawnea

                    SpawnNumber(i);
                    allComp = 0; //Reinicia variable
                }
            }
        }

        SetData();
    }

    private void SetData() //Asigna las variables
    {
        for (int k = 0; k < 4; k++)
        {
            AnswerManager.GetComponent<AnswrMngrNumbers>().OrgNumbers[k] = number[k]; //Indica las respuestas al AnswerManager
        }
    }

    void RandomNumber(){ //numero aleatorio
		num = Random.Range(0, 19);
	}

	void SpawnNumber(int index)
    {
        int color = GameObject.FindWithTag("LvlManager").GetComponent<ColorSelectorManager>().Color;
        NumberObj.GetComponent<NumbersNumber>().Number = number[index];
        SpawnedNumbers[index] = (GameObject)Instantiate(NumberObj, Spawnpoint[index]);  //Crea el boton
        AssingColors(index, color);
    }

    private void AssingColors(int index, int color)
    {
        SpawnedNumbers[index].GetComponent<ColorSelectorAdapter_Dinamic>().localColor_Dinamic = color;
        SpawnedNumbers[index].GetComponent<ColorSelectorAdapter_Dinamic>().SwitchColors();
    }
}
