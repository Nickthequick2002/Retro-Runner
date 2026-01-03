using UnityEngine;

///<summary>
///Makes the saw trap move between a series of points in a loop
///</summary>

public class Point_Movement : MonoBehaviour
{
    // Array of points the saw will move between
    [SerializeField] private GameObject[] points;

    // Index of the current point
    private int currentIndex = 0;

    // Movement speed of the saw (can be adjusted in the Inspector tab)
    [SerializeField] private float speed = 2f;

    ///<summary>
    ///Updates the saw position for every frame, moving it towards the current point
    ///</summary>
    private void Update()
    {
        // Checks if the saw is close enough to the current point
        if (Vector2.Distance(points[currentIndex].transform.position, transform.position) < 0.1f)
        {
            currentIndex++; // Move to the next point
        }

        // If the end of the point is reached, it prompts to loop back to the first point
        if (currentIndex >= points.Length)
        {
            currentIndex = 0;
        }

        // Moves the saw towwards the current point
        transform.position = Vector2.MoveTowards(transform.position, points[currentIndex].transform.position, Time.deltaTime * speed);
    }
}