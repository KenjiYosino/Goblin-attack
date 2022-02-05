using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    [SerializeField] Text HighScoreText;
    [SerializeField] Text ScoreText;
    private int highscore;
   
    private void Start()
    {
        score = 0;
        HighScoreText.text = PlayerPrefs.GetInt("score").ToString();
    }

    private void Update()
    {
        if (highscore != score)
        {
            highscore = score;
            ScoreText.text = highscore.ToString();
            if (PlayerPrefs.GetInt("score") <= highscore) PlayerPrefs.SetInt("score", highscore); 
            HighScoreText.text = PlayerPrefs.GetInt("score").ToString();
        }
    }
}
