/// DeathScreen.cs
/// Controls the death screen, calling restart game and back to menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject player;
    public TMP_Text scoreText;

	void Start()
    {
        gameObject.SetActive( false );   // On load set deactivate the death screen
    }

    public void CallEndMenu( int score )
    {
        gameObject.SetActive( true );   // Activate the death screen
        scoreText.text = ( ( int )score ).ToString();   // Set the players score
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   // Load the scene again
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene( 0 );   // Call scene 0 (Main Menu)
    }
}