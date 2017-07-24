using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kusuri : MonoBehaviour {

	[SerializeField]
	private GameObject kusuri;
	[SerializeField]
	private GameObject light;
	[SerializeField]
	private GameObject cirlce_obj;
	private circleProcess cirlce;
	private bool isRo = false;
	[SerializeField]
	private PlayerState playerLife ;

	void Awake(){
		cirlce = cirlce_obj.GetComponent<circleProcess> ();
	}
	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
	void Update () {
		if(isRo){
			kusuri.transform.Rotate(0, 5, 0);
		}
	}

	public void EyeIn(){
		isRo = true;
		light.SetActive (true);
		kusuri.transform.Rotate(-5, 2, 0);
		//HP ++
		if(cirlce !=null && playerLife.GetPlayerLife() < 100){
			//cirlce_obj.SetActive (true);
			cirlce.HPUp(30);
		}
		Destroy (kusuri, 1);
	}
}
