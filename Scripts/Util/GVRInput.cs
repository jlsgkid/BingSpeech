using System;
using UnityEngine;

public class GVRInput : MonoBehaviour{

	//Swipe directions
	public enum SwipeDirection
	{
		NONE,
		UP,
		DOWN,
		LEFT,
		RIGHT
	};

	//event 
	public event Action<SwipeDirection> OnSwipe; 
	public event Action OnTouchPad;   
	public event Action OnClickPad;
	public event Action OnClickApp;
	public event Action OnClickAppUp;

	private void Update(){
		CheckInput();
	}

	private void CheckInput(){

		SwipeDirection swipe = SwipeDirection.NONE;
		if(GvrController.TouchUp){
			swipe = SwipeDirection.NONE;
		}
		//Touch Pad
		if(GvrController.IsTouching){
			swipe = DetectSwipe();
			if(OnSwipe != null)
				OnSwipe(swipe);
			if(OnTouchPad != null)
				OnTouchPad();
		}
		//Click Pad
		if (GvrController.ClickButtonDown) {
			if(OnClickPad != null){
				OnClickPad();
			}
		}
		if(GvrController.AppButtonDown){
			if(OnClickApp != null){
				OnClickApp();
			}
		}
		//ClickAppUp
		if(GvrController.AppButtonUp){
			if(OnClickAppUp != null){
				OnClickAppUp();
			}
		}
	}

	private SwipeDirection DetectSwipe (){

		Vector2 curPos = GvrController.TouchPos;
		if (GvrController.TouchPos.x > 0.8) {
			//Debug.Log ("RIGHT");
			return SwipeDirection.RIGHT;
		} else if (GvrController.TouchPos.x  <0.2) { 
			//Debug.Log ("LEFt");
			return SwipeDirection.LEFT;
		} else if (GvrController.TouchPos.y < 0.2) {
			//Debug.Log ("UP");
			return SwipeDirection.UP;
		} else if(GvrController.TouchPos.y > 0.8){
			//Debug.Log ("DOWN");
			return SwipeDirection.DOWN;
		}
		return SwipeDirection.NONE;

	}

	private void OnDestroy(){
		OnSwipe = null;
		OnTouchPad = null;
		OnClickPad = null;
		OnClickApp = null;
	}

}
	