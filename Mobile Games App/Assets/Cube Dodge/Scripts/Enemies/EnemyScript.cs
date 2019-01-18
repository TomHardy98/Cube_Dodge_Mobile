/// EnemyScript.cs
/// Controls the enemies collision variables

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject brokenBlock;
    public GameObject player;

    private void OnCollisionEnter( Collision collision )   // Check for a collision in the enemy
    {
        // If the enemy collides with the floor, player or the out of bounds box then do something
        if ( collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "InvisibleCollision" )
        {
            Destroy( gameObject );   // Destroy the enemy

            GameObject brokenBlockClone = Instantiate( brokenBlock, gameObject.transform.position, gameObject.transform.rotation );   // Instatiate the broken block where the enemy was

            Destroy( brokenBlockClone, 0.5f );   // Destroy the broken block after half a second
        }
    }
}