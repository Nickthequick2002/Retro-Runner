using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

///<summary>
///Controls the player's movement, jumping and animation
///</summary>

public class Player_Movement : MonoBehaviour
{
    // Components
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    // Movement Settings
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 14f;

    //Ground Detection
    [SerializeField] private LayerMask jumpGround;

    //Audio for Jumping
    [SerializeField] private AudioSource jumpSound;

    //Animation States
    private enum MovementState { Idle, Running, Jumping, Falling };


    ///<summary>
    ///Initiliazes the components above
    ///</summary>

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       sprite = GetComponent<SpriteRenderer>();
       coll = GetComponent<BoxCollider2D>();
       anim = GetComponent<Animator>();
    }

    ///<summary>?
    ///Handle the movement and animation for every frame
    ///</summary>

    private void Update()
    {
        if (!Pause_Menu.isPaused)
        {
            HandleMovement();
        }   
        if (!Pause_Menu.isPaused)
        {
            HandleJump();
        }
        UpdateAnimation();
    }

    ///<summary>
    ///Handles the Horizontal movement of the player
    ///</summary>
    
    private void HandleMovement()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);

        //Flip the player's sprite based on the direction
        sprite.flipX = dirX < 0;
    }

    ///<summary>
    ///Handles the jumping logic for the player
    ///</summary>
    
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    ///<summary>
    ///Updates animation state based on the movement and the velocity
    ///</summary>

    private void UpdateAnimation()
    {
       MovementState state = MovementState.Idle;
       
        if (rb.velocity.x != 0)
        {
            state = MovementState.Running;
        }

        // If the player's vertical velocity is positive, they jump
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.Jumping;
        }

        //If the player's velocity is negative, they fall
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }

        //Update the animator with the current state
        anim.SetInteger("state", (int)state);
    }

    ///<summary>
    ///Checks if the player is on the ground
    ///</summary>
    ///<returns> True if grounded, false otherwise</returns>
    
    private bool IsGrounded()
    {
        //Perform a BoxCast below the player's collider to detect the ground
        //col.bounds defines the size and position of the collider.
        //Vector2.down specifies the downwards direction
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);
    }

}