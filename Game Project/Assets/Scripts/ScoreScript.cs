using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public Text winMessage;
    public int scoreLimit = 5;
    public BallCodes Goal;
    public TimerScript timer;

    public bool win = false;

    void Start()
    { 
        scoreText.text = "Score : " + Goal.Score;
    }

    void Update()
    {
        scoreText.text = "Score : " + Goal.Score;
        if(Goal.Score == scoreLimit && timer.secondsLeft != 0)
        {
            win = true;
            winMessage.text = "BOLUM BASARILI";

        }else if(timer.secondsLeft == 0 && Goal.Score != scoreLimit)
        {
            win = false;
            winMessage.text = "BOLUM BASARISIZ";
        }

    }
}
