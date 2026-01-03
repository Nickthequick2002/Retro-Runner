using UnityEngine;

/// <summary>
/// This script allows the player to stick to a moving platform when on it and detach when leaving
/// </summary>

public class Platform_Movement : MonoBehaviour
{
    ///<summary>
    ///The function is called when another collider (the player) enters the platform's trigger
    ///Makes the player a child of the platform to move with it
    ///</summary>
    ///<parameter name = "collision">The collider of the player entering the trigger</parameter>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the colliding obejct is the player
        if (collision.gameObject.name == "Player")
        {
            // Sets the player as a child of the platform to move together
            collision.gameObject.transform.SetParent(transform);
        }
    }

    ///<summary>
    ///The above function is called when the player exits the platform's trigger
    ///Deatches the player from the platform
    ///</summary>
    ///<parameter name = "collision">The collider of the player exiting the trigger
    ///</parameter>

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if the colliding object is the player
        if (collision.gameObject.name == "Player")
        {
            // Removes the player from the platform's hierarchy
            collision.gameObject.transform.SetParent(null);
        }
    }

}
