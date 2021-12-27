using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private float startMinutes = 2;
    public Text currentTimeText;
    public PlayerDeath deathManager;

    float currentTime;

    bool timerActive = true;




    void Start()
    { 
        currentTime = startMinutes * 60;
    }

    void Update()
    {
        CountDownTimer();

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = "Chrono : " + time.Minutes.ToString() +  "'" + time.Seconds.ToString();

        CheckIfTimerIsOver();
    }


    private void CountDownTimer()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void CheckIfTimerIsOver()
    {
        if (currentTime <= 0)
        {
            timerActive = false;
            deathManager.Dead();
        }
    }
}
