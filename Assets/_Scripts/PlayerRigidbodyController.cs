using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyController : MonoBehaviour {

	public float maxSpeed;
	public Rigidbody2D rigidb;
	public SpriteRenderer sprite;
	public Animator anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		Movement ();
	}

	private void Movement() {
		//Get the direction of the horizontal movement
		float moveDirec = Input.GetAxis ("Horizontal");

		anim.SetFloat ("speed", Mathf.Abs (moveDirec));

		//Sprite starts facing right
		//So if the movement direction is to the left we need to slip the sprite
		if (moveDirec < 0) {
			sprite.flipX = true;
		} 
		else if (moveDirec > 0) {
			sprite.flipX = false;
		}

		//Adding velocity to the rigidbody
		rigidb.velocity = new Vector2(moveDirec * maxSpeed, rigidb.velocity.y);
	}
}
