using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour {

	[SerializeField] private int life = 100;
	public int GetPlayerLife(){
		return life;
	}
	[SerializeField] private VRCameraFade vfade;
	[SerializeField] private Color fadeColor = Color.red; 
	[SerializeField] private GameObject life_circle;

	// Use this for initialization
	public void GetDamage(int damage){
		if (this.life > 0) {
			this.life -= damage;
		}
		if(this.life <= 0){
			DoDie ();
		}
	}

	public void XuetiaoFadeIn(){
		//Camera FadeIn
		vfade.m_FadeDuration = 1.0f;
		vfade.m_FadeColor = fadeColor;
		vfade.StartFadeIn (true);
	}

	void Update(){
		if(this.life >= 100){
			//life_circle.SetActive(false);
		}
	}

	private void DoDie(){
		SceneManager.LoadScene ("Maze_scene");
	}
}
