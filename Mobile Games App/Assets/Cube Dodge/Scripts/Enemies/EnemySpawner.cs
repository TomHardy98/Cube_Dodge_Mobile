/// EnemySpawner.cs
/// Controls the spawn rate, spawn positions and falling speed of the enemy blocks

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject fallingBlock;
    public Transform[] spawnPoints;
    public PlayerController player;
    public float minDelay = 0.5f;   // Set the minimum spawn delay to 0.5
    public float maxDelay = 1.0f;   // Set the maximum spawn delay to 1

    private bool spawning;
    private float massIncrease = 0.01f;   // Set the mass increase to 0.01

    void Start()
    {
        spawning = true;   // Set spawning to true

        StartCoroutine( SpawnFallingBlocks() );   // Start spawning the falling blocks using a Coroutine and IEnumerator
	}

    void FixedUpdate()
    {
        if ( spawning )   // If spawning is true
        {
            fallingBlock.GetComponent<Rigidbody>().mass = massIncrease;   // Set the falling blocks mass to the mass increase variable

            massIncrease += 0.015f * Time.deltaTime;   // Over time increase the falling blocks mass by 0.015 so blocks get heavier

            minDelay -= 0.0015f * Time.deltaTime;   // Over time decrease the minimum spawn delay so they fall more frequently

            maxDelay -= 0.0015f * Time.deltaTime;   // Over time decrease the maximum spawn delay so they fall more frequently

            if ( minDelay <= 0.2 )
            {
                minDelay = 0.2f;   // If the minimum delay is equal to 0.2 then keep it there
            }

            if ( maxDelay <= 0.3 )
            {
                maxDelay = 0.3f;   // If the maximum delay is equal to 0.3 then keep it there
            }

            if ( massIncrease >= 10 )
            {
                massIncrease = 10f;   // If the mass is equal to 10 then keep it there
            }
        }
    }

    IEnumerator SpawnFallingBlocks()
    {
        while ( spawning )   // If spawning is true
        {
            float delay = Random.Range( minDelay, maxDelay );   // Set the delay to a random number between the minimum and maximum delay

            yield return new WaitForSeconds( delay );   // Wait for the delay

            int spawnIndex = Random.Range( 0, spawnPoints.Length );   // Randomly select a spawn point from the array of spawns

            Transform spawnPoint = spawnPoints[spawnIndex];   // Set the blocks spawn point

            GameObject spawnedBlock = Instantiate( fallingBlock, spawnPoint.position, spawnPoint.rotation );   // Spawn a block at the spawn point

            if ( spawnedBlock )
            {
                Destroy( spawnedBlock, 10.0f );   // If the block has fallen for 10 seconds without being destroyed then destroy it
            }

            if ( player.alive == false )
            {
                spawning = false;   // If the player has been killed then stop spawning
            }
        }
    }
}