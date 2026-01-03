using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the behavior of a falling platform
/// The platform will fall after the delay when the player lands on it and it will be destroyed a few seconds after falling
///</summary>
public class Falling_Platform : MonoBehaviour
{
    // Time to wait before the platform starts falling after being triggered
    [SerializeField] private float fallDelay = 1f;

    // Time to wait before the platform is destroyed after it starts falling
    [SerializeField] private float destroyDelay = 2f;

    // Flag to prevent the coroutine from being called multiples times
    private bool falling = false;

    // Reference to the platform's RigidBody2D to enable physics-based falling
    [SerializeField] private Rigidbody2D rb;

    ///<summary>
    ///Triggered when player collides with the platform
    ///Starts the falling behavior if the player lands on it
    ///</summary>
    ///<parameter name = "collision">The colliding object (in our case the player) involved in the event
    ///</parameter>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the platform is already falling, do nothing
        if(falling)
        {
            return;
        }

        // Check if the colliding object is tagged as "Player"
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(StartFall()); // Begin the fall method
        }
    }

    ///<summary>
    ///Coroutine to handle the delayed falling and destruction of the platform
    ///</summary>
    ///<return> IEnumator for the coroutine functionality</return>
    
    private IEnumerator StartFall()
    {
        falling = true; // Marks the platform falling to prevent duplicate calls

        // Wait for the mentioned fall delay before enabling the falling behavior
        yield return new WaitForSeconds(fallDelay);

        // Change the RigidBody2D type to dynamic to enable the physics-based falling
        rb.bodyType = RigidbodyType2D.Dynamic;

        // Destroy the platform after the specified destruction delay
        Destroy(gameObject,destroyDelay);
    }

  

}
