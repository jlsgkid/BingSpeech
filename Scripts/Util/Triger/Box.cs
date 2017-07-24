using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	private Animation anim;
	[SerializeField] private GameObject box;
	[SerializeField] private bool isCanOpen = false;

	// Use this for initialization
	void Awake () {
		anim = box.GetComponent<Animation> ();
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Triger");
		//Destroy(other.gameObject);
		//&& other.tag.CompareTo("Player")
		if(isCanOpen ){
			anim.CrossFade("woodenchest_large_open");
			//Destroy(box, 5);
		}
	}

	public void EyeEnter(){
		isCanOpen = true;
	}
		
}
