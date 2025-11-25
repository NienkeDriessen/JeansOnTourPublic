using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    public static float highScore;
    public float currentHighScore = 0;
    public TMP_Text displayHighScore;
    bool scoreSet;
    public TMP_Text displayNewHighscore;
    public GameObject highScoreText;
    public GameObject newHighScoreText;

    void Awake()
    {

    }
    void Start()
    {
        currentHighScore = 0;
        scoreSet = false;
    }

    public void Restart()
    {
        currentHighScore = 0;
        highScore = 0;
        scoreSet = false;
        displayHighScore.SetText(highScore + "%");
        highScoreText.GetComponent<CanvasGroup>().alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CutOut.done)
        {
            currentHighScore = Mathf.Round(percentageText.percentage);
        }
        if (currentHighScore > highScore)
        {
            newHighScoreText.GetComponent<CanvasGroup>().alpha = 1f;
            displayNewHighscore.SetText(currentHighScore + "%");
            highScore = currentHighScore;
            //scoreSet = true;
        }
        else if (highScore > 0 && !scoreSet)
        {
            highScoreText.GetComponent<CanvasGroup>().alpha = 1f;
            displayHighScore.SetText(highScore + "%");
        }
    }
}
