using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Rotates the saw trap continuously around its Z-Axis at a specified speed
///</summary>

public class Saw_Rotation : MonoBehaviour
{
    // Rotation speed can be adjusted from the Inspector tab 
    [SerializeField] private float speed = 2f;

    ///<summary>
    ///Rotates the saw trap for every frame
    ///</summary>

    private void Update()
    {
        // Rotates the saw trap around the Z-Axis by an angle based on the given speed
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
