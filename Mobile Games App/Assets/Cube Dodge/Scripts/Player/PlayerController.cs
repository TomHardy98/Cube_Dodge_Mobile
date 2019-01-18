/// PlayerController.cs
/// Controls the player variables, rolling movement and collisions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject brokenPlayer;
    public GameObject center;
    public GameObject left;
    public GameObject right;
    public GameObject invisibleCollision;
    public bool alive;

    private Vector3 offset;
    private float threshold = 0.1f;
    private int step = 9;
    private bool isMoving = true;

	void Start()
    {
        alive = true;   // Set alive to true

        Screen.orientation = ScreenOrientation.LandscapeLeft;   // Set screen orientation to landscape left at start of game
    }

	void Update()
    {
        if ( alive )   // If alive is true
        {
            if ( isMoving == true )   // If isMoving is true
            {
                if ( Input.acceleration.x < -threshold )   // If the accelerometer is tilted past the threshold
                {
                    StartCoroutine( "MoveLeft" );   // Start the move left coroutine

                    isMoving = false;   // Set isMoving to false
                }

                if ( Input.acceleration.x > threshold )   // If the accelerometer is tilted past the threshold
                {
                    StartCoroutine( "MoveRight" );   // Start the move right coroutine

                    isMoving = false;   // Set isMoving to false
                }
            }

            // If you fall off the map then disable all controls

            if ( player.transform.position.x <= -10 )   // If the players position is off the map
            {
                player.GetComponent<Rigidbody>().isKinematic = false;   // Set isKinematic to false

                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;   // Remove all rigidbody constraints
            }

            // If you fall off the map then disable all controls

            if ( player.transform.position.x >= 10.1 )   // If the players position is off the map
            {
                player.GetComponent<Rigidbody>().isKinematic = false;   // Set isKinematic to false

                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;   // Remove all rigidbody constraints
            }
        }
    }

    IEnumerator MoveLeft()
    {
        for ( int i = 0; i < ( 90 / step ); ++i )   // Loop through 90 times for 90 degrees
        {
            player.transform.RotateAround ( left.transform.position, Vector3.forward, step );   // Rotate the cube around the left transform position attached to the cube

            yield return null;
        }

        yield return new WaitForSeconds( 0.1f );   // Wait for 0.1

        center.transform.position = player.transform.position;   // Set the center transform position to the players transform position (recenter)

        isMoving = true;   // Set isMoving to true
    }

    IEnumerator MoveRight()
    {
        for ( int i = 0; i < ( 90 / step ); ++i )   // Loop through 90 times for 90 degrees
        {
            player.transform.RotateAround ( right.transform.position, Vector3.back, step );   // Rotate the cube around the left transform position attached to the cube

            yield return null;
        }

        yield return new WaitForSeconds( 0.1f );   // Wait for 0.1

        center.transform.position = player.transform.position;   // Set the center transform position to the players transform position (recenter)

        isMoving = true;   // Set isMoving to true
    }

    void OnCollisionEnter( Collision collision )   // Players collision function
    {
        if ( collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "InvisibleCollision" )   // If the player collides with an enemy or the out of bounds
        {
            Handheld.Vibrate();

            invisibleCollision.GetComponent<BoxCollider>().enabled = false;   // Disable the box collider of the out of bounds box

            gameObject.GetComponent<MeshRenderer>().enabled = false;   // Disable the mesh renderer of the player

            gameObject.GetComponent<BoxCollider>().enabled = false;   // Disable the box collider of the player

            GameObject playerBroken = Instantiate( brokenPlayer, transform.position, transform.rotation );   // Instantiate the broken player object on the players position

            Destroy( playerBroken, 3.0f );   // Destroy the broken player object after 3 seconds

            IsDead();   // Call the isDead function
        }
    }

    void IsDead()
    {
        alive = false;   // Set alive to false
    }
}