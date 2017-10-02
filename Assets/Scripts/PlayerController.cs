using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigidBody;
    SpriteRenderer renderer;
    Animator animator;

    bool facingRight = true;

    public float MaxSpeed;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxisRaw("Horizontal");

        if(move > 0  && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }

        animator.SetFloat("MoveSpeed", Mathf.Abs(move));
        rigidBody.velocity = new Vector2(move * MaxSpeed, rigidBody.velocity.y);
	}

    private void Flip()
    {
        facingRight = !facingRight;
        renderer.flipX = !renderer.flipX;
    }
}
