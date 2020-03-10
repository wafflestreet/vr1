using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Just place this in your scene somewhere and let objects send it points via UpdateScore method
/// </summary>
public sealed class ScoreManager : MonoBehaviour
{
    // Simple singleton pattern
    static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
            }

            return instance;
        }
    }

    [SerializeField] Text highScoreText;
    [SerializeField] Text currentScoreText;

    int currentScore;
    public int CurrentScore
    {
        get { return currentScore; }
        private set
        {
            currentScore = value;
            UpdateScoreText();
        }
    }

    // When the game launches, set the high score
    private void Awake()
    {
        SetHighScoreText();
    }

    // Just for testing - should delete the entire method
    // Uncomment to use this as a test
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        UpdateScore(10);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Return))
    //    {
    //        CheckForNewHighScore();
    //    }
    //}


    // Call this method to add more points (which will auto update the text for you)
    // Called like this ScoreManager.Instance.UpdateScore(10); from wherever points are given
    public void UpdateScore(int delta)
    {
        CurrentScore += delta;
    }


    private void UpdateScoreText()
    {
        currentScoreText.text = CurrentScore.ToString();
    }


    private void SetHighScoreText()
    {
        // We try to find a highscore, if there isn't one, we default to 0
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        highScoreText.text = highScore.ToString();
    }


    // Game ended - call this to set new highscore if there is one (and save it)
    public void CheckForNewHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();

            // Update high score text
            SetHighScoreText();
        }
    }
}