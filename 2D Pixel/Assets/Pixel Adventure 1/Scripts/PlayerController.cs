using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PolygonCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovemementState { idle, running, jumping, falling }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpForce);
        }
        UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate()
    {
        MovemementState state;

        if (dirX > 0f)
        {
            state = MovemementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovemementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovemementState.idle;
        }

        // keep running animation on top of jumping animation because it has higher priority
        if (rb.velocity.y > .1f) // tells if the movement is going up
        {

            state = MovemementState.jumping;

        }

         if (rb.velocity.y < -.1f) //downward motion
        { // when youre not touching the ground

            state = MovemementState.falling;

        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded(){ // if player is touching the ground then they are allowed to jump, this avoids the player jumping multiple times.
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
