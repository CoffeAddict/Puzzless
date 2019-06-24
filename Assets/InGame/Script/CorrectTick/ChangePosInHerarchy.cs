using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosInHerarchy : MonoBehaviour {

	public int delta;

    public void PositionChanger()
    {
		if(gameObject.transform.parent.childCount == 2){
        int index = transform.GetSiblingIndex();
        transform.SetSiblingIndex(index + delta);
		}
    }
}
