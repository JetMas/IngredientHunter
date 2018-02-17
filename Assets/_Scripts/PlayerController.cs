using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private bool attacking;
	private bool blocking;

	public Animator animator;
	public float attackTime;
	public float blockTime;
	public int speed;

	// Use this for initialization
	void Start () {
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
		Block ();
		Move ();
	}

	private void Move() {
		if (Input.GetKey (KeyCode.D) && !attacking && !blocking) {
			gameObject.transform.eulerAngles = Vector2.zero;
			gameObject.transform.Translate (Vector2.right * speed * Time.deltaTime, Space.World);
			animator.SetInteger ("speed", 1);
		} 
		else if (Input.GetKey (KeyCode.A) && !attacking && !blocking) {
			gameObject.transform.eulerAngles = new Vector2 (0f, -180f);
			gameObject.transform.Translate (-Vector2.right * speed * Time.deltaTime, Space.World);
			animator.SetInteger ("speed", 1);
		} 
		else {
			animator.SetInteger ("speed", 0);
		}
	}

	private void Attack() {
		if (Input.GetKeyDown (KeyCode.Q) && !attacking && !blocking) {
			animator.SetTrigger ("attack");
			attacking = true;
			StartCoroutine (AttackTimer ());

		}
	}

	IEnumerator AttackTimer(){
		yield return new WaitForSeconds (attackTime);
		attacking = false;
	}

	private void Block() {
		if (Input.GetKeyDown (KeyCode.E) && !attacking && !blocking) {
			animator.SetBool ("block", true);
			blocking = true;
		}
		if (Input.GetKeyUp (KeyCode.E) && blocking) {
			animator.SetBool ("block", false);
			StartCoroutine (BlockTimer ());
		}
	}

	IEnumerator BlockTimer() {
		yield return new WaitForSeconds (blockTime);
		blocking = false;
	}



}
