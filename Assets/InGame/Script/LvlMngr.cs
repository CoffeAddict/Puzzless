using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlMngr : MonoBehaviour {
	public GameObject PG;
	public float Key;
	public bool Solve;
	public bool Fail;

	public bool check;

	public float[] Range = new float[2];

	public float delayTime;

	public GameObject Score;

	public GameObject Timer;
	public int TimerTime;

	public GameObject[] Lives = new GameObject[3];
	public int lives = -1;

	public GameObject StreakManager;

	public int PuzzleCount;

	int LastPuzzle;

	public GameObject CorrectClick;

	public GameObject LoseStats;

	public void Start () {
		StartCoroutine(FirstDelay(0.5f)); //Genera un delay la primera vez, por la transicion
	}

	public void Solved(){ //Acciones al resolverse un puzzle

			StreakSolvedAction (); //Aumenta el streak
			
			CorrectClick.SetActive(true);
			CorrectClick.GetComponent<ChangePosInHerarchy>().PositionChanger();

			//El score es igual a los segundos que tardaste en hacer el puzzle por la cantidad de streak si hay streak > 1
			if (StreakManager.GetComponent<StrkMngr> ().Streak > 1) {
				Score.GetComponent<Score> ().score += Timer.GetComponent<Timer> ().Seconds * StreakManager.GetComponent<StrkMngr> ().Streak;
			} else {
				Score.GetComponent<Score>().score += Timer.GetComponent<Timer> ().Seconds;
			}

			Score.GetComponent<Score>().RenewText();

			Timer.GetComponent<Timer> ().Seconds = 16; //Resetea el timer;

			

			StartCoroutine (SpawnDelayer(delayTime));
	}

	void SelectRandomPuzzle()
    { //Elige un puzzle random entre el rango y los Spawnea       
		gameObject.GetComponent<ColorSelectorManager>().SelectColor();
        for(int i = 0; i < 1; i++){ //Evita que se repita el puzzle
			Key = Random.Range(0f, PG.GetComponent<PuzzleGen>().Puzzles.Length - 1f);
			if (Mathf.RoundToInt(Key) != LastPuzzle)
			{
				Spawn();
			}else{
				i--;
			}
		}
    }

    private void Spawn()
    {	
        PG.GetComponent<PuzzleGen>().Spawn(Mathf.RoundToInt(Key)); //Accion de spawnear
        LastPuzzle = Mathf.RoundToInt(Key); //Guardar el numero de puzzle
        PuzzleCount++; //Aumentar la cantidad spawneada
        PG.GetComponent<PuzzleGen>().DifficultManager(); //Ejecutar la dificultad (actualizar)
    }

    public void LivesManager(){
		switch (lives) { //Verifica cuantas vidas hay y realiza una accion (activar sprites)
		case 0:
			Lives [0].SetActive (true);
			break;
		case 1:
			Lives [0].SetActive (true);
			Lives [1].SetActive (true);
			break;
		case 2:
			Lives [0].SetActive (true);
			Lives [1].SetActive (true);
			Lives [2].SetActive (true);
			break;
		case 3:
			Lives [0].SetActive (true);
			Lives [1].SetActive (true);
			Lives [2].SetActive (true);
			Lives [3].SetActive (true);
			break;
		case 4:
			Lives [0].SetActive (true);
			Lives [1].SetActive (true);
			Lives [2].SetActive (true);
			Lives [3].SetActive (true);
			Lives [4].SetActive (true);
			StartCoroutine (Lose("01")); // al perder 3 vidas, pierde
			break;
		}
	}

	void SaveMaxScore(){
		if (PlayerPrefs.HasKey ("MaxScore") == true ) { //Si existe la variable de maxscore
			if (PlayerPrefs.GetInt ("MaxScore") < Score.GetComponent<Score> ().score) { //y el score es mayor al anterior

				PlayerPrefs.SetInt ("MaxScore", Score.GetComponent<Score> ().score); //Lo actualiza
			}
		} else {
			PlayerPrefs.SetInt ("MaxScore", Score.GetComponent<Score> ().score);//Si no existe lo crea
		}
	}

	void StreakSolvedAction(){
		StreakManager.GetComponent<StrkMngr> ().AddStreak(); //Aumenta el streak
	}

	public void StreakWrongAction(){
			StreakManager.GetComponent<StrkMngr> ().Streak = 0;	//Resetea el streak
	}

	IEnumerator Lose(string ChangeTo) //Acciones a realizar al perder
	{
		SaveMaxScore (); //Guarda el score
		yield return new WaitForSeconds(0.5f);
		PuzzleDestroyer();
		Timer.SetActive(false);
		LoseScene();
	}

	void LoseScene(){
		LoseStats.SetActive(true);
	}

	IEnumerator SpawnDelayer(float DelayTime) //Retrasa el spawn del proximo puzzle
    {
		PuzzleDestroyer();
		yield return new WaitForSeconds(0.25f);
		CorrectClick.SetActive(false);
		yield return new WaitForSeconds(DelayTime/2);
        SelectRandomPuzzle();
    }

    private void PuzzleDestroyer()
    {
        GameObject.FindWithTag("Puzzle").GetComponent<Autodestruct>().AutoDestruct();   //Le indica al puzzle que se resolvio y se tiene que destruir
	}

    IEnumerator FirstDelay(float index){ //Delay del inicio para resolver problemas con animacion
		yield return new WaitForSeconds(index);
		SelectRandomPuzzle ();
	}
}
