using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///Handles the item collection logic and updates the score and plays the collect sound effect
///</summary>

public class Item_Collect : MonoBehaviour
{
    //Tracks the number of items collected
    private int apples = 0;

    //UI text element to display the current score
    [SerializeField] private Text score;

    //Sound effect for collecting an item
    [SerializeField] private AudioSource collectSound;

    ///<summary>
    ///The above function is called when the player collides with a collectible item
    ///</summary>
    ///<parameter name = "collision">The collider of the item the player interacts with
    ///</parameter>

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the collided object is tagged us "Apple"
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject); // Removes the collected item from the scene
            apples++;
            score.text = "Score: " + apples; // Updates the score display
            collectSound.Play(); // Plays the collection sound effect
        }
    }
}


