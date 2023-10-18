using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text  highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        var score = PlayerPrefs.GetInt("score");
        scoreText.text = score.ToString();

        var highScore = PlayerPrefs.GetInt("highScore");
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        highScoreText.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
