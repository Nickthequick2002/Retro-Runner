using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Controls the camera to follow the player's position
///</summary>

public class Camera_Movement : MonoBehaviour
{
    // Reference to the player's transform component
    [SerializeField] private Transform player;

    ///<summary>
    ///Updates the camera's position for every frame to match the player's position
    ///</summary>

    private void Update()
    {
        // Checks if the player exists before updating the camera's position
        if (player != null)
        {
            // Updates the camera's position to follow the player
            // Maintain the current Z position to keep the camera's depth constant 
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}


