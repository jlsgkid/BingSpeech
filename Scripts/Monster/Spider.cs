using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Spider : MonoBehaviour {

	//player
	private GameObject player;
	private PlayerState playerState;
	private UnityEngine.AI.NavMeshAgent nav;
	[SerializeField] private Monster.MonsterState state = Monster.MonsterState.IDLE;
	[SerializeField] private int life = 100;
	[SerializeField] private int atk = 20;
	[SerializeField] private float distance = 0.0f;
	private Animator animator;
	//xuetiao
	[SerializeField] private Slider xuetiao;
	[SerializeField] private circleProcess life_circle;

	//timer
	private float timer = 0.0f;

	//public event Action AttackPlayer;

	private void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		animator = GetComponent<Animator>();
		playerState = player.GetComponent<PlayerState> ();
	}
	
	// Update is called once per frame
	private void Update () {
		timer += Time.deltaTime;
		xuetiao.value = this.life;
		if (animator == null) return;
		if(state == Monster.MonsterState.ATTACK && timer > 1.2f){
			playerState.GetDamage (atk);
			life_circle.gameObject.SetActive (true);
			life_circle.MinusProcess (atk);
			playerState.XuetiaoFadeIn ();
			timer = 0.0f;
		}
//		if(state != Monster.MonsterState.ATTACK ){
//			life_circle.gameObject.SetActive (false);
//		}
		MoveToPlayer ();
	}

	private void DoDie(){
		state = Monster.MonsterState.DIE;
		xuetiao.gameObject.SetActive (false);
		nav.enabled = false;
		animator.SetTrigger ("die");
		Destroy (gameObject, 3.0f);
	}

	private void MoveToPlayer(){
		distance = Vector3.Distance (player.transform.position, transform.position);
		if(distance > 16f){
			state = Monster.MonsterState.IDLE;
		}
		else if (distance > 2.36f && distance < 16f) {
			state = Monster.MonsterState.WALK;
			if(this.life > 0){
				nav.SetDestination (player.transform.position);
			}
			animator.SetBool ("isAttack", false);
			animator.SetBool ("isWalk", true);
		} else {
			//player life 
			state = Monster.MonsterState.ATTACK;
			animator.SetBool ("isAttack", true);
			//animator.SetBool ("isWalk", false);
		}
	}

	private void ChangeAnim(){

	}

	//monster is damage
	public void GetDamage(int damage){
		if(state == Monster.MonsterState.DIE){
			return;
		}
		this.life -= damage;

		if(this.life <= 0){
			DoDie ();
		}
	}

}
