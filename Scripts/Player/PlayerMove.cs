using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour{


	[SerializeField] private GVRInput m_GVRInput;   
	private CharacterController controller;
	private float gravity = 300f;
	public GameObject eye_dPos;
	public float moveSpeed = 5.0f;
	[SerializeField] private GameObject miniMap;

	void Awake(){
		controller = this.GetComponent<CharacterController> ();
	}

	private void OnEnable()
	{
		m_GVRInput.OnSwipe += HandleSwipe;
		m_GVRInput.OnClickApp += AppButtonDown;
		m_GVRInput.OnClickAppUp += AppButtonUp;
	}

	private void OnDisable()
	{
		m_GVRInput.OnSwipe -= HandleSwipe;
		m_GVRInput.OnClickApp -= AppButtonDown;
		m_GVRInput.OnClickAppUp -= AppButtonUp;
	}

	private void AppButtonDown(){
		miniMap.SetActive (true);
	}
	private void AppButtonUp(){
		miniMap.SetActive (false);
	}

	private void HandleSwipe(GVRInput.SwipeDirection swipeDirection)
	{
		Vector3 transformValue = new Vector3(); 
		switch (swipeDirection)
		{
		case GVRInput.SwipeDirection.NONE:
			break;
		case GVRInput.SwipeDirection.UP:
			transformValue = eye_dPos.transform.forward * Time.deltaTime;  
			break;  
		case GVRInput.SwipeDirection.DOWN:
			transformValue = (-eye_dPos.transform.forward) * Time.deltaTime;  
			break;  
		case GVRInput.SwipeDirection.LEFT:
			transformValue = (-eye_dPos.transform.right )* Time.deltaTime;  
			break;  
		case GVRInput.SwipeDirection.RIGHT:
			transformValue = eye_dPos.transform.right * Time.deltaTime;  
			break;  
		}
		transformValue = transform.TransformDirection(transformValue);
		transformValue *= moveSpeed;
		transformValue.y -= gravity * Time.deltaTime;
		controller.Move(transformValue);
	}
}

