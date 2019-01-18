/// Score.cs
/// Controls the score variable, comparing and setting the highscore

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject player;
    public TMP_Text scoreText;
    public DeathScreen deathScreen;
    public TMP_Text highScore;
    public TMP_Text highScoreOutput;

    private int score;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt( "Highscore" ).ToString();   // Set the end game highscore text to the players saved highscore

        highScoreOutput.text = PlayerPrefs.GetInt( "Highscore" ).ToString();   // Set the on screen while playing highscore text to the players saved highscore
    }

    // Fixed Update, so score doesnt increase faster with frame rate
    void FixedUpdate()
    { 
        if ( player.GetComponent<PlayerController>().alive )   // If alive is set to true on the player
        {
            score += 1;   // Increment the score by 1 every frame

            scoreText.text = score.ToString();   // Set the score text to the score variable

            if ( score > PlayerPrefs.GetInt( "Highscore", 0 ) )   // If the score is bigger than the highscore
            {
                PlayerPrefs.SetInt( "Highscore", score );   // Set the score to the new highscore

                highScore.text = score.ToString();   // Set the end game score to the new end game highscore

                highScoreOutput.text = score.ToString();   // Set the while playing score to the new while playing highscore
            }
        }
        else
        {
            scoreText.text = score.ToString();   // Set the score achieved to the score text

            StartCoroutine( DeathDelay() );   // Start the death delay coroutine
        }
	}

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(2.0f);   // Wait 2 seconds

        deathScreen.CallEndMenu( score );   // Call the death screen
    }
}