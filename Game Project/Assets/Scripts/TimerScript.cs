using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timeText;
    public int secondsLeft = 30;
    public bool takingAway = false;

    void Start()
    {
        timeText.text = " 00:" + secondsLeft;
    }

    void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft < 10)
        {
            timeText.text = "00 : 0" + secondsLeft;
        }  
        else if (secondsLeft <= 60)
        {
            timeText.text = "00 : " + secondsLeft;
        }
        else if (secondsLeft == 60)
        {
            timeText.text = "01 : 00";
        }
        else if (secondsLeft < 70)
        {
            timeText.text = "01 : 0" + (secondsLeft - 60);
        }
        else if (secondsLeft < 120)
        {
            timeText.text = "01 : " + (secondsLeft - 60);
        }
        else if (secondsLeft == 120)
        {
            timeText.text = "02 : 00";
        }
        else if (secondsLeft < 130)
        {
            timeText.text = "02 : 0" + (secondsLeft - 120);
        }
        else if (secondsLeft < 180)
        {
            timeText.text = "02 : " + (secondsLeft - 120);
        }
        else if (secondsLeft == 180)
        {
            timeText.text = "03 : 00";
        }
        else if (secondsLeft < 190)
        {
            timeText.text = "03 : 0" + (secondsLeft - 180);
        }
        else if (secondsLeft < 240)
        {
            timeText.text = "03 : " + (secondsLeft - 180);
        }
        else if (secondsLeft == 240)
        {
            timeText.text = "04 : 00";
        }
        else if (secondsLeft < 250)
        {
            timeText.text = "04 : 0" + (secondsLeft - 240);
        }
        else if (secondsLeft < 300)
        {
            timeText.text = "04 : " + (secondsLeft - 240);
        }
        else if (secondsLeft == 300)
        {
            timeText.text = "05 : 00";
        }

        takingAway = false;
    }
}
