using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed to restart the level

///<summary>
///Handles the behavior of the spikehead trap, including detecting and chasing the player
///Restarts the level when the player is caught and eventually is dea
///</summary>

public class Spikehead : MonoBehaviour
{
    [SerializeField] private float speed; // Movement speed of Spikehead
    [SerializeField] private float range; // Detection of range for the player
    [SerializeField] private float checkDelay; // Delay between detection checks
    [SerializeField] private LayerMask playerLayer; // Layer to identify the player

    private Transform player; // Reference to the player's transform
    private float checkTimer; // Timer to track delay between the checks
    private bool attacking; // Flag to indicate if the spikehead is chasing the player
    private Vector3 currentDirection; // Direction of the Spikehead's movement
    private bool stoppedByBlock; // Flag to ensure the Spikehead stops when it meets a block

    ///<summary>
    ///The function below is called when the object becomes active
    ///Stops the Spikehead's moevemtn and resets its state
    ///</summary>
    
    private void OnEnable()
    {
        ResetState();
    }

    /// <summary>
    /// Called oncepre frame to handle the Spikehead's behavior
    /// Moves the Spikehead if it is attacking, or checks for the player if not
    /// </summary>
    
    private void Update()
    {
        // Do nothing if stopped by a block
        if (stoppedByBlock)
            return;

        // If attacking and the player exists, moves towards the player
        if (attacking && player != null)
        {
            // Calculate the direction towards the player and moves
            currentDirection = (player.position - transform.position).normalized;
            transform.Translate(currentDirection * Time.deltaTime * speed);
        }
        else
        {
            //Increment the check timer and checks for the player if has exceeded the delay
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
            
        }
    }

    ///<summary>
    ///Checks for the player within the Spikehead's detection range
    ///</summary>
    
    private void CheckForPlayer()
    {
        // Use circular detection to find the player within range
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, playerLayer);

        if (hit != null)
        {
            // Player detected and starts chasing the player
            attacking = true;
            player = hit.transform;
        }

        // Resets the check timer
        checkTimer = 0;
    }

    ///<summary>
    ///Stops the spikehead's movement and resets is attacking state
    ///</summary>


    ///<summary>
    ///Handles the collision with the player. Destroys the player and restarts the level
    ///</summary>
    ///<parameter name = "collision">The object the Spikehead collides with (player)</parameter>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the Spikehead colides with the player
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destroys the player
            RestartLevel(); // Restarts the level
        }

        if (collision.gameObject.CompareTag("Terrain"))
        {
            StopMovementOnBlock();
        }
    }

    ///<summary>
    ///Restarts the current level by reloading the active scene
    ///</summary>
    
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current level
    }

    ///<summary>
    ///Draws a visualization of the detectioon range in the Scene view 
    ///</summary>

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Sets gizmo color to red
        Gizmos.DrawWireSphere(transform.position, range); // Draw a wireframe sphere
    }

    private void StopMovementOnBlock()
    {
        stoppedByBlock = true; // Prevents further movement
        attacking = false; // Disables attacks
        currentDirection = Vector3.zero; // Resets the direction to stop the movement
    }

    private void ResetState()
    {
        attacking = false; 
        stoppedByBlock = false;
        player = null;
        currentDirection = Vector3.zero;
    }
}