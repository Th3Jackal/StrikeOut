using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public static ScoreText instance;

    public Text scoreBoard;
    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreBoard.text = score.ToString();
    }

    public void increaseScore() {
        score += 1;
        scoreBoard.text = score.ToString();
    }
}
