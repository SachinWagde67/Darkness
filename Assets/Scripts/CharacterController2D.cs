﻿using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float JumpForce = 400f;
	[SerializeField] public float speed;	
	[SerializeField] private bool AirControl = false;							
	[SerializeField] private LayerMask WhatIsGround;							
	[SerializeField] private Transform GroundCheck;
	[SerializeField] private Transform FallCheck;
	[SerializeField] private Animator anim;
	[SerializeField] private LayerMask LayerLight;

	private bool Grounded;
	const float GroundedRadius = .05f; 
	const float FallRadius = .05f;
	private float horizontal;
	private Rigidbody2D rb;
	private bool FacingRight = true;
	private bool jump = false;
	private Vector3 Velocity = Vector3.zero;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update() 
	{
		horizontal = Input.GetAxisRaw("Horizontal") * speed;
		anim.SetFloat("speed", Mathf.Abs(horizontal));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			anim.SetBool("jump", true);
		}
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (!jump)
			{
				anim.SetTrigger("attack");
				speed = 0f;
				Invoke(nameof(SpeedChange), 0.7f);
			}
		}
	}

	private void FixedUpdate()
	{
		bool wasGrounded = Grounded;
		Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				Grounded = true;
				if (!wasGrounded)
				{
					anim.SetBool("jump", false);
				}
			}
		}
        Collider2D[] fallcollider = Physics2D.OverlapCircleAll(FallCheck.position, FallRadius, WhatIsGround);
        for (int i = 0; i < fallcollider.Length; i++)
        {
            if (fallcollider[i].gameObject != gameObject)
            {
                anim.SetBool("fall", false);
                anim.SetTrigger("land");
            }
        }
        Move(horizontal * Time.fixedDeltaTime, jump);
		jump = false;
	}


	public void Move(float move, bool jump)
	{
		if (Grounded || AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			rb.velocity = targetVelocity;

			if (move > 0 && !FacingRight)
			{
				Flip();
			}
			else if (move < 0 && FacingRight)
			{
				Flip();
			}
		}
		if (Grounded && jump)
		{
			Grounded = false;
			rb.AddForce(new Vector2(0f, JumpForce * 100f));
		}
	}
	private void Flip()
	{
		FacingRight = !FacingRight;
		transform.Rotate(0, 180, 0);
	}

	private void SpeedChange()
    {
		speed = 20f;
    }

	private void Fall()
    {
		anim.SetBool("fall", true);
	}
}