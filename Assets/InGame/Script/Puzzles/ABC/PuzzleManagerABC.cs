using UnityEngine;

public class PuzzleManagerABC: MonoBehaviour {

	public GameObject LetterObj;//Prefab Letra
	public Transform[] Spawnpoint;//Listado de Spawnpoint

	char let;//Letra
	int allComp; //Cuantas veces se comparo
	public char[] letter = new char[4];//Array de las letras a Spawnear

	public GameObject AnswerManager;

	public GameObject[] SpawnedLetters = new GameObject[4];

	void Awake () {
		Spawn ();		
	}

	void Spawn(){
		for(int i = 0; i <= 3; i++){			
			RandomLetter (); //Tira una letra random
			letter [i] = let; //La agrega al array
			if (i == 0) { //Si es la primer letra, la spawnea de una				
				SpawnLetter (i);
			} else { //Sino, verifica que no se repita
				for (int j = 0; j <= 3; j++){ //Tiene que verificar con las cuatro letras					
					if (i != j) { //Menos con ella misma						
						if (letter [i] != letter [j]) { //Si es diferente suma a la variable que verifica							
							allComp++;	
						} else { //Si es igual, vuelve a elegir otra letra							
							i--;
							allComp = 0;
							break;
						}
					}
				}
				if (allComp == 3) { //Si es diferente a todas, la spawnea

					SpawnLetter (i);
					allComp = 0; //Reinicia variable
				}
			}
		}

		for(int k = 0; k <4; k++){
			AnswerManager.GetComponent<AnswrMngrABC> ().OrgLetters [k] = letter [k]; //Indica las respuestas al AnswerManager
		}
	}

	void RandomLetter(){ //Letra aleatoria
		int num = Random.Range(0, 26);
		let = (char)('a' + num);
	}

	void SpawnLetter(int index)
    {
        int color = GameObject.FindWithTag("LvlManager").GetComponent<ColorSelectorManager>().Color;
        LetterObj.GetComponentInChildren<ABCLetter>().Letter = char.ToUpper(let); //Le dice al boton que letra debe mostrar
        LetterObj.GetComponent<ABCButton>().SP = index;
        SpawnedLetters[index] = (GameObject)Instantiate(LetterObj, Spawnpoint[index]);  //Crea el boton	
        AssignColor(index, color);
    }

    private void AssignColor(int index, int color)
    {
        SpawnedLetters[index].GetComponent<ColorSelectorAdapter_Dinamic>().localColor_Dinamic = color;
        SpawnedLetters[index].GetComponent<ColorSelectorAdapter_Dinamic>().SwitchColors();
    }
}
