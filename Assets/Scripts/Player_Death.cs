using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///Handles the player's death, including triggering the death animation, sounds and restarting the level
///</summary>

public class Player_Death : MonoBehaviour
{
    // Components for controlling the player's physics and animations
    private Rigidbody2D rb;
    private Animator anim;

    // Sound effect for player death
    [SerializeField] private AudioSource deathSound;

    ///<summary>
    ///Initilizes the RigidBody2D and Animator components
    ///</summary>

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Reference to the RigidBody2D for the physics control
        anim = GetComponent<Animator>(); // Reference to the Animator for playing animations
    }

    ///<summary>
    ///Checks for collisions with traps and triggers the death sequence
    ///</summary>
    ///<parameter name = " collision" >The collision object involved in the event
    ///</parameter>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the object the player collides with object tagged as "Trap"
        if (collision.gameObject.CompareTag("Trap"))
        {
            deathSound.Play(); // Play death sound
            Die(); // Trigger the death sequence
        }
    }

    ///<summary>
    ///Handles the death sequence meaning that is stops the movement and triggers the death animation
    ///</summary>
    
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; // Disable all RigidBody2D movement
        anim.SetTrigger("death"); // Triggers the death animation
    }

    ///<summary>
    ///Restarts the current level
    ///</summary>
    
    private void RestartLevel()
    {
        //Reloads the current scene using its name 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}