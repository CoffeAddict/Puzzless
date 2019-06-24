using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButtons : MonoBehaviour {

	public GameObject TrasitionWallpaperObj;
	public void OnClick(string scene){
		TrasitionWallpaperObj.SetActive(true);
		TrasitionWallpaperObj.GetComponent<TransitionWallpaper>().Scene = scene;
		TrasitionWallpaperObj.GetComponent<TransitionWallpaper>().StartCount();		
	}
}
