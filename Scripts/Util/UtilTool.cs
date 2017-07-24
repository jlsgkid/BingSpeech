using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilTool : MonoBehaviour {

	public static IEnumerator SetObjUnEnaleAfterTime(GameObject obj, float time){
		yield return new WaitForSeconds (time);
		obj.SetActive (false);
	}

	public static IEnumerator SetObjUnEnaleAfterTime(GameObject obj1, GameObject obj2, float time){
		yield return new WaitForSeconds (time);
		obj1.SetActive (false);
		obj2.SetActive (false);
	}

	public static void SetObjActive(GameObject obj, bool state){
		obj.SetActive (state);
	}
}
