using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the pause menu functionality, including pausing/resuming the game. 
/// It also navigates to the main menu and quits the game
/// </summary>

public class Pause_Menu : MonoBehaviour
{
    // Reference to the pause meneu UI gameObject
    public GameObject pauseMenu;

    // Static variable to keep track of the pause state
    public static bool isPaused;

    // Start is called before the first frame update

    /// <summary>
    /// Start is called before the first frame update
    /// Initiliazes the pause meni and ensures it is hidden at the start
    /// </summary>
    void Start()
    {
        // Ensure the pause menu is not visible at the beginning of the game
        pauseMenu.SetActive(false);
    }

    /// <summary>
    /// Activates the pause menu and stops the game
    /// Freezes the game by setting the Time.timeScale to 0
    /// </summary>
    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Freezes the game
        isPaused = true; // Sets pause state to true
    }


    /// <summary>
    /// Deactivates the pause menu and resumes the game
    /// Unfreezes the game by setting the Time.timeScale to 1
    /// </summary>
    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Hides the pause menu
        Time.timeScale = 1f; // Unfreezes the game
        isPaused = false; // Sets the pause state to false
    }


    /// <summary>
    /// Update is called once per frame
    /// Checks for the escape key input toggle between pausing and resuming the game.
    /// </summary>
    void Update()
    {
        // Searches for the escape button to toggle the pause state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame(); // Resume the game if it is paused
            }
            else
            {
                PauseGame(); // Pause the game if it si not paused
            }
        }
    }

    /// <summary>
    /// Navigates back to the Main Menu, in our case the start scene
    /// Ensure the game is unfrozen before loading the main menu scene
    /// </summary>
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Unfreezes the game 
        SceneManager.LoadScene("Start Scene"); // Load the Start Scene 
    }

    /// <summary>
    /// Quits the game application
    /// It does not affect the unity editor. It works only in the built application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
