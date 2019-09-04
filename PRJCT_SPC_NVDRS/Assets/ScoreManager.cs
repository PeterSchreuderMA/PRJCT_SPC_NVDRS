using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //- Score texts
    Text playerScoreText;
    Text waveCounter;
    Text waveCounterBest;
    Text highScoreText;

    public int playerScore = 0;
    int waveAmount = 1;

    //FindObjectOfType<Enemy>().OnEnemyDeath += AddScore;

    void Start()
    {

        //- Init the scores
        //- Player score
        playerScoreText = GameObject.FindGameObjectWithTag("PlayerScore").GetComponent<Text>();
        waveCounter = GameObject.FindGameObjectWithTag("TextWaveCounter").GetComponent<Text>();

        //- Best wave
        waveCounterBest = GameObject.FindGameObjectWithTag("TextWaveCounterBest").GetComponent<Text>();
        UpdateText(waveCounterBest, "Best Wave\n" + PlayerPrefs.GetInt("BestWave", 0).ToString());

        //- Highscore
        highScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
        UpdateText(highScoreText, "High Score\n" + PlayerPrefs.GetInt("HighScore", 0).ToString());
    }

    public void AddScore(int _amount)
    {
        playerScore += _amount;
        UpdateText(playerScoreText, "Score\n" + playerScore.ToString());
    }

    public void WaveAmount(int _amount)
    {
        waveAmount = _amount;
        UpdateText(waveCounter, "Wave\n" + waveAmount.ToString());
    }

    /// <summary>
    /// Saves the player score to PlayerPrefs's "HighScore"
    /// </summary>
    public void SaveHighScore()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", playerScore);

        if (waveAmount > PlayerPrefs.GetInt("BestWave", 1))
            PlayerPrefs.SetInt("BestWave", waveAmount);
    }

    void UpdateText(Text _text, string _string)
    {
        _text.text = _string;
    }

}
