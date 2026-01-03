using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

///<summary>
/// This script controlls the behavior of a firetrap
/// It can be trigerred by the player, when the player touches he dies and it follows an activation/deactivation cycle
/// </summary>

public class Firetrap_Activation : MonoBehaviour
{
    // Delay before the trap activates after being triggred
    [SerializeField] private float activationDelay;

    // Duration of the trap activation
    [SerializeField] private float activeTime;

    // Audio source for the Death sound effect
    [SerializeField] private AudioSource deathSound; 

    // Reference to the animator component 
    private Animator anim;
   

    // Reference to the SpriteRenderer component for visual effects
    private SpriteRenderer spriteRend;

    // Flag to check if the trap has been trigerred by the player
    private bool triggered;

    // Flag to check if the trap is activated and can kill the player
    private bool active;

    ///<summary>
    ///Reference to required components (Animator and SpriteRenderer)
    ///</summary>

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    ///<summary>
    ///Called when another collider enters the trap's trigger zone
    ///Kills the player only if the trap is active
    ///</summary>
    ///<parameter name = "collision">The object (player) that enters the trigger zone
    ///</parameter>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object entering the trap is the player
        if (collision.CompareTag("Player"))
        {
            // Starts the trap activation sequence if not already triggered
            if (!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
            // Kill the player only if the trap is active
            if (active)
            {
                Destroy(collision.gameObject); // Destroys the game object
                deathSound.Play(); // Play death sound
                RestartLevel(); // Calls the function to restart the level
            }

        }
    }

    ///<summary>
    ///Handles the firetrap's activation process. Changes the color to red to signal the player
    ///Waits for the activation delay and then it activates the trap
    ///Deactivates the trap after the active time
    ///</summary>

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;

        // Change the sprite color to red as a warning
        spriteRend.color = Color.red;

        // Wait for the specified activation delay
        yield return new WaitForSeconds(activationDelay);

        // Resets the prite color to its default and activates the trap
        spriteRend.color = Color.white;
        active = true;

        // Play the activation animation
        anim.SetBool("Activated", true);

        // Wait for the trap to remain active for the specified duration
        yield return new WaitForSeconds(activeTime);

        // Deactivate the trap and reset the variables
        active = false;
        triggered = false;

        // Stop the activation animation
        anim.SetBool("Activated", false);
    }

    private void RestartLevel()
    {
        // Reloads the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}