using UnityEngine;

/// <summary>
/// Handles the functionality of the end menu and quits the application
/// </summary>
public class End_Menu : MonoBehaviour
{
    ///<summary>
    ///Quits the application
    ///This method is called when the "Quit" button is presed
    ///</summary>

    public void Quit()
    {
        // Closes the application
        // This method will not close the Unity Editor, just quits the game 
        Application.Quit();
    }
}
