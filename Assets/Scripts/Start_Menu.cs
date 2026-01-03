using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///Handles the functionality of the start menu, including starting the game
///</summary>

public class Start_Menu : MonoBehaviour
{
   ///<summary>
   ///Starts the game by loading the next scene in the build order
   ///This method is called when the "Start" button is pressed
   ///</summary>
   
    public void StartGame()
    {
        // Load the next scene based on the current scene's build index 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

   


