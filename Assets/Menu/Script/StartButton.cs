using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
	public GameObject TrasitionWallpaperObj;
	public void StartGame(string scene){
		TrasitionWallpaperObj.SetActive(true);
		TrasitionWallpaperObj.GetComponent<TransitionWallpaper>().Scene = scene;
		TrasitionWallpaperObj.GetComponent<TransitionWallpaper>().StartCount();		
	}
	
}
