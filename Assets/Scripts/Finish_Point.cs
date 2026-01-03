using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the level completion when the player reaches the finish point
/// </summary>

public class Finish_Point : MonoBehaviour
{
    // Audio source for the finish sound effect\
    private AudioSource finishSound;

    // Ensures the finish logic is executed only once
    private bool hasFinished = false;

    ///<summary>
    ///Initializes the audio source
    ///</summary>

    private void Start()
    {
        // Get the AudioSource component attached to the object
        finishSound = GetComponent<AudioSource>();
    }

    ///<summary>
    ///Trigerred when a collider enters the finish trigger zone
    ///</summary>
    ///<parameter name = "collision">The collider of the player that enters the trigger
    ///</parameter>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the player reached the finish point and the logic has not already been executed
        if (collision.gameObject.name == "Player" && !hasFinished)
        {
            finishSound.Play(); // Play the finish sound
            hasFinished = true; // Mark the level as completed
            Invoke(nameof(CompleteLevel), 1.5f); // Delay the level completion
        }
    }

    ///<summary>
    ///Loads the next level in the build order
    ///</summary>

    private void CompleteLevel()
    {
        // Loads the next scene by incrementing the current scene's build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
