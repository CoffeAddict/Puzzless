using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGen : MonoBehaviour {
	public GameObject[] Puzzles;
	public GameObject LevelManager;
	public Transform Spawnpoint;

	public GameObject Score;

	public int difficulty;

	public void Spawn(int K){
		Instantiate (Puzzles[K],Spawnpoint); //Spawnea el puzzle indicado en la varible, y donde se lo indica
    }

    public void DifficultManager()//Establece los niveles de dificultad
    {
        if (LevelManager.GetComponent<LvlMngr>().PuzzleCount > 7)
        {
            difficulty = 1;
        }
        else if (LevelManager.GetComponent<LvlMngr>().PuzzleCount > 14)
        {
            difficulty = 2;
        }
    }
}
