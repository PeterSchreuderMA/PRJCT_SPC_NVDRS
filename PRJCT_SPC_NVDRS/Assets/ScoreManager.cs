using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //- Score texts
    Text playerScoreText;
    Text highScoreText;

    int playerScore = 0;

    //FindObjectOfType<Enemy>().OnEnemyDeath += AddScore;

    void Start()
    {
        playerScoreText = GameObject.FindGameObjectWithTag("PlayerScore").GetComponent<Text>();

        //- Init the highscore
        highScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
        highScoreText.text = "High Score\n" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    public void AddScore(int _amount)
    {
        playerScore += _amount;
        UpdateText(playerScoreText, "Score\n" + playerScore.ToString());
    }

    /// <summary>
    /// Saves the player score to PlayerPrefs's "HighScore"
    /// </summary>
    private void SaveHighScore()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", playerScore);
    }

    void UpdateText(Text _text, string _string)
    {
        _text.text = _string;
    }

}
